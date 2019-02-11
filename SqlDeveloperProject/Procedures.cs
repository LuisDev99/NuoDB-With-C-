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
    public partial class Procedures : Form
    {

        DatabaseHandler dbHandler;
        List<String> parametersName;
        List<String> parametersType;


        public Procedures()
        {
            InitializeComponent();
        }

        private void Procedures_Load(object sender, EventArgs e)
        {
            dbHandler = new DatabaseHandler();
            parametersName = new List<string>();
            parametersType = new List<string>();
            cmbDataTypeParameter.SelectedIndex = 0;

            LoadTablesToCombobox();

        }

        private void LoadTablesToCombobox()
        {
            cmbSchemasCreate.Items.Clear();
            cmbSchemasDelete.Items.Clear();
            cmbDeleteProcedureName.Items.Clear();

            var listProcedures = dbHandler.GetSchemaProcedures(DatabaseHandler.currentSchema);
            var listSchemas = dbHandler.GetConnectionSchemas("");

            foreach (String str in listProcedures)
                cmbDeleteProcedureName.Items.Add(str);

            foreach (String str in listSchemas)
            {
                if (str != "SYSTEM")
                    cmbSchemasDelete.Items.Add(str);

                cmbSchemasCreate.Items.Add(str);
            }

            cmbSchemasCreate.SelectedIndex = cmbSchemasDelete.SelectedIndex = 0;
        }

        private void btnAddParameter_Click(object sender, EventArgs e)
        {
            parametersName.Add(RemoveWhiteSpaceFromString(txtParameterName.Text));
            parametersType.Add(cmbDataTypeParameter.SelectedItem.ToString());

            UpdateLabelScript();
        }

        public void UpdateLabelScript()
        {
            /*@delimiter %%%;
            CREATE
            PROCEDURE "MANGO".Hola(INOUT sas STRING) SECURITY INVOKER
            AS
                THROW 'Not implemented yet!';
                END_PROCEDURE;
                %%%
            @delimiter ;
            %%%*/

            labelScript.Text = "CREATE \n PROCEDURE \"" + cmbSchemasCreate.SelectedItem.ToString() + "\"." + RemoveWhiteSpaceFromString(txtProcedureName.Text) + "(";

            /* Add Parenthesis and the parameters to the string */
            for (int i = 0; i < parametersName.Count; i++)
            {

                labelScript.Text += "INOUT " + parametersName[i].ToString() + " " + parametersType[i].ToString();

                if (parametersName.Count != i + 1)
                {
                    labelScript.Text += ", ";
                }
            }

            labelScript.Text += ") SECURITY INVOKER\nAS\n " + txtSQL.Text + ";";

            labelScript.Text += "\n END_PROCEDURE;";

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

        private void btnCreateProcedure_Click(object sender, EventArgs e)
        {
            UpdateLabelScript();

            if (txtProcedureName.Text != "")
            {

                if (parametersName.Count != 0)
                {

                    if (txtSQL.Text != "")
                    {
                        string generatedDDL = GenerateDDL();

                        string state = dbHandler.CreateProcedure(generatedDDL);

                        if (state == "Success")
                            MessageBox.Show("Procedure created succesfully!");
                        else
                            MessageBox.Show("Error while creating procedure\n Error Message: " + state);
                    }
                    else
                    {
                        MessageBox.Show("Enter the sql command!!");
                    }

                }
                else
                {
                    MessageBox.Show("Add at least one parameter to create the procedure!!!");
                }


            }
            else
                MessageBox.Show("Write the procedure Name!!!!");
        }

        private string GenerateDDL()
        {
            return labelScript.Text.Replace('\n', ' ');
        }

        private void btnDeleteProcedure_Click(object sender, EventArgs e)
        {
            if (cmbSchemasDelete.SelectedItem.ToString() == "")
            {
                MessageBox.Show("Select a schema to delete the procedure");
                return;
            }

            string status = dbHandler.DeleteProcedure(cmbDeleteProcedureName.SelectedItem.ToString(), cmbSchemasDelete.SelectedItem.ToString());

            if (status == "Success")
            {
                MessageBox.Show("Procedure Deleted Correctly");
                LoadTablesToCombobox();
                cmbDeleteProcedureName.Items.Clear();
            }
            else
            {
                MessageBox.Show("Something went wrong while deleting procedure\nError message: " + status);
            }

        }

        private void btnLoadScript_Click(object sender, EventArgs e)
        {
            if (cmbDeleteProcedureName.Items.Count != 0)
            {
                cmbSchemasDelete.Enabled = cmbDeleteProcedureName.Enabled = btnDeleteProcedure.Enabled = false;
                txtAlterScript.Enabled = btnDiscard.Enabled = btnAlterProcedure.Enabled = true;


                string ddl = dbHandler.GetProcedureDDL(cmbDeleteProcedureName.SelectedItem.ToString(), cmbSchemasDelete.SelectedItem.ToString());

                txtAlterScript.Text = ddl;

                txtAlterScript.Enabled = true;
            }

        }

        private void cmbSchemasDelete_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cmb = sender as ComboBox;

            var listProcedures = dbHandler.GetSchemaProcedures(cmb.SelectedItem.ToString());

            cmbDeleteProcedureName.Items.Clear();

            foreach (String str in listProcedures)
                cmbDeleteProcedureName.Items.Add(str);

            if(cmbDeleteProcedureName.Items.Count != 0)
                 cmbDeleteProcedureName.SelectedIndex = 0;
        }

        private void btnDiscard_Click(object sender, EventArgs e)
        {
            cmbSchemasDelete.Enabled = cmbDeleteProcedureName.Enabled = btnDeleteProcedure.Enabled = true;
            txtAlterScript.Enabled = btnDiscard.Enabled = btnAlterProcedure.Enabled = false;
        }

        private void btnAlterProcedure_Click(object sender, EventArgs e)
        {
            string alterString = "ALTER PROCEDURE\"" + cmbSchemasDelete.SelectedItem.ToString() + "\".\"" + cmbDeleteProcedureName.SelectedItem.ToString() + "\"";
            alterString += txtAlterScript.Text;

            string status = dbHandler.AlterFunction(alterString);

            if (status == "Success")
            {
                MessageBox.Show("Procedure altered correctly");
                labelScript.Text = alterString;
                txtAlterScript.Enabled = btnDiscard.Enabled = btnAlterProcedure.Enabled = false;
                cmbSchemasDelete.Enabled = cmbDeleteProcedureName.Enabled = btnDeleteProcedure.Enabled = true;

            }
            else
            {
                MessageBox.Show("Something went wrong when altering procedure\nMessage: " + status);
            }
        }
    }
}



