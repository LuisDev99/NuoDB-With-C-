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
    public partial class Indexes : Form
    {

        DatabaseHandler dbHandler;

        public Indexes()
        {
            InitializeComponent();
        }

        private void Indexes_Load(object sender, EventArgs e)
        {
            dbHandler = new DatabaseHandler();
            LoadTablesToCombobox();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void cmbSchemasCreate_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cmb = sender as ComboBox;
            var listTables = dbHandler.GetSchemaTables(cmb.SelectedItem.ToString());

            cmbTableName.Items.Clear();

            foreach (String str in listTables)
                cmbTableName.Items.Add(str);

            cmbTableName.SelectedIndex = 0;

        }

        private void LoadTablesToCombobox()
        {
            cmbSchemasCreate.Items.Clear();
            cmbSchemasDelete.Items.Clear();
            cmbDeleteIndexName.Items.Clear();
            cmbTableName.Items.Clear();

            //cmbDeleteFunctionName.Items.Clear();

            var listIndexes = dbHandler.GetSchemaIndexes(DatabaseHandler.currentSchema);
            var listSchemas = dbHandler.GetConnectionSchemas("");

            foreach (String str in listIndexes)
                cmbDeleteIndexName.Items.Add(str);
            
            foreach (String str in listSchemas)
            {
                if (str != "SYSTEM")
                    cmbSchemasDelete.Items.Add(str);

                cmbSchemasCreate.Items.Add(str);
            }

            cmbSchemasCreate.SelectedIndex = cmbSchemasDelete.SelectedIndex = 0;
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            MessageBox.Show("Hello");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSelectTable_Click(object sender, EventArgs e)
        {
            if(txtIndexName.Text == "")
            {
                MessageBox.Show("Enter the index name in order to continue");
                return;
            }

            if (cmbTableName.Items.Count == 0)
            {
                MessageBox.Show("Select a schema with tables");
                return;
            }

            cmbSchemasCreate.Enabled = cmbTableName.Enabled = txtIndexName.Enabled = false;
            checkedListBox1.Enabled = btnCreateIndex.Enabled = btnCreateUniqueIndex.Enabled = true;

            var tableFields = dbHandler.GetTableFields(cmbTableName.SelectedItem.ToString());

            checkedListBox1.Items.Clear();
            foreach(String str in tableFields)
            {
                checkedListBox1.Items.Add(str);   
            }


        }

        private void btnCancelSelection_Click(object sender, EventArgs e)
        {
            cmbSchemasCreate.Enabled = cmbTableName.Enabled = txtIndexName.Enabled = true;
            checkedListBox1.Enabled = btnCreateIndex.Enabled = btnCreateUniqueIndex.Enabled = false;


        }

        private void btnCreateIndex_Click(object sender, EventArgs e)
        {
            if(checkedListBox1.CheckedItems.Count == 0)
            {
                MessageBox.Show("Select at least one table field to create index!");
                return;
            }
            CreateScript(false);

            var status = dbHandler.CreateIndex(labelScript.Text);

            if (status == "Success")
            {
                MessageBox.Show("Index created successfully");
                LoadTablesToCombobox();
            }
            else
            {
                MessageBox.Show("Error while creating index\nError message: " + status);
            }

        }

        private void btnCreateUniqueIndex_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count == 0)
            {
                MessageBox.Show("Select at least one table field to create index!");
                return;
            }

            CreateScript(true);

            var status = dbHandler.CreateIndex(labelScript.Text);

            if(status == "Success")
            {
                MessageBox.Show("Index created successfully");
                LoadTablesToCombobox();
            }
            else
            {
                MessageBox.Show("Error while creating index\nError message: " + status);
            }
        }

        public void CreateScript(bool isUniqueIndex)
        {
            /*
             CREATE UNIQUE INDEX
                PLAYER_IDX
                ON
                HOCKEY
                (
                NUMBER,
                NAME,
                TEAM
                );
             */
            string script = (isUniqueIndex) ? "CREATE UNIQUE INDEX " : "CREATE INDEX ";

            script += RemoveWhiteSpaceFromString(txtIndexName.Text) + " ON " + cmbSchemasCreate.SelectedItem.ToString() + "."+ cmbTableName.SelectedItem.ToString();

            script += " (";

            for(int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if(checkedListBox1.GetItemChecked(i) == true)
                {
                    script += checkedListBox1.Items[i].ToString();

                    if( checkedListBox1.Items.Count != i + 1)
                    {
                        script += ",";
                    }
                }
            }

            script += ");";

            labelScript.Text = script;
        }

        private void checkedListBox1_ItemCheck_1(object sender, ItemCheckEventArgs e)
        {
            CreateScript(false);
        }

        public string RemoveWhiteSpaceFromString(string str)
        {
            /* Remove all whitespaces and fills the whitespace by joining the rest of the string*/

            return new string(str.Where
                            (
                                c => !char.IsWhiteSpace(c)
                            )
                            .ToArray<char>()
                       );
        }

        private void cmbSchemasDelete_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listIndexes = dbHandler.GetSchemaIndexes(cmbSchemasDelete.SelectedItem.ToString());

            cmbDeleteIndexName.Items.Clear();

            foreach (String str in listIndexes)
                cmbDeleteIndexName.Items.Add(str);

            if(cmbDeleteIndexName.Items.Count > 0)
                cmbDeleteIndexName.SelectedIndex = 0;
        }

        private void btnDeleteIndex_Click(object sender, EventArgs e)
        {

            if (cmbSchemasDelete.SelectedItem.ToString() == "")
            {
                MessageBox.Show("Select a schema to delete the index");
                return;
            }

            if (cmbDeleteIndexName.Items.Count == 0)
                return;

            string status = dbHandler.DeleteIndex("\""+cmbDeleteIndexName.SelectedItem.ToString()+"\"", cmbSchemasDelete.SelectedItem.ToString());

            if (status == "Success")
            {
                MessageBox.Show("Index Deleted Correctly");
                LoadTablesToCombobox();
                cmbDeleteIndexName.Items.Clear();
            }
            else
            {
                MessageBox.Show("Something went wrong while deleting index\nError message: " + status);
            }

        }

        private void btnLoadScript_Click(object sender, EventArgs e)
        {
            if (cmbDeleteIndexName.Items.Count == 0)
                return;


            var listIndexFields = dbHandler.GetIndexFields(cmbDeleteIndexName.SelectedItem.ToString(), cmbSchemasDelete.SelectedItem.ToString());

            string script = "INDEX " + cmbDeleteIndexName.SelectedItem.ToString();
            script += "\n----- Fields -----\n";

            foreach(string str in listIndexFields)
            {
                script += "\t" + str + "\n";
            }

            txtDDL.Text = script;

        }
    }
}
