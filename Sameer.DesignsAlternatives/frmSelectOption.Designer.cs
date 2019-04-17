namespace Sameer.DesignsAlternatives
{
    partial class frmSelectOption
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
            this.designOptionDataGridView = new System.Windows.Forms.DataGridView();
            this.btnOk = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.designOptionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.designOptionDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.designOptionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // designOptionDataGridView
            // 
            this.designOptionDataGridView.AllowUserToAddRows = false;
            this.designOptionDataGridView.AllowUserToDeleteRows = false;
            this.designOptionDataGridView.AutoGenerateColumns = false;
            this.designOptionDataGridView.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.designOptionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.designOptionDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3});
            this.designOptionDataGridView.DataSource = this.designOptionBindingSource;
            this.designOptionDataGridView.Location = new System.Drawing.Point(25, 31);
            this.designOptionDataGridView.Name = "designOptionDataGridView";
            this.designOptionDataGridView.ReadOnly = true;
            this.designOptionDataGridView.RowHeadersVisible = false;
            this.designOptionDataGridView.Size = new System.Drawing.Size(258, 235);
            this.designOptionDataGridView.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.Image = global::Sameer.DesignsAlternatives.Properties.Resources.Ok_64_2;
            this.btnOk.Location = new System.Drawing.Point(249, 315);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(108, 91);
            this.btnOk.TabIndex = 0;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(302, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(305, 235);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn3.HeaderText = "Options";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // designOptionBindingSource
            // 
            this.designOptionBindingSource.DataSource = typeof(Sameer.DesignsAlternatives.Models.DesignOption);
            this.designOptionBindingSource.CurrentChanged += new System.EventHandler(this.designOptionBindingSource_CurrentChanged);
            // 
            // frmSelectOption
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 459);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.designOptionDataGridView);
            this.Controls.Add(this.btnOk);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmSelectOption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Design Option";
            this.Load += new System.EventHandler(this.frmSelectOption_Load);
            ((System.ComponentModel.ISupportInitialize)(this.designOptionDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.designOptionBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource designOptionBindingSource;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.DataGridView designOptionDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}