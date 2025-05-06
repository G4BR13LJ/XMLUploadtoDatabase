using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.XPath;

namespace Proj1_P2_391
{
    public partial class Form1 : Form
    {
        public SqlConnection myConnection;
        public SqlCommand myCommand;
        public SqlDataReader myReader;
        private string connectionString;
        public string tableName;

        public Form1()
        {
            InitializeComponent();
            //String connectionString = "Server = localhost; Database = Project_1_pt2_391; Trusted_Connection = yes; ";
            connectionString = "Server = DESKTOP-S3E6JLP\\MSSQLSERVER01; Database = Project_1_pt2_391; Trusted_Connection = yes; ";
            myConnection = new SqlConnection(connectionString);

            try
            {
                myConnection.Open();
                myCommand = new SqlCommand();
                myCommand.Connection = myConnection;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error");
                this.Close();
            }

            //populate dropdow menus
            myCommand.CommandText = "select DISTINCT Instructor from Instructors";
            myReader = myCommand.ExecuteReader();
            if (myReader.HasRows)
            {
                while (myReader.Read())
                {
                    InstructorName.Items.Add(myReader["Instructor"].ToString());
                }
            }
            myReader.Close();

            myCommand.CommandText = "select DISTINCT Faculty from Instructors";
            myReader = myCommand.ExecuteReader();
            if (myReader.HasRows)
            {
                while (myReader.Read())
                {
                    InstructorFaculty.Items.Add(myReader["Faculty"].ToString());
                }
            }
            myReader.Close();

            myCommand.CommandText = "select DISTINCT University from Instructors";
            myReader = myCommand.ExecuteReader();
            if (myReader.HasRows)
            {
                while (myReader.Read())
                {
                    InstructorUniversity.Items.Add(myReader["University"].ToString());
                }
            }
            myReader.Close();

            myCommand.CommandText = "select DISTINCT Student from Students";
            myReader = myCommand.ExecuteReader();
            if (myReader.HasRows)
            {
                while (myReader.Read())
                {
                    StudentName.Items.Add(myReader["Student"].ToString());
                }
            }
            myReader.Close();

            myCommand.CommandText = "select DISTINCT Major from Students";
            myReader = myCommand.ExecuteReader();
            if (myReader.HasRows)
            {
                while (myReader.Read())
                {
                    StudentMajor.Items.Add(myReader["Major"].ToString());
                }
            }
            myReader.Close();

            myCommand.CommandText = "select DISTINCT Gender from Students";
            myReader = myCommand.ExecuteReader();
            if (myReader.HasRows)
            {
                while (myReader.Read())
                {
                    StudentGender.Items.Add(myReader["Gender"].ToString());
                }
            }
            myReader.Close();

            myCommand.CommandText = "select DISTINCT Department from Courses";
            myReader = myCommand.ExecuteReader();
            if (myReader.HasRows)
            {
                while (myReader.Read())
                {
                    CourseDept.Items.Add(myReader["Department"].ToString());
                }
            }
            myReader.Close();

            myCommand.CommandText = "select DISTINCT Faculty from Courses";
            myReader = myCommand.ExecuteReader();
            if (myReader.HasRows)
            {
                while (myReader.Read())
                {
                    CourseFaculty.Items.Add(myReader["Faculty"].ToString());
                }
            }
            myReader.Close();

            myCommand.CommandText = "select DISTINCT University from Courses";
            myReader = myCommand.ExecuteReader();
            if (myReader.HasRows)
            {
                while (myReader.Read())
                {
                    CourseUniversity.Items.Add(myReader["University"].ToString());
                }
            }
            myReader.Close();

            myCommand.CommandText = "select DISTINCT Semester from Date";
            myReader = myCommand.ExecuteReader();
            if (myReader.HasRows)
            {
                while (myReader.Read())
                {
                    Semester.Items.Add(myReader["Semester"].ToString());
                }
            }
            myReader.Close();

            myCommand.CommandText = "select DISTINCT Year from Date";
            myReader = myCommand.ExecuteReader();
            if (myReader.HasRows)
            {
                while (myReader.Read())
                {
                    Year.Items.Add(myReader["Year"].ToString());
                }
            }
            myReader.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            Boolean joinInstructor;
            Boolean joinStudent;
            Boolean joinCourses;
            Boolean joinDate;

            //check if table is used for search
            if (InstructorName.SelectedItem != null || InstructorFaculty.SelectedItem != null || InstructorUniversity.SelectedItem != null)
            {
                joinInstructor = true;
            }
            else { joinInstructor = false; }

            if (StudentName.SelectedItem != null || StudentMajor.SelectedItem != null || StudentGender.SelectedItem != null)
            {
                joinStudent = true;
            }
            else { joinStudent = false; }

            if (CourseDept.SelectedItem != null || CourseFaculty.SelectedItem != null || CourseUniversity.SelectedItem != null)
            {
                joinCourses = true;
            }
            else { joinCourses = false; }

            if (Semester.SelectedItem != null || Year.SelectedItem != null)
            {
                joinDate = true;
            }
            else { joinDate = false; }

            if (joinInstructor || joinStudent || joinCourses || joinDate)
            {
                String query = joinTablesCommand(joinInstructor, joinStudent, joinCourses, joinDate);
                query += addConditions(joinInstructor, joinStudent, joinCourses, joinDate);
                query += searchConditions(joinInstructor, joinStudent, joinCourses, joinDate);


                MessageBox.Show(query);
                ResultsTextBox.Clear();

                myCommand.CommandText = query;
                myReader = myCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        ResultsTextBox.AppendText(myReader["Result"].ToString());
                    }
                }
                myReader.Close();
            }

        }

        //add the required tables to the query 
        public String joinTablesCommand(Boolean instructor, Boolean student, Boolean course, Boolean date)
        {
            String tables = "select SUM(Count) as Result from";

            if (instructor)
            {
                tables += " Instructors I,";
            }
            if (student)
            {
                tables += " Students S,";
            }
            if (course)
            {
                tables += " Courses C,";
            }
            if (date)
            {
                tables += " Date D,";
            }
            tables += " Fact_Table F";

            return tables;
        }

        //join the appropriate tables
        public String addConditions(Boolean instructor, Boolean student, Boolean course, Boolean date)
        {
            String toAdd = " where";

            if (instructor)
            {
                toAdd += " I.InstructorID = F.InstructorID ";
            }
            if (student)
            {
                if (instructor)
                {
                    toAdd += "AND";
                }
                toAdd += " S.StudentID = F.StudentID ";
            }
            if (course)
            {
                if (instructor || student)
                {
                    toAdd += "AND";
                }
                toAdd += " C.CourseID = F.CourseID ";
            }
            if (date)
            {
                if (instructor || student || course)
                {
                    toAdd += "AND";
                }
                toAdd += " D.DateID = F.DateID ";
            }

            return toAdd;
        }

        public String searchConditions(Boolean instructor, Boolean student, Boolean course, Boolean date)
        {
            String toAdd = "AND ";
            Boolean isFirstCondition = true; // Flag to track if it's the first condition

            if (instructor)
            {

                if (InstructorName.SelectedItem != null)
                {
                    toAdd += "I.Instructor = '" + InstructorName.SelectedItem.ToString() + "'";
                    isFirstCondition = false;
                }

                if (InstructorFaculty.SelectedItem != null)
                {
                    if (!isFirstCondition)
                        toAdd += " AND ";

                    toAdd += "I.Faculty = '" + InstructorFaculty.SelectedItem.ToString() + "'";
                    isFirstCondition = false;
                }

                if (InstructorUniversity.SelectedItem != null)
                {
                    if (!isFirstCondition)
                        toAdd += " AND ";

                    toAdd += "I.University = '" + InstructorUniversity.SelectedItem.ToString() + "'";
                    isFirstCondition = false;
                }
            }

            if (student)
            {

                if (StudentName.SelectedItem != null)
                {
                    if (!isFirstCondition)
                        toAdd += " AND ";

                    toAdd += "S.Student = '" + StudentName.SelectedItem.ToString() + "'";
                    isFirstCondition = false;
                }

                if (StudentMajor.SelectedItem != null)
                {
                    if (!isFirstCondition)
                        toAdd += " AND ";

                    toAdd += "S.Major = '" + StudentMajor.SelectedItem.ToString() + "'";
                    isFirstCondition = false;
                }

                if (StudentGender.SelectedItem != null)
                {
                    if (!isFirstCondition)
                        toAdd += " AND ";

                    toAdd += "S.Gender = '" + StudentGender.SelectedItem.ToString() + "'";
                    isFirstCondition = false;
                }
            }

            if (course)
            {

                if (CourseDept.SelectedItem != null)
                {
                    if (!isFirstCondition)
                        toAdd += " AND ";

                    toAdd += "C.Department = '" + CourseDept.SelectedItem.ToString() + "'";
                    isFirstCondition = false;
                }

                if (CourseFaculty.SelectedItem != null)
                {
                    if (!isFirstCondition)
                        toAdd += " AND ";

                    toAdd += "C.Faculty = '" + CourseFaculty.SelectedItem.ToString() + "'";
                    isFirstCondition = false;
                }

                if (CourseUniversity.SelectedItem != null)
                {
                    if (!isFirstCondition)
                        toAdd += " AND ";

                    toAdd += "C.University = '" + CourseUniversity.SelectedItem.ToString() + "'";
                    isFirstCondition = false;
                }
            }
            if (date)
            {

                if (Semester.SelectedItem != null)
                {
                    if (!isFirstCondition)
                        toAdd += " AND ";

                    toAdd += "D.Semester = '" + Semester.SelectedItem.ToString() + "'";
                    isFirstCondition = false;
                }

                if (Year.SelectedItem != null)
                {
                    if (!isFirstCondition)
                        toAdd += " AND ";

                    toAdd += "D.Year = '" + Year.SelectedItem.ToString() + "'";
                }
            }


            return toAdd;
        }

        //clear the search parameters
        private void ResetButton_Click(object sender, EventArgs e)
        {
            InstructorName.SelectedIndex = -1;
            InstructorFaculty.SelectedIndex = -1;
            InstructorUniversity.SelectedIndex = -1;

            StudentName.SelectedIndex = -1;
            StudentMajor.SelectedIndex = -1;
            StudentGender.SelectedIndex = -1;

            CourseDept.SelectedIndex = -1;
            CourseFaculty.SelectedIndex = -1;
            CourseUniversity.SelectedIndex = -1;

            Semester.SelectedIndex = -1;
            Year.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //tableName = comboBox1.SelectedItem.ToString();
            //MessageBox.Show(tableName);
        }

        private void uploadBtn_Click(object sender, EventArgs e)
        {
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                // Set the title and filter for the file dialog
                openFileDialog.Title = "Select a File";
                openFileDialog.Filter = "XML Files (*.xml)|*.xml";

                // Show the file dialog and check if the user selected a file
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected file name and display it
                    string selectedFileName = openFileDialog.FileName;
                    //MessageBox.Show("Selected File: " + selectedFileName);
                    TransformAndLoadData(selectedFileName);
                    //selectedFileLabel.Text = "Selected File: " + selectedFileName;
                }
            }
        }
        private void TransformAndLoadData(string xmlFilePath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);
            LoadInstructorsData(xmlDoc, connectionString);
            LoadStudentsData(xmlDoc, connectionString);
            LoadCoursesData(xmlDoc, connectionString);
            LoadDates(xmlDoc, connectionString);
            LoadFact(xmlDoc, connectionString);
            MessageBox.Show("Data Uploaded Successfully!");


        }
        private void LoadInstructorsData(XmlDocument xmlDoc, string connectionString)
        {
            try
            {
                XmlNodeList instructorNodes = xmlDoc.SelectNodes("//Instructors/Instructor");
                if (instructorNodes != null) {
                    var dataTable = new DataTable();
                    dataTable.Columns.Add("InstructorID", typeof(int));
                    dataTable.Columns.Add("Instructor", typeof(string));
                    dataTable.Columns.Add("Faculty", typeof(string));
                    dataTable.Columns.Add("rank", typeof(string));
                    dataTable.Columns.Add("University", typeof(string));

                    foreach (XmlNode node in instructorNodes)
                    {
                        int instructorID = int.Parse(node.SelectSingleNode("InstructorID").InnerText);
                        string instructorName = node.SelectSingleNode("Instructor").InnerText;
                        string faculty = node.SelectSingleNode("Faculty").InnerText.Trim('\''); // Remove leading and trailing single quotes
                        string rank = node.SelectSingleNode("rank").InnerText.Trim('\''); // Remove leading and trailing single quotes
                        string university = node.SelectSingleNode("University").InnerText.Trim('\''); // Remove leading and trailing single quotes

                        dataTable.Rows.Add(instructorID, instructorName, faculty, rank, university);
                    }
                    using (var bulkCopy = new SqlBulkCopy(connectionString, SqlBulkCopyOptions.KeepIdentity))
                    {
                        bulkCopy.DestinationTableName = "Instructors";
                        bulkCopy.BatchSize = 1000;
                        bulkCopy.BulkCopyTimeout = 600;
                        bulkCopy.ColumnMappings.Add("InstructorID", "InstructorID");
                        bulkCopy.ColumnMappings.Add("Instructor", "Instructor");
                        bulkCopy.ColumnMappings.Add("Faculty", "Faculty");
                        bulkCopy.ColumnMappings.Add("rank", "rank");
                        bulkCopy.ColumnMappings.Add("University", "University");

                        bulkCopy.WriteToServer(dataTable);
                    }
                }
                else
                {
                    MessageBox.Show("No instructor nodes found in the XML document.");
                }
            }
            catch (XPathException xpathEx)
            {
                // Handle XPathException
                MessageBox.Show("XPathException occurred: " + xpathEx.Message);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void LoadStudentsData(XmlDocument xmlDoc, string connectionString)
        {
            try
            {
                XmlNodeList studentNodes = xmlDoc.SelectNodes("//Students/Student");
                if (studentNodes != null)
                {
                    var dataTable = new DataTable();
                    dataTable.Columns.Add("StudentID", typeof(int));
                    dataTable.Columns.Add("Student", typeof(string));
                    dataTable.Columns.Add("major", typeof(string));
                    dataTable.Columns.Add("Gender", typeof(string));

                    foreach (XmlNode node in studentNodes)
                    {
                        int studentID = int.Parse(node.SelectSingleNode("StudentID").InnerText);
                        string student = node.SelectSingleNode("Student").InnerText;
                        string major = node.SelectSingleNode("major").InnerText.Trim('\''); // Remove leading and trailing single quotes
                        string gender = node.SelectSingleNode("Gender").InnerText.Trim('\''); // Remove leading and trailing single quotes


                        dataTable.Rows.Add(studentID, student, major, gender);
                    }
                    using (var bulkCopy = new SqlBulkCopy(connectionString, SqlBulkCopyOptions.KeepIdentity))
                    {
                        bulkCopy.DestinationTableName = "Students";
                        bulkCopy.BatchSize = 1000;
                        bulkCopy.BulkCopyTimeout = 600;
                        bulkCopy.ColumnMappings.Add("StudentID", "StudentID");
                        bulkCopy.ColumnMappings.Add("Student", "Student");
                        bulkCopy.ColumnMappings.Add("major", "major");
                        bulkCopy.ColumnMappings.Add("Gender", "Gender");

                        bulkCopy.WriteToServer(dataTable);
                    }
                }
                else
                {
                    MessageBox.Show("No student nodes found in the XML document.");
                }
            }
            catch (XPathException xpathEx)
            {
                // Handle XPathException
                MessageBox.Show("XPathException occurred: " + xpathEx.Message);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void LoadCoursesData(XmlDocument xmlDoc, string connectionString)
        {
            try
            {
                XmlNodeList courseNodes = xmlDoc.SelectNodes("//Courses/Course");
                if (courseNodes != null)
                {
                    var dataTable = new DataTable();
                    dataTable.Columns.Add("CourseID", typeof(int));
                    dataTable.Columns.Add("Department", typeof(string));
                    dataTable.Columns.Add("Faculty", typeof(string));
                    dataTable.Columns.Add("University", typeof(string));

                    foreach (XmlNode node in courseNodes)
                    {
                        int courseID = int.Parse(node.SelectSingleNode("CourseID").InnerText);
                        string department = node.SelectSingleNode("Department").InnerText.Trim('\'', ' ');
                        string faculty = node.SelectSingleNode("Faculty").InnerText.Trim('\''); // Remove leading and trailing single quotes
                        string university = node.SelectSingleNode("University").InnerText.Trim('\''); // Remove leading and trailing single quotes


                        dataTable.Rows.Add(courseID, department, faculty, university);
                    }
                    using (var bulkCopy = new SqlBulkCopy(connectionString, SqlBulkCopyOptions.KeepIdentity))
                    {
                        bulkCopy.DestinationTableName = "Courses";
                        bulkCopy.BatchSize = 1000;
                        bulkCopy.BulkCopyTimeout = 600;
                        bulkCopy.ColumnMappings.Add("CourseID", "CourseID");
                        bulkCopy.ColumnMappings.Add("Department", "Department");
                        bulkCopy.ColumnMappings.Add("Faculty", "Faculty");
                        bulkCopy.ColumnMappings.Add("University", "University");

                        bulkCopy.WriteToServer(dataTable);
                    }
                }
                else
                {
                    MessageBox.Show("No course nodes found in the XML document.");
                }
            }
            catch (XPathException xpathEx)
            {
                // Handle XPathException
                MessageBox.Show("XPathException occurred: " + xpathEx.Message);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        private void LoadDates(XmlDocument xmlDoc, string connectionString)
        {
            try
            {
                XmlNodeList dateNodes = xmlDoc.SelectNodes("//Date/date");
                if (dateNodes != null)
                {
                    var dataTable = new DataTable();
                    dataTable.Columns.Add("DateID", typeof(int));
                    dataTable.Columns.Add("Semester", typeof(string));
                    dataTable.Columns.Add("year", typeof(int));
                    foreach (XmlNode node in dateNodes)
                    {
                        int dateID = int.Parse(node.SelectSingleNode("DateID").InnerText);
                        string semester = node.SelectSingleNode("Semester").InnerText.Trim('\''); // Remove leading and trailing single quotes
                        int year = int.Parse(node.SelectSingleNode("year").InnerText);


                        dataTable.Rows.Add(dateID, semester, year);
                    }
                    using (var bulkCopy = new SqlBulkCopy(connectionString, SqlBulkCopyOptions.KeepIdentity))
                    {
                        bulkCopy.DestinationTableName = "Date";
                        bulkCopy.BatchSize = 1000;
                        bulkCopy.BulkCopyTimeout = 600;
                        bulkCopy.ColumnMappings.Add("DateID", "DateID");
                        bulkCopy.ColumnMappings.Add("Semester", "Semester");
                        bulkCopy.ColumnMappings.Add("year", "year");

                        bulkCopy.WriteToServer(dataTable);
                    }
                }
                else
                {
                    MessageBox.Show("No date nodes found in the XML document.");
                }
            }
            catch (XPathException xpathEx)
            {
                // Handle XPathException
                MessageBox.Show("XPathException occurred: " + xpathEx.Message);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        private void LoadFact(XmlDocument xmlDoc, string connectionString)
        {
            try
            {
                // Extract data for Fact_Table
                XmlNodeList factNodes = xmlDoc.SelectNodes("//Fact_Table/fact_table");
                if (factNodes != null)
                {
                    var dataTable = new DataTable();
                    dataTable.Columns.Add("InstructorID", typeof(int));
                    dataTable.Columns.Add("StudentID", typeof(int));
                    dataTable.Columns.Add("CourseID", typeof(int));
                    dataTable.Columns.Add("DateID", typeof(int));
                    dataTable.Columns.Add("Count", typeof(int));

                    foreach (XmlNode node in factNodes)
                    {
                        // Extract data from XML node
                        int instructorID = int.Parse(node.SelectSingleNode("InstructorID").InnerText);
                        int studentID = int.Parse(node.SelectSingleNode("StudentID").InnerText);
                        int courseID = int.Parse(node.SelectSingleNode("CourseID").InnerText);
                        int dateID = int.Parse(node.SelectSingleNode("DateID").InnerText);
                        int count = int.Parse(node.SelectSingleNode("Count").InnerText);

                        dataTable.Rows.Add(instructorID, studentID, courseID, dateID, count);
                    }

                    using (var bulkCopy = new SqlBulkCopy(connectionString, SqlBulkCopyOptions.KeepIdentity))
                    {
                        bulkCopy.DestinationTableName = "Fact_Table";
                        bulkCopy.BatchSize = 1000;
                        bulkCopy.BulkCopyTimeout = 600; // 10 minutes timeout
                        bulkCopy.ColumnMappings.Add("InstructorID", "InstructorID");
                        bulkCopy.ColumnMappings.Add("StudentID", "StudentID");
                        bulkCopy.ColumnMappings.Add("CourseID", "CourseID");
                        bulkCopy.ColumnMappings.Add("DateID", "DateID");
                        bulkCopy.ColumnMappings.Add("Count", "Count");

                        bulkCopy.WriteToServer(dataTable);
                    }
                }
                else
                {
                    MessageBox.Show("No fact nodes found in the XML document.");
                }
            }
            catch (XPathException xpathEx)
            {
                // Handle XPathException
                MessageBox.Show("XPathException occurred: " + xpathEx.Message);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}

