namespace Sameer.DesignsAlternatives
{
    partial class frmSettings
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
            this.components = new System.ComponentModel.Container();
            this.categoryDataGridView = new System.Windows.Forms.DataGridView();
            this.subCategoriesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.subCategoriesDataGridView = new System.Windows.Forms.DataGridView();
            this.designOptionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.designOptionsDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.categoryDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subCategoriesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subCategoriesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.designOptionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.designOptionsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // categoryDataGridView
            // 
            this.categoryDataGridView.AllowUserToAddRows = false;
            this.categoryDataGridView.AllowUserToDeleteRows = false;
            this.categoryDataGridView.AutoGenerateColumns = false;
            this.categoryDataGridView.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.categoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.categoryDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3});
            this.categoryDataGridView.DataSource = this.categoryBindingSource;
            this.categoryDataGridView.Location = new System.Drawing.Point(12, 20);
            this.categoryDataGridView.Name = "categoryDataGridView";
            this.categoryDataGridView.ReadOnly = true;
            this.categoryDataGridView.RowHeadersVisible = false;
            this.categoryDataGridView.Size = new System.Drawing.Size(300, 261);
            this.categoryDataGridView.TabIndex = 0;
            this.categoryDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.categoryDataGridView_CellContentClick);
            // 
            // subCategoriesBindingSource
            // 
            this.subCategoriesBindingSource.DataMember = "SubCategories";
            this.subCategoriesBindingSource.DataSource = this.categoryBindingSource;
            // 
            // subCategoriesDataGridView
            // 
            this.subCategoriesDataGridView.AllowUserToAddRows = false;
            this.subCategoriesDataGridView.AllowUserToDeleteRows = false;
            this.subCategoriesDataGridView.AutoGenerateColumns = false;
            this.subCategoriesDataGridView.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.subCategoriesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.subCategoriesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4});
            this.subCategoriesDataGridView.DataSource = this.subCategoriesBindingSource;
            this.subCategoriesDataGridView.GridColor = System.Drawing.Color.AliceBlue;
            this.subCategoriesDataGridView.Location = new System.Drawing.Point(325, 20);
            this.subCategoriesDataGridView.Name = "subCategoriesDataGridView";
            this.subCategoriesDataGridView.ReadOnly = true;
            this.subCategoriesDataGridView.RowHeadersVisible = false;
            this.subCategoriesDataGridView.Size = new System.Drawing.Size(300, 261);
            this.subCategoriesDataGridView.TabIndex = 1;
            // 
            // designOptionsBindingSource
            // 
            this.designOptionsBindingSource.DataMember = "designOptions";
            this.designOptionsBindingSource.DataSource = this.subCategoriesBindingSource;
            // 
            // designOptionsDataGridView
            // 
            this.designOptionsDataGridView.AllowUserToAddRows = false;
            this.designOptionsDataGridView.AllowUserToDeleteRows = false;
            this.designOptionsDataGridView.AutoGenerateColumns = false;
            this.designOptionsDataGridView.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.designOptionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.designOptionsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5});
            this.designOptionsDataGridView.DataSource = this.designOptionsBindingSource;
            this.designOptionsDataGridView.Location = new System.Drawing.Point(638, 20);
            this.designOptionsDataGridView.Name = "designOptionsDataGridView";
            this.designOptionsDataGridView.ReadOnly = true;
            this.designOptionsDataGridView.RowHeadersVisible = false;
            this.designOptionsDataGridView.Size = new System.Drawing.Size(300, 261);
            this.designOptionsDataGridView.TabIndex = 2;
            this.designOptionsDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.designOptionsDataGridView_CellContentClick);
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn5.HeaderText = "Design Option";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // categoryBindingSource
            // 
            this.categoryBindingSource.DataSource = typeof(Sameer.DesignsAlternatives.Models.Category);
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn4.HeaderText = "Sub-Category";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn3.HeaderText = "Category";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 678);
            this.Controls.Add(this.designOptionsDataGridView);
            this.Controls.Add(this.subCategoriesDataGridView);
            this.Controls.Add(this.categoryDataGridView);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Values Setting";
            ((System.ComponentModel.ISupportInitialize)(this.categoryDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subCategoriesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subCategoriesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.designOptionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.designOptionsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource categoryBindingSource;
        private System.Windows.Forms.DataGridView categoryDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.BindingSource subCategoriesBindingSource;
        private System.Windows.Forms.DataGridView subCategoriesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.BindingSource designOptionsBindingSource;
        private System.Windows.Forms.DataGridView designOptionsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    }
}