namespace StudentWinApp
{
    partial class FormRegisterForCourse
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
            this.cmbCoursesOffered = new System.Windows.Forms.ComboBox();
            this.txtStudentId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRegisterForCourse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbSemesters
            // 
            this.cmbSemesters.FormattingEnabled = true;
            this.cmbSemesters.Location = new System.Drawing.Point(493, 105);
            this.cmbSemesters.Name = "cmbSemesters";
            this.cmbSemesters.Size = new System.Drawing.Size(276, 39);
            this.cmbSemesters.TabIndex = 0;
            this.cmbSemesters.SelectedIndexChanged += new System.EventHandler(this.cmbSemesters_SelectedIndexChanged);
            // 
            // cmbCoursesOffered
            // 
            this.cmbCoursesOffered.FormattingEnabled = true;
            this.cmbCoursesOffered.Location = new System.Drawing.Point(493, 205);
            this.cmbCoursesOffered.Name = "cmbCoursesOffered";
            this.cmbCoursesOffered.Size = new System.Drawing.Size(276, 39);
            this.cmbCoursesOffered.TabIndex = 1;
            // 
            // txtStudentId
            // 
            this.txtStudentId.Location = new System.Drawing.Point(493, 313);
            this.txtStudentId.Name = "txtStudentId";
            this.txtStudentId.Size = new System.Drawing.Size(276, 38);
            this.txtStudentId.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(279, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Semester";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "Course Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(279, 319);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 32);
            this.label3.TabIndex = 5;
            this.label3.Text = "Student ID";
            // 
            // btnRegisterForCourse
            // 
            this.btnRegisterForCourse.Location = new System.Drawing.Point(493, 412);
            this.btnRegisterForCourse.Name = "btnRegisterForCourse";
            this.btnRegisterForCourse.Size = new System.Drawing.Size(276, 49);
            this.btnRegisterForCourse.TabIndex = 6;
            this.btnRegisterForCourse.Text = "Register Student";
            this.btnRegisterForCourse.UseVisualStyleBackColor = true;
            this.btnRegisterForCourse.Click += new System.EventHandler(this.btnRegisterForCourse_Click);
            // 
            // FormRegisterForCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 647);
            this.Controls.Add(this.btnRegisterForCourse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtStudentId);
            this.Controls.Add(this.cmbCoursesOffered);
            this.Controls.Add(this.cmbSemesters);
            this.Name = "FormRegisterForCourse";
            this.Text = "FormRegisterForCourse";
            this.Load += new System.EventHandler(this.FormRegisterForCourse_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSemesters;
        private System.Windows.Forms.ComboBox cmbCoursesOffered;
        private System.Windows.Forms.TextBox txtStudentId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRegisterForCourse;
    }
}