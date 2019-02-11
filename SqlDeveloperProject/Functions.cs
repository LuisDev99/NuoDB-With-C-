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
    public partial class Functions : Form
    {

        DatabaseHandler dbHandler;
        List<String> parametersName;
        List<String> parametersType;

        public Functions()
        {
            InitializeComponent();
        }

        private void Functions_Load(object sender, EventArgs e)
        {
            dbHandler = new DatabaseHandler();

            parametersName = new List<string>();
            parametersType = new List<string>();
            cmbDataTypeParameter.SelectedIndex = cmbDataTypeReturn.SelectedIndex = 0;

            LoadTablesToCombobox();
        }


        private void LoadTablesToCombobox()
        {
            cmbSchemasCreate.Items.Clear();
            cmbSchemasDelete.Items.Clear();
            cmbDeleteFunctionName.Items.Clear();

            var listFunction = dbHandler.GetSchemaFunctions(DatabaseHandler.currentSchema);
            var listSchemas = dbHandler.GetConnectionSchemas("");

            foreach (String str in listFunction)
                cmbDeleteFunctionName.Items.Add(str);

            foreach (String str in listSchemas)
            {
                if(str != "SYSTEM")
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
                FUNCTION "MANGO".hola (parm STRING) RETURNS STRING SECURITY INVOKER
                AS
                THROW 'Not implemented yet!';
                END_FUNCTION;
                %%%
                @delimiter ;
                %%%*/

            labelScript.Text = "CREATE \n FUNCTION \"" + cmbSchemasCreate.SelectedItem.ToString() + "\"." + RemoveWhiteSpaceFromString(txtFunctionName.Text) + "(";

            /* Add Parenthesis and the parameters to the string */
            for (int i = 0; i < parametersName.Count; i++)
            {

                labelScript.Text += parametersName[i].ToString() + " " + parametersType[i].ToString();

                if (parametersName.Count != i + 1)
                {
                    labelScript.Text += ", ";
                }
            }

            labelScript.Text += ") \n RETURNS " + cmbDataTypeReturn.SelectedItem.ToString() + " SECURITY INVOKER\nAS\n var str = (" + txtSQL.Text + ");";

            labelScript.Text += "\n return str; \n END_FUNCTION;";

        }

        private void btnCreateFunction_Click(object sender, EventArgs e)
        {
            UpdateLabelScript();

            if (txtFunctionName.Text != "")
            {

                if(parametersName.Count != 0)
                {

                    if (txtSQL.Text != "")
                    {
                        string generatedDDL = GenerateDDL();

                        string state = dbHandler.CreateFunction(generatedDDL);

                        if (state == "Success")
                            MessageBox.Show("Function created succesfully!");
                        else
                            MessageBox.Show("Error while creating function\n Error Message: " + state);
                    } else
                    {
                        MessageBox.Show("Enter the sql command!!");
                    }

                } else
                {
                    MessageBox.Show("Add at least one parameter to create the function!!!");
                }


            }
            else
                MessageBox.Show("Write the function Name!!!!");


        }

        private string GenerateDDL()
        {
            return labelScript.Text.Replace('\n', ' ');
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

        private void btnDeleteFunction_Click(object sender, EventArgs e)
        {

            if (cmbSchemasDelete.SelectedItem.ToString() == "")
            {
                MessageBox.Show("Select a schema to delete the function");
                return;
            }

            string status = dbHandler.DeleteFunction(cmbDeleteFunctionName.SelectedItem.ToString(), cmbSchemasDelete.SelectedItem.ToString());

            if (status == "Success")
            {
                MessageBox.Show("Function Deleted Correctly");
                LoadTablesToCombobox();
                cmbDeleteFunctionName.Items.Clear();
            }
            else
            {
                MessageBox.Show("Something went wrong while deleting function\nError message: " + status);
            }
            
        }

        private void cmbSchemasDelete_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cmb = sender as ComboBox;

            var listTables = dbHandler.GetSchemaFunctions(cmb.SelectedItem.ToString());

            cmbDeleteFunctionName.Items.Clear();

            foreach (String str in listTables)
                cmbDeleteFunctionName.Items.Add(str);

            cmbDeleteFunctionName.SelectedIndex = 0;




        }

        private void btnLoadScript_Click(object sender, EventArgs e)
        {

            cmbSchemasDelete.Enabled = cmbDeleteFunctionName.Enabled = btnDeleteFunction.Enabled = false;
            txtAlterScript.Enabled = btnDiscard.Enabled = btnAlterFunction.Enabled = true;

            string ddl = dbHandler.GetFunctionDDL(cmbDeleteFunctionName.SelectedItem.ToString(), cmbSchemasDelete.SelectedItem.ToString());

            txtAlterScript.Text = ddl;

            txtAlterScript.Enabled = true;

            
        }

        private void btnDiscard_Click(object sender, EventArgs e)
        {
            cmbSchemasDelete.Enabled = cmbDeleteFunctionName.Enabled = btnDeleteFunction.Enabled = true;
            txtAlterScript.Enabled = btnDiscard.Enabled = btnAlterFunction.Enabled = false;

        }

        private void btnAlterFunction_Click(object sender, EventArgs e)
        {
            string alterString = "ALTER FUNCTION\"" + cmbSchemasDelete.SelectedItem.ToString() + "\".\"" + cmbDeleteFunctionName.SelectedItem.ToString() + "\"";
            alterString += txtAlterScript.Text;

            string status = dbHandler.AlterFunction(alterString);

            if(status == "Success")
            {
                MessageBox.Show("Function altered correctly");
                labelScript.Text = alterString;
                txtAlterScript.Enabled = btnDiscard.Enabled = btnAlterFunction.Enabled = false;
                cmbSchemasDelete.Enabled = cmbDeleteFunctionName.Enabled = btnDeleteFunction.Enabled = true;

            }
            else
            {
                MessageBox.Show("Something went wrong when altering function\nMessage: " + status);
            }

        }
    }
}
