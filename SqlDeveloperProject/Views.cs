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
    public partial class Views : Form
    {
        public Views()
        {
            InitializeComponent();
        }

        private void Views_Load(object sender, EventArgs e)
        {
            LoadTablesToCombobox();

            
        }

        private void LoadTablesToCombobox()
        {
            cmbSchemasCreate.Items.Clear();
            cmbSchemasDelete.Items.Clear();
            cmbDeleteViewName.Items.Clear();

            var listViews = new DatabaseHandler().GetSchemaProcedures(DatabaseHandler.currentSchema);
            var listSchemas = new DatabaseHandler().GetConnectionSchemas("");

            foreach (String str in listViews)
                cmbDeleteViewName.Items.Add(str);

            foreach (String str in listSchemas)
            {
                if (str != "SYSTEM")
                    cmbSchemasDelete.Items.Add(str);

                cmbSchemasCreate.Items.Add(str);
            }

            cmbSchemasCreate.SelectedIndex = cmbSchemasDelete.SelectedIndex = 0;
        }

        private void btnCreateView_Click(object sender, EventArgs e)
        {

            string ddl = "Create View \"" + cmbSchemasCreate.SelectedItem.ToString() + "\"." + RemoveWhiteSpaceFromString(txtViewName.Text) + " AS " + txtSQL.Text;

            labelScript.Text = ddl;

            txtViewName.Text = txtSQL.Text = "";

            string status = new DatabaseHandler().CreateView(ddl);

            if(status == "Success")
            {
                MessageBox.Show("Created Succesfully");
            }
            else
            {
                MessageBox.Show("Error while creating view\nMessage: " + status);
            }

        }

        private void btnDeleteProcedure_Click(object sender, EventArgs e)
        {

            DatabaseHandler dbHandler = new DatabaseHandler();
            string status = "";

            if (cmbDeleteViewName.Items.Count != 0)
            {
                status = dbHandler.DeleteView(cmbDeleteViewName.SelectedItem.ToString(), cmbSchemasDelete.SelectedItem.ToString());

                if(status == "Success")
                {
                    MessageBox.Show("View deleted");
                    LoadTablesToCombobox();
                }
                else
                {
                    MessageBox.Show("Something went wrong while deleting the view\nError message: " + status);
                }

            }

            

        }

        private void cmbSchemasDelete_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cmb = sender as ComboBox;

            var listViews = new DatabaseHandler().GetSchemaViews(cmb.SelectedItem.ToString());

            cmbDeleteViewName.Items.Clear();

            foreach (String str in listViews)
                cmbDeleteViewName.Items.Add(str);

            if (cmbDeleteViewName.Items.Count != 0)
                cmbDeleteViewName.SelectedIndex = 0;
        }

        private void btnLoadScript_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Theres no View DDL");
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
    }
}
