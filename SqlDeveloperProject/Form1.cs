using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlDeveloperProject
{
    public partial class Form1 : Form
    {

        DatabaseHandler dbHandler;
        string currentSchema = "";
        string currentSchemaObject = ""; //This string can only be "Table", "Function", "Procedure", "View"
        string username, password;

        public Form1(string _user, string _pass)
        {
            InitializeComponent();
            username = _user;
            password = _pass;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

            DatabaseHandler.userLogged = username;
            DatabaseHandler.userPassword = password;

            dbHandler = new DatabaseHandler();



            var connections = dbHandler.GetConnections();

            PopulateTreeView(connections);


        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            

        }

        private void PopulateTreeView(List<String> dataset)
        {
            foreach (String data in dataset)
                treeView1.Nodes.Add(data);
        }

        
        private void PopulateTreeViewWithKey(TreeView selectedNode)
        {
            /* Function will get the data according to the level of the node in the treeview
             * 0 level = Get Schemas 
             * 1 level = Get Tables, Functions, Views and Procedures
             * 2 level = Get Table Fields (Just a string which may be Table, Procedure, Functions and Views)
             * 3 level = Get, according to the treenode text, return its data (for example, if the user clicked table, get the tables of that schema and displayed it and so on) 
             * 4 level = depends it is a tbale or stored procedure or function*/

            //Given the level of the selected node and the text of the selected node, its possible to get its data
            string nodeText = selectedNode.SelectedNode.Text; 

            int level = selectedNode.SelectedNode.Level;
            List<String> listData = new List<string>();

            switch (level)
            {
                case 0:
                    listData = dbHandler.GetConnectionSchemas(nodeText);
                    break;
                case 1:
                    listData = dbHandler.GetSchemaStringObjects(nodeText);
                    currentSchema = nodeText;
                    DatabaseHandler.currentSchema = currentSchema;
                    break;
                case 2:

                    /*Given the text of the node, if the text of the node is equal to "Table" then call the function
                    * that returns the tables of the given schema */

                    switch (nodeText)
                    {

                        case "Tables":
                            listData = dbHandler.GetSchemaTables(currentSchema);
                            currentSchemaObject = "Tables";
                            break;

                        case "Functions":
                            listData = dbHandler.GetSchemaFunctions(currentSchema);
                            currentSchemaObject = "Functions";
                            break;

                        case "Procedures":
                            listData = dbHandler.GetSchemaProcedures(currentSchema);
                            currentSchemaObject = "Procedures";
                            break;

                        case "Views":
                            listData = dbHandler.GetSchemaViews(currentSchema);
                            currentSchemaObject = "Views";
                            break;

                        case "Indexes":
                            listData = dbHandler.GetSchemaIndexes(currentSchema);
                            currentSchemaObject = "Indexes";
                            break;

                    }

                    break;
                case 3:
                    /* If the current schema object is table, call the function that brings the data of that table ( the table name is the selected node text )
                     * and so on */

                    switch (currentSchemaObject)
                    {

                        case "Tables":
                            PopulateDataGridView(nodeText);
                            break;

                        case "Functions":

                            break;

                        case "Procedures":

                            break;

                        case "Views":
                            GetViewData(nodeText);
                            break;

                    }
                    break;
                default:
                    return;
            }

            selectedNode.SelectedNode.Nodes.Clear();

            foreach (String data in listData)
                selectedNode.SelectedNode.Nodes.Add(data);

        }

        private void GetViewData(string nodeText)
        {
            dtgvTables.DataSource = dbHandler.GetViewData(nodeText);
        }

        private void PopulateDataGridView(string nodeText)
        {
            try
            {
                dtgvTables.DataSource = dbHandler.GetTableData(nodeText, currentSchema);
            }catch(Exception e)
            {
                return;
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeView selectedNode = sender as TreeView;

            if(e.Node != null)
                if(e.Node.Parent != null)
                    if(e.Node.Parent.Parent != null)
                        if(e.Node.Parent.Parent.Text != "Connection 1")
                currentSchema = e.Node.Parent.Parent.Text;

            PopulateTreeViewWithKey(selectedNode);

        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            Tables table = new Tables();
            DatabaseHandler.currentSchema = "HOCKEY";

            table.Show();
        }

        private void btnFunction_Click(object sender, EventArgs e)
        {
            Functions function = new Functions();
           

            function.Show();
        }

        private void btnProcedure_Click(object sender, EventArgs e)
        {
            Procedures procedures = new Procedures();
            procedures.Show();
        }

        private void btnVIew_Click(object sender, EventArgs e)
        {
            Views views = new Views();
            views.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var index = new Indexes();
            index.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dtgvTables.DataSource == null)
                return;

            if (dtgvTables.CurrentCell == null)
                return;

            int rowIndex = dtgvTables.CurrentCell.RowIndex;
            dtgvTables.Rows.RemoveAt(rowIndex);

            var status = dbHandler.UpdateTableData(dtgvTables.DataSource as DataTable);
            if (status == "Success")
            {
                MessageBox.Show("Data Deleted");
            }
            else
            {
                MessageBox.Show("Something Went Wrong while updating/modifying deleting\nMessage: " + status);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dtgvTables.DataSource == null)
                return;

            var status = dbHandler.UpdateTableData(dtgvTables.DataSource as DataTable);
            if (status == "Success")
            {
                MessageBox.Show("Data Updated");
            } else
            {
                MessageBox.Show("Something Went Wrong while updating/modifying deleting\nMessage: "+status);
            }
        }
    }
}
