namespace lab1
{
    partial class MainPage
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
            this.dataGridViewCherestea = new System.Windows.Forms.DataGridView();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.dataGridViewSpecii = new System.Windows.Forms.DataGridView();
            this.labelCherestea = new System.Windows.Forms.Label();
            this.labelSpecii = new System.Windows.Forms.Label();
            this.textBoxSpeciiName = new System.Windows.Forms.TextBox();
            this.labelSpeciiName = new System.Windows.Forms.Label();
            this.labelGen = new System.Windows.Forms.Label();
            this.textBoxGen = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCherestea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSpecii)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCherestea
            // 
            this.dataGridViewCherestea.AllowUserToAddRows = false;
            this.dataGridViewCherestea.AllowUserToDeleteRows = false;
            this.dataGridViewCherestea.AllowUserToResizeColumns = false;
            this.dataGridViewCherestea.AllowUserToResizeRows = false;
            this.dataGridViewCherestea.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewCherestea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCherestea.Location = new System.Drawing.Point(67, 62);
            this.dataGridViewCherestea.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewCherestea.MultiSelect = false;
            this.dataGridViewCherestea.Name = "dataGridViewCherestea";
            this.dataGridViewCherestea.ReadOnly = true;
            this.dataGridViewCherestea.RowHeadersWidth = 51;
            this.dataGridViewCherestea.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCherestea.Size = new System.Drawing.Size(591, 316);
            this.dataGridViewCherestea.StandardTab = true;
            this.dataGridViewCherestea.TabIndex = 0;
            this.dataGridViewCherestea.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCherestea_CellClick);
            this.dataGridViewCherestea.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCherestea_CellContentClick);
            this.dataGridViewCherestea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewCherestea_KeyDown);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(740, 426);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(183, 46);
            this.buttonAdd.TabIndex = 4;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(944, 426);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(183, 46);
            this.buttonDelete.TabIndex = 5;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(1148, 426);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(183, 46);
            this.buttonUpdate.TabIndex = 6;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // dataGridViewSpecii
            // 
            this.dataGridViewSpecii.AllowUserToAddRows = false;
            this.dataGridViewSpecii.AllowUserToDeleteRows = false;
            this.dataGridViewSpecii.AllowUserToResizeColumns = false;
            this.dataGridViewSpecii.AllowUserToResizeRows = false;
            this.dataGridViewSpecii.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewSpecii.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSpecii.Location = new System.Drawing.Point(740, 62);
            this.dataGridViewSpecii.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewSpecii.MultiSelect = false;
            this.dataGridViewSpecii.Name = "dataGridViewSpecii";
            this.dataGridViewSpecii.ReadOnly = true;
            this.dataGridViewSpecii.RowHeadersWidth = 51;
            this.dataGridViewSpecii.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSpecii.Size = new System.Drawing.Size(591, 316);
            this.dataGridViewSpecii.StandardTab = true;
            this.dataGridViewSpecii.TabIndex = 1;
            this.dataGridViewSpecii.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSpecii_CellContentClick);
            // 
            // labelCherestea
            // 
            this.labelCherestea.AutoSize = true;
            this.labelCherestea.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.labelCherestea.Location = new System.Drawing.Point(64, 37);
            this.labelCherestea.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCherestea.Name = "labelCherestea";
            this.labelCherestea.Size = new System.Drawing.Size(65, 22);
            this.labelCherestea.TabIndex = 7;
            this.labelCherestea.Text = "Cherestea";
            this.labelCherestea.Click += new System.EventHandler(this.labelCherestea_Click);
            // 
            // labelSpecii
            // 
            this.labelSpecii.AutoSize = true;
            this.labelSpecii.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.labelSpecii.Location = new System.Drawing.Point(736, 37);
            this.labelSpecii.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSpecii.Name = "labelSpecii";
            this.labelSpecii.Size = new System.Drawing.Size(75, 22);
            this.labelSpecii.TabIndex = 6;
            this.labelSpecii.Text = "Specii";
            // 
            // textBoxSpeciiName
            // 
            this.textBoxSpeciiName.Location = new System.Drawing.Point(179, 415);
            this.textBoxSpeciiName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxSpeciiName.Name = "textBoxSpeciiName";
            this.textBoxSpeciiName.Size = new System.Drawing.Size(479, 22);
            this.textBoxSpeciiName.TabIndex = 2;
            this.textBoxSpeciiName.TextChanged += new System.EventHandler(this.textBoxSpeciiName_TextChanged);
            // 
            // labelSpeciiName
            // 
            this.labelSpeciiName.AutoSize = true;
            this.labelSpeciiName.Location = new System.Drawing.Point(64, 418);
            this.labelSpeciiName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSpeciiName.Name = "labelSpeciiName";
            this.labelSpeciiName.Size = new System.Drawing.Size(98, 16);
            this.labelSpeciiName.TabIndex = 5;
            this.labelSpeciiName.Text = "Denumire Specii: ";
            // 
            // labelGen
            // 
            this.labelGen.AutoSize = true;
            this.labelGen.Location = new System.Drawing.Point(64, 455);
            this.labelGen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGen.Name = "labelGen";
            this.labelGen.Size = new System.Drawing.Size(104, 16);
            this.labelGen.TabIndex = 4;
            this.labelGen.Text = "Gen Specie: ";
            // 
            // textBoxGen
            // 
            this.textBoxGen.Location = new System.Drawing.Point(179, 452);
            this.textBoxGen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxGen.Name = "textBoxGen";
            this.textBoxGen.Size = new System.Drawing.Size(479, 22);
            this.textBoxGen.TabIndex = 3;
            this.textBoxGen.TextChanged += new System.EventHandler(this.textBoxGen_TextChanged);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1409, 554);
            this.Controls.Add(this.textBoxGen);
            this.Controls.Add(this.labelGen);
            this.Controls.Add(this.labelSpeciiName);
            this.Controls.Add(this.textBoxSpeciiName);
            this.Controls.Add(this.labelSpecii);
            this.Controls.Add(this.labelCherestea);
            this.Controls.Add(this.dataGridViewSpecii);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.dataGridViewCherestea);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainPage";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCherestea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSpecii)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewCherestea;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.DataGridView dataGridViewSpecii;
        private System.Windows.Forms.Label labelCherestea;
        private System.Windows.Forms.Label labelSpecii;
        private System.Windows.Forms.TextBox textBoxSpeciiName;
        private System.Windows.Forms.Label labelSpeciiName;
        private System.Windows.Forms.Label labelGen;
        private System.Windows.Forms.TextBox textBoxGen;
    }
}