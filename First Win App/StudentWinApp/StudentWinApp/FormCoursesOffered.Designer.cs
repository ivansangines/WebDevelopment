namespace StudentWinApp
{
    partial class FormCoursesOffered
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
            this.cmbSemesters = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgCoursesOffered = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgCoursesOffered)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbSemesters
            // 
            this.cmbSemesters.FormattingEnabled = true;
            this.cmbSemesters.Location = new System.Drawing.Point(103, 96);
            this.cmbSemesters.Name = "cmbSemesters";
            this.cmbSemesters.Size = new System.Drawing.Size(278, 39);
            this.cmbSemesters.TabIndex = 0;
            this.cmbSemesters.SelectedIndexChanged += new System.EventHandler(this.cmbSemesters_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(161, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Smester";
            // 
            // dgCoursesOffered
            // 
            this.dgCoursesOffered.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCoursesOffered.Location = new System.Drawing.Point(434, 96);
            this.dgCoursesOffered.Name = "dgCoursesOffered";
            this.dgCoursesOffered.RowTemplate.Height = 40;
            this.dgCoursesOffered.Size = new System.Drawing.Size(1759, 567);
            this.dgCoursesOffered.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1183, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(222, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "Courses Offered";
            // 
            // FormCoursesOffered
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2246, 784);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgCoursesOffered);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbSemesters);
            this.Name = "FormCoursesOffered";
            this.Text = "FormCoursesOffered";
            this.Load += new System.EventHandler(this.FormCoursesOffered_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgCoursesOffered)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSemesters;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgCoursesOffered;
        private System.Windows.Forms.Label label2;
    }
}