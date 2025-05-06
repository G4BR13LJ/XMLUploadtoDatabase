namespace Proj1_P2_391
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            InstructorName = new ComboBox();
            InstructorFaculty = new ComboBox();
            InstructorUniversity = new ComboBox();
            StudentGender = new ComboBox();
            StudentMajor = new ComboBox();
            StudentName = new ComboBox();
            CourseUniversity = new ComboBox();
            CourseFaculty = new ComboBox();
            CourseDept = new ComboBox();
            Year = new ComboBox();
            Semester = new ComboBox();
            GenerateButton = new Button();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            ResultsTextBox = new TextBox();
            ResetButton = new Button();
            uploadBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(56, 95);
            label1.Name = "label1";
            label1.Size = new Size(80, 20);
            label1.TabIndex = 0;
            label1.Text = "Instructors:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(59, 197);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 1;
            label2.Text = "Students:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(64, 305);
            label3.Name = "label3";
            label3.Size = new Size(63, 20);
            label3.TabIndex = 2;
            label3.Text = "Courses:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(65, 412);
            label4.Name = "label4";
            label4.Size = new Size(44, 20);
            label4.TabIndex = 3;
            label4.Text = "Date:";
            label4.Click += label4_Click;
            // 
            // InstructorName
            // 
            InstructorName.DropDownStyle = ComboBoxStyle.DropDownList;
            InstructorName.FormattingEnabled = true;
            InstructorName.Location = new Point(151, 91);
            InstructorName.Margin = new Padding(3, 4, 3, 4);
            InstructorName.Name = "InstructorName";
            InstructorName.Size = new Size(165, 28);
            InstructorName.TabIndex = 4;
            // 
            // InstructorFaculty
            // 
            InstructorFaculty.DropDownStyle = ComboBoxStyle.DropDownList;
            InstructorFaculty.FormattingEnabled = true;
            InstructorFaculty.Location = new Point(376, 91);
            InstructorFaculty.Margin = new Padding(3, 4, 3, 4);
            InstructorFaculty.Name = "InstructorFaculty";
            InstructorFaculty.Size = new Size(170, 28);
            InstructorFaculty.TabIndex = 5;
            // 
            // InstructorUniversity
            // 
            InstructorUniversity.DropDownStyle = ComboBoxStyle.DropDownList;
            InstructorUniversity.FormattingEnabled = true;
            InstructorUniversity.Location = new Point(602, 91);
            InstructorUniversity.Margin = new Padding(3, 4, 3, 4);
            InstructorUniversity.Name = "InstructorUniversity";
            InstructorUniversity.Size = new Size(170, 28);
            InstructorUniversity.TabIndex = 6;
            // 
            // StudentGender
            // 
            StudentGender.DropDownStyle = ComboBoxStyle.DropDownList;
            StudentGender.FormattingEnabled = true;
            StudentGender.Location = new Point(602, 197);
            StudentGender.Margin = new Padding(3, 4, 3, 4);
            StudentGender.Name = "StudentGender";
            StudentGender.Size = new Size(170, 28);
            StudentGender.TabIndex = 9;
            // 
            // StudentMajor
            // 
            StudentMajor.DropDownStyle = ComboBoxStyle.DropDownList;
            StudentMajor.FormattingEnabled = true;
            StudentMajor.Location = new Point(376, 197);
            StudentMajor.Margin = new Padding(3, 4, 3, 4);
            StudentMajor.Name = "StudentMajor";
            StudentMajor.Size = new Size(170, 28);
            StudentMajor.TabIndex = 8;
            // 
            // StudentName
            // 
            StudentName.DropDownStyle = ComboBoxStyle.DropDownList;
            StudentName.FormattingEnabled = true;
            StudentName.Location = new Point(151, 197);
            StudentName.Margin = new Padding(3, 4, 3, 4);
            StudentName.Name = "StudentName";
            StudentName.Size = new Size(162, 28);
            StudentName.TabIndex = 7;
            // 
            // CourseUniversity
            // 
            CourseUniversity.DropDownStyle = ComboBoxStyle.DropDownList;
            CourseUniversity.FormattingEnabled = true;
            CourseUniversity.Location = new Point(602, 305);
            CourseUniversity.Margin = new Padding(3, 4, 3, 4);
            CourseUniversity.Name = "CourseUniversity";
            CourseUniversity.Size = new Size(170, 28);
            CourseUniversity.TabIndex = 12;
            // 
            // CourseFaculty
            // 
            CourseFaculty.DropDownStyle = ComboBoxStyle.DropDownList;
            CourseFaculty.FormattingEnabled = true;
            CourseFaculty.Location = new Point(376, 305);
            CourseFaculty.Margin = new Padding(3, 4, 3, 4);
            CourseFaculty.Name = "CourseFaculty";
            CourseFaculty.Size = new Size(170, 28);
            CourseFaculty.TabIndex = 11;
            // 
            // CourseDept
            // 
            CourseDept.DropDownStyle = ComboBoxStyle.DropDownList;
            CourseDept.FormattingEnabled = true;
            CourseDept.Location = new Point(151, 305);
            CourseDept.Margin = new Padding(3, 4, 3, 4);
            CourseDept.Name = "CourseDept";
            CourseDept.Size = new Size(165, 28);
            CourseDept.TabIndex = 10;
            // 
            // Year
            // 
            Year.DropDownStyle = ComboBoxStyle.DropDownList;
            Year.FormattingEnabled = true;
            Year.Location = new Point(376, 412);
            Year.Margin = new Padding(3, 4, 3, 4);
            Year.Name = "Year";
            Year.Size = new Size(170, 28);
            Year.TabIndex = 14;
            // 
            // Semester
            // 
            Semester.DropDownStyle = ComboBoxStyle.DropDownList;
            Semester.FormattingEnabled = true;
            Semester.Location = new Point(151, 412);
            Semester.Margin = new Padding(3, 4, 3, 4);
            Semester.Name = "Semester";
            Semester.Size = new Size(165, 28);
            Semester.TabIndex = 13;
            // 
            // GenerateButton
            // 
            GenerateButton.Location = new Point(151, 474);
            GenerateButton.Margin = new Padding(3, 4, 3, 4);
            GenerateButton.Name = "GenerateButton";
            GenerateButton.Size = new Size(89, 31);
            GenerateButton.TabIndex = 15;
            GenerateButton.Text = "Generate";
            GenerateButton.UseVisualStyleBackColor = true;
            GenerateButton.Click += GenerateButton_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(246, 479);
            label5.Name = "label5";
            label5.Size = new Size(52, 20);
            label5.TabIndex = 16;
            label5.Text = "Result:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(151, 67);
            label6.Name = "label6";
            label6.Size = new Size(115, 20);
            label6.TabIndex = 18;
            label6.Text = "Instructor Name";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(376, 67);
            label7.Name = "label7";
            label7.Size = new Size(54, 20);
            label7.TabIndex = 19;
            label7.Text = "Faculty";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(602, 67);
            label8.Name = "label8";
            label8.Size = new Size(73, 20);
            label8.TabIndex = 20;
            label8.Text = "University";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(151, 173);
            label9.Name = "label9";
            label9.Size = new Size(104, 20);
            label9.TabIndex = 21;
            label9.Text = "Student Name";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(376, 173);
            label10.Name = "label10";
            label10.Size = new Size(48, 20);
            label10.TabIndex = 22;
            label10.Text = "Major";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(602, 173);
            label11.Name = "label11";
            label11.Size = new Size(57, 20);
            label11.TabIndex = 23;
            label11.Text = "Gender";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(151, 281);
            label12.Name = "label12";
            label12.Size = new Size(89, 20);
            label12.TabIndex = 24;
            label12.Text = "Department";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(376, 281);
            label13.Name = "label13";
            label13.Size = new Size(54, 20);
            label13.TabIndex = 25;
            label13.Text = "Faculty";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(602, 281);
            label14.Name = "label14";
            label14.Size = new Size(73, 20);
            label14.TabIndex = 26;
            label14.Text = "University";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(151, 388);
            label15.Name = "label15";
            label15.Size = new Size(70, 20);
            label15.TabIndex = 27;
            label15.Text = "Semester";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(376, 388);
            label16.Name = "label16";
            label16.Size = new Size(37, 20);
            label16.TabIndex = 28;
            label16.Text = "Year";
            // 
            // ResultsTextBox
            // 
            ResultsTextBox.Location = new Point(304, 476);
            ResultsTextBox.Margin = new Padding(3, 4, 3, 4);
            ResultsTextBox.Name = "ResultsTextBox";
            ResultsTextBox.ReadOnly = true;
            ResultsTextBox.Size = new Size(51, 27);
            ResultsTextBox.TabIndex = 17;
            // 
            // ResetButton
            // 
            ResetButton.Location = new Point(151, 508);
            ResetButton.Margin = new Padding(3, 4, 3, 4);
            ResetButton.Name = "ResetButton";
            ResetButton.Size = new Size(89, 31);
            ResetButton.TabIndex = 29;
            ResetButton.Text = "Reset";
            ResetButton.UseVisualStyleBackColor = true;
            ResetButton.Click += ResetButton_Click;
            // 
            // uploadBtn
            // 
            uploadBtn.Location = new Point(602, 412);
            uploadBtn.Name = "uploadBtn";
            uploadBtn.Size = new Size(173, 100);
            uploadBtn.TabIndex = 30;
            uploadBtn.Text = "Upload an XML";
            uploadBtn.UseVisualStyleBackColor = true;
            uploadBtn.Click += uploadBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(uploadBtn);
            Controls.Add(ResetButton);
            Controls.Add(label16);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(ResultsTextBox);
            Controls.Add(label5);
            Controls.Add(GenerateButton);
            Controls.Add(Year);
            Controls.Add(Semester);
            Controls.Add(CourseUniversity);
            Controls.Add(CourseFaculty);
            Controls.Add(CourseDept);
            Controls.Add(StudentGender);
            Controls.Add(StudentMajor);
            Controls.Add(StudentName);
            Controls.Add(InstructorUniversity);
            Controls.Add(InstructorFaculty);
            Controls.Add(InstructorName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox InstructorName;
        private ComboBox InstructorFaculty;
        private ComboBox InstructorUniversity;
        private ComboBox StudentGender;
        private ComboBox StudentMajor;
        private ComboBox StudentName;
        private ComboBox CourseUniversity;
        private ComboBox CourseFaculty;
        private ComboBox CourseDept;
        private ComboBox Year;
        private ComboBox Semester;
        private Button GenerateButton;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private TextBox ResultsTextBox;
        private Button ResetButton;
        private Button uploadBtn;
    }
}
