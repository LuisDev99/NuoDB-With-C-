namespace SqlDeveloperProject
{
    partial class Functions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbDataTypeReturn = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbSchemasCreate = new System.Windows.Forms.ComboBox();
            this.txtFunctionName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelScript = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmbDeleteFunctionName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSchemasDelete = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtParameterName = new System.Windows.Forms.TextBox();
            this.cmbDataTypeParameter = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnAddParameter = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSQL = new System.Windows.Forms.RichTextBox();
            this.btnCreateFunction = new System.Windows.Forms.Button();
            this.btnDeleteFunction = new System.Windows.Forms.Button();
            this.btnLoadScript = new System.Windows.Forms.Button();
            this.txtAlterScript = new System.Windows.Forms.RichTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnDiscard = new System.Windows.Forms.Button();
            this.btnAlterFunction = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.btnCreateFunction);
            this.panel1.Controls.Add(this.txtSQL);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.btnAddParameter);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.cmbDataTypeParameter);
            this.panel1.Controls.Add(this.txtParameterName);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cmbDataTypeReturn);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cmbSchemasCreate);
            this.panel1.Controls.Add(this.txtFunctionName);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(49, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(296, 452);
            this.panel1.TabIndex = 0;
            // 
            // cmbDataTypeReturn
            // 
            this.cmbDataTypeReturn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDataTypeReturn.FormattingEnabled = true;
            this.cmbDataTypeReturn.Items.AddRange(new object[] {
            "string",
            "integer"});
            this.cmbDataTypeReturn.Location = new System.Drawing.Point(110, 83);
            this.cmbDataTypeReturn.Name = "cmbDataTypeReturn";
            this.cmbDataTypeReturn.Size = new System.Drawing.Size(121, 21);
            this.cmbDataTypeReturn.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Return Type:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(47, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Schema:";
            // 
            // cmbSchemasCreate
            // 
            this.cmbSchemasCreate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSchemasCreate.FormattingEnabled = true;
            this.cmbSchemasCreate.Location = new System.Drawing.Point(110, 16);
            this.cmbSchemasCreate.Name = "cmbSchemasCreate";
            this.cmbSchemasCreate.Size = new System.Drawing.Size(121, 21);
            this.cmbSchemasCreate.TabIndex = 25;
            // 
            // txtFunctionName
            // 
            this.txtFunctionName.Location = new System.Drawing.Point(110, 47);
            this.txtFunctionName.Name = "txtFunctionName";
            this.txtFunctionName.Size = new System.Drawing.Size(100, 20);
            this.txtFunctionName.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Function Name:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.labelScript);
            this.panel2.Location = new System.Drawing.Point(351, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(515, 452);
            this.panel2.TabIndex = 1;
            // 
            // labelScript
            // 
            this.labelScript.AutoSize = true;
            this.labelScript.Location = new System.Drawing.Point(23, 16);
            this.labelScript.Name = "labelScript";
            this.labelScript.Size = new System.Drawing.Size(35, 13);
            this.labelScript.TabIndex = 0;
            this.labelScript.Text = "label4";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.btnAlterFunction);
            this.panel3.Controls.Add(this.btnDiscard);
            this.panel3.Controls.Add(this.txtAlterScript);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.btnLoadScript);
            this.panel3.Controls.Add(this.btnDeleteFunction);
            this.panel3.Controls.Add(this.cmbDeleteFunctionName);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.cmbSchemasDelete);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(872, 33);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(283, 452);
            this.panel3.TabIndex = 2;
            // 
            // cmbDeleteFunctionName
            // 
            this.cmbDeleteFunctionName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeleteFunctionName.FormattingEnabled = true;
            this.cmbDeleteFunctionName.Location = new System.Drawing.Point(128, 47);
            this.cmbDeleteFunctionName.Name = "cmbDeleteFunctionName";
            this.cmbDeleteFunctionName.Size = new System.Drawing.Size(121, 21);
            this.cmbDeleteFunctionName.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Schema:";
            // 
            // cmbSchemasDelete
            // 
            this.cmbSchemasDelete.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSchemasDelete.FormattingEnabled = true;
            this.cmbSchemasDelete.Location = new System.Drawing.Point(128, 19);
            this.cmbSchemasDelete.Name = "cmbSchemasDelete";
            this.cmbSchemasDelete.Size = new System.Drawing.Size(121, 21);
            this.cmbSchemasDelete.TabIndex = 31;
            this.cmbSchemasDelete.SelectedIndexChanged += new System.EventHandler(this.cmbSchemasDelete_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Function Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(148, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Create";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(576, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Script";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(979, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Delete";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(84, 107);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 25);
            this.label9.TabIndex = 6;
            this.label9.Text = "Parameters";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(58, 152);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "Name:";
            // 
            // txtParameterName
            // 
            this.txtParameterName.Location = new System.Drawing.Point(110, 152);
            this.txtParameterName.Name = "txtParameterName";
            this.txtParameterName.Size = new System.Drawing.Size(100, 20);
            this.txtParameterName.TabIndex = 30;
            // 
            // cmbDataTypeParameter
            // 
            this.cmbDataTypeParameter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDataTypeParameter.FormattingEnabled = true;
            this.cmbDataTypeParameter.Items.AddRange(new object[] {
            "string",
            "integer"});
            this.cmbDataTypeParameter.Location = new System.Drawing.Point(110, 192);
            this.cmbDataTypeParameter.Name = "cmbDataTypeParameter";
            this.cmbDataTypeParameter.Size = new System.Drawing.Size(121, 21);
            this.cmbDataTypeParameter.TabIndex = 31;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(58, 195);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 13);
            this.label11.TabIndex = 32;
            this.label11.Text = "Type:";
            // 
            // btnAddParameter
            // 
            this.btnAddParameter.Location = new System.Drawing.Point(89, 233);
            this.btnAddParameter.Name = "btnAddParameter";
            this.btnAddParameter.Size = new System.Drawing.Size(127, 23);
            this.btnAddParameter.TabIndex = 33;
            this.btnAddParameter.Text = "Add Parameter";
            this.btnAddParameter.UseVisualStyleBackColor = true;
            this.btnAddParameter.Click += new System.EventHandler(this.btnAddParameter_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(114, 268);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 25);
            this.label12.TabIndex = 34;
            this.label12.Text = "SQL";
            // 
            // txtSQL
            // 
            this.txtSQL.Location = new System.Drawing.Point(30, 296);
            this.txtSQL.Name = "txtSQL";
            this.txtSQL.Size = new System.Drawing.Size(250, 96);
            this.txtSQL.TabIndex = 36;
            this.txtSQL.Text = "";
            // 
            // btnCreateFunction
            // 
            this.btnCreateFunction.Location = new System.Drawing.Point(89, 410);
            this.btnCreateFunction.Name = "btnCreateFunction";
            this.btnCreateFunction.Size = new System.Drawing.Size(106, 23);
            this.btnCreateFunction.TabIndex = 37;
            this.btnCreateFunction.Text = "Create Function";
            this.btnCreateFunction.UseVisualStyleBackColor = true;
            this.btnCreateFunction.Click += new System.EventHandler(this.btnCreateFunction_Click);
            // 
            // btnDeleteFunction
            // 
            this.btnDeleteFunction.Location = new System.Drawing.Point(35, 107);
            this.btnDeleteFunction.Name = "btnDeleteFunction";
            this.btnDeleteFunction.Size = new System.Drawing.Size(102, 23);
            this.btnDeleteFunction.TabIndex = 34;
            this.btnDeleteFunction.Text = "Delete Function";
            this.btnDeleteFunction.UseVisualStyleBackColor = true;
            this.btnDeleteFunction.Click += new System.EventHandler(this.btnDeleteFunction_Click);
            // 
            // btnLoadScript
            // 
            this.btnLoadScript.Location = new System.Drawing.Point(158, 107);
            this.btnLoadScript.Name = "btnLoadScript";
            this.btnLoadScript.Size = new System.Drawing.Size(91, 23);
            this.btnLoadScript.TabIndex = 35;
            this.btnLoadScript.Text = "Load Script";
            this.btnLoadScript.UseVisualStyleBackColor = true;
            this.btnLoadScript.Click += new System.EventHandler(this.btnLoadScript_Click);
            // 
            // txtAlterScript
            // 
            this.txtAlterScript.Enabled = false;
            this.txtAlterScript.Location = new System.Drawing.Point(15, 192);
            this.txtAlterScript.Name = "txtAlterScript";
            this.txtAlterScript.Size = new System.Drawing.Size(250, 96);
            this.txtAlterScript.TabIndex = 39;
            this.txtAlterScript.Text = "";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(99, 164);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 25);
            this.label13.TabIndex = 38;
            this.label13.Text = "SQL";
            // 
            // btnDiscard
            // 
            this.btnDiscard.Enabled = false;
            this.btnDiscard.Location = new System.Drawing.Point(49, 318);
            this.btnDiscard.Name = "btnDiscard";
            this.btnDiscard.Size = new System.Drawing.Size(75, 23);
            this.btnDiscard.TabIndex = 40;
            this.btnDiscard.Text = "Discard";
            this.btnDiscard.UseVisualStyleBackColor = true;
            this.btnDiscard.Click += new System.EventHandler(this.btnDiscard_Click);
            // 
            // btnAlterFunction
            // 
            this.btnAlterFunction.Enabled = false;
            this.btnAlterFunction.Location = new System.Drawing.Point(153, 318);
            this.btnAlterFunction.Name = "btnAlterFunction";
            this.btnAlterFunction.Size = new System.Drawing.Size(75, 23);
            this.btnAlterFunction.TabIndex = 41;
            this.btnAlterFunction.Text = "ALTER";
            this.btnAlterFunction.UseVisualStyleBackColor = true;
            this.btnAlterFunction.Click += new System.EventHandler(this.btnAlterFunction_Click);
            // 
            // Functions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1167, 497);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Functions";
            this.Text = "Functions";
            this.Load += new System.EventHandler(this.Functions_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelScript;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbSchemasCreate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbDataTypeReturn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFunctionName;
        private System.Windows.Forms.ComboBox cmbDeleteFunctionName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbSchemasDelete;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCreateFunction;
        private System.Windows.Forms.RichTextBox txtSQL;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnAddParameter;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbDataTypeParameter;
        private System.Windows.Forms.TextBox txtParameterName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnDeleteFunction;
        private System.Windows.Forms.Button btnAlterFunction;
        private System.Windows.Forms.Button btnDiscard;
        private System.Windows.Forms.RichTextBox txtAlterScript;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnLoadScript;
    }
}