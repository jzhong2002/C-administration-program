using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Security;
using System.Xml.Linq;

// This is the namespace where our enumeration classes will be defined
namespace MyNamespace
{
    // This is an enumeration for different role names
    public enum RoleName
    {
        Teacher,
        Admin,
        Student
    }

    // This is an enumeration for different job types to be used by the admin derived class
    public enum JobType
    {
        Full_Time,
        Part_Time
    }

    // This is a parent class named "Person", which has various properties like name, telephone, email, role and ID
    class Person
    {

        private string name = "";
        private int telephone = 0;
        private string email = "";
        private RoleName role = RoleName.Teacher;
        private int id = 0;
        private static int nextId = 1;

        // This is the constructor for the Person class. It sets the ID to the next available ID
        public Person()
        {
            id = nextId;
            nextId++;
        }

        // This is a property for the Person's name to get the name and sets the name to a new value
        public string Name
        {
            get { return (name); }
            set { name = value; }
        }

        // This is a property for the Person's telephone to get the telephone and sets the telephone to a new value
        public int Telephone
        {
            get { return (telephone); }
            set { telephone = value; }
        }

        // This is a property for the Person's email to get the email and sets the email to a new value
        public string Email
        {
            get { return (email); }
            set { email = value; }
        }

        // This is a property for the Person's role names to get the role names and sets the role names to a new value
        public RoleName Role
        {
            get { return (role); }
            set { if (((int)value >= (int)RoleName.Teacher) && ((int)value <= (int)RoleName.Student)) { role = value; } }
        }

        // This is a property for the Person's ID 
        public int Id
        {
            get { return (id); }
        }
    }

    // Implementing properties of the derived class "Teacher" with using the "get" & "set" method
    class Teacher : Person
    {
        private double salary = 0;
        private string primary_Subject = "";
        private string secondary_Subject = "";

        //This is a preperty for the Teacher's salary to get and set the salary to a new value
        public double Salary
        {
            get { return (salary); }
            set { if ((value >= 10000) && (value <= 100000)) { salary = value; } }
        }

        //This is a preperty for the Teacher's primary subject to get and set the salary to a new value
        public string Primary_Subject
        {
            get { return (primary_Subject); }
            set { primary_Subject = value; }
        }

        //This is a preperty for the Teacher's secondary subject to get and set the salary to a new value
        public string Secondary_Subject
        {
            get { return (secondary_Subject); }
            set { secondary_Subject = value; }
        }
    }

    // Implementing properties of the derived class "Admin" with using the "get" & "set" method
    class Admin : Person
    {
        private double salary = 0;
        private JobType jobtitle = JobType.Full_Time;
        private int working_hours = 0;


        //This is a preperty for the Admin's salary to get and set the salary to a new value
        public double Salary
        {
            get { return (salary); }
            set { if ((value >= 10000) && (value <= 100000)) { salary = value; } }
        }

        //This is a preperty for the Admin's job types to get and set the salary to a new value
        public JobType Jobtitle
        {

            get { return (jobtitle); }
            set { if (((int)value >= (int)JobType.Full_Time) && ((int)value <= (int)JobType.Part_Time)) { jobtitle = value; } }

        }

        //This is a preperty for the Admin's working hours to get and set the salary to a new value
        public int Working_Hours
        {
            get { return (working_hours); }
            set { working_hours = value; }
        }
    }

    // Implementing properties of the derived class "Student" with using the "get" & "set" method"
    class Student : Person
    {
        private string current_first_subject = "";
        private string current_second_subject = "";
        private string previous_first_subject = "";
        private string previous_second_subject = "";

        // This is a property for the Student's current first subject to get and set the subject values
        public string Current_first_subject
        {
            get { return (current_first_subject); }
            set { current_first_subject = value; }
        }

        // This is a property for the Student's current second subject to get and set the subject values
        public string Current_second_subject
        {
            get { return (current_second_subject); }
            set { current_second_subject = value; }
        }

        // This is a property for the Student's previous first subject to get and set the subject values
        public string Previous_first_subject
        {
            get { return (previous_first_subject); }
            set { previous_first_subject = value; }
        }

        // This is a property for the Student's previous second subject to get and set the subject values
        public string Previous_second_subject
        {
            get { return (previous_second_subject); }
            set { previous_second_subject = value; }
        }
    }

    // Initialising the public class named MyClass to provide implementation of methods that allows user input and display of data
    public class MyClass
    {
        public static void Main(string[] args)
        {
            // List of objects
            List<Teacher> Teachers = new List<Teacher>();
            List<Admin> Admins = new List<Admin>();
            List<Student> Students = new List<Student>();

            while (true)
            {
                int i = 0;
                int c = 1;
                int r = 0;

                Console.WriteLine("\n ---Welcome!--- \n");
                Console.Write("Enter Your role (0: Teacher, 1: Admin, 2: Student): "); // Get user to select a role 
                int z = Convert.ToInt32(Console.ReadLine());

                if (z == (int)RoleName.Teacher)
                {
                    Console.WriteLine("\n ---Teacher--- \n");
                    while (c < 6)
                    {
                        // Main Menu

                        Console.WriteLine("\n Main Menu \n");
                        Console.WriteLine("1. Add New Data");
                        Console.WriteLine("2. View All Teacher");
                        Console.WriteLine("3. View Existing Data by User Group (Teachers, Admins, Students)");
                        Console.WriteLine("4. Edit Existing Data");
                        Console.WriteLine("5. Delete Existing Data");
                        Console.WriteLine("6. Exit the Teacher Database");
                        c = Convert.ToInt32(Console.ReadLine());
                        switch (c)
                        {
                            case 1:
                                Teacher myTeacher = new Teacher(); // Create a new teacher object

                                Console.WriteLine("\n Adding new record \n"); // This is the first option for adding new Teacher record

                                // Enter data
                                Console.Write("Enter teacher name: ");
                                myTeacher.Name = Convert.ToString(Console.ReadLine()); // Get the teacher's name

                                Console.Write("Enter teacher telephone number: ");
                                myTeacher.Telephone = (int)Convert.ToInt64(Console.ReadLine()); // Get the teacher's telephone number

                                Console.Write("Enter teacher email: ");
                                myTeacher.Email = Convert.ToString(Console.ReadLine()); // Get the teacher's email

                                myTeacher.Role = RoleName.Teacher; // Set the role name to teacher

                                Console.Write("Enter teacher salary: ");
                                myTeacher.Salary = Convert.ToInt32(Console.ReadLine()); // Get the teahcer's salary

                                Console.Write("Enter First_Subject: ");
                                myTeacher.Primary_Subject = Convert.ToString(Console.ReadLine()); // Get the teacher's first subject

                                Console.Write("Enter Second_Subject: ");
                                myTeacher.Secondary_Subject = Convert.ToString(Console.ReadLine()); // Get the teacher's second subject

                                // Save object to list
                                Teachers.Add(myTeacher);
                                break;

                            case 2:
                                Console.WriteLine("List All Records"); // This is Option 2 for listing all records from the Teacher list
                                i = 0;
                                foreach (Teacher b in Teachers) // This is to display each of the record from the Teacher list
                                {
                                    Console.WriteLine("{0}. {1} {2} {3} {4} {5} {6}", i, b.Name, b.Telephone, b.Email, b.Role, b.Primary_Subject, b.Secondary_Subject);
                                    i = i + 1;
                                }
                                break;

                            // List all records of a specific role
                            case 3:

                                Console.WriteLine("\n Listing records by Groups \n"); // Option 3 for listing all records in different roles
                                Console.Write("Enter a role title (0: Teacher, 1: Admin, 2: Student): "); // User could select a role type to view its records
                                r = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("You selected {0}: ", (RoleName)r);
                                i = 1;
                                if (r == (int)RoleName.Teacher)
                                {
                                    foreach (Teacher b in Teachers) // This is to display each of the record in Teacher
                                    {
                                        if (r == (int)b.Role)
                                        {
                                            Console.WriteLine("{0}. Name: {1} Telephone: {2} Email: {3} Role:  {4} Primary Subject: {5} Secondary Subject: {6} Salary: £{7}", i, b.Name, b.Telephone, b.Email, b.Role, b.Primary_Subject, b.Secondary_Subject, b.Salary);
                                            i = i + 1;
                                        }
                                    }
                                }
                                else if (r == (int)RoleName.Admin) // This is to display each of the record in Admin
                                {
                                    foreach (Admin b in Admins)
                                    {
                                        if (r == (int)b.Role)
                                        {
                                            Console.WriteLine("{0}. Name: {1}, Telephone: {2}, Email: {3}, Role: {4}, Salary: {5}, Job Type: {6}, Working Hours: {7}", i, b.Name, b.Telephone, b.Email, b.Role, b.Salary, b.Jobtitle, b.Working_Hours);
                                            i = i + 1;
                                        }
                                    }
                                }
                                else if (r == (int)RoleName.Student) // This is to display each of the record in Student
                                {
                                    foreach (Student b in Students)
                                    {
                                        if (r == (int)b.Role)
                                        {
                                            Console.WriteLine("{0}. Name: {1}, Telephone: {2}, Email: {3}, Role: {4}, Current Primary Subject: {5}, Current Secondary Subject: {6}, Previous Primary Subject: {7}, Previous Secondary Subject: {8}", i, b.Name, b.Telephone, b.Email, b.Role, b.Current_first_subject, b.Current_second_subject, b.Previous_first_subject, b.Previous_second_subject);
                                            i = i + 1;
                                        }
                                    }
                                }
                                break;

                            // Option 4: Edit and overide the existing records by role
                            case 4:
                                Console.WriteLine("\n Editing the original data \n");

                                i = 1;
                                Console.WriteLine("List");
                                foreach (Teacher b in Teachers) // Display of existing records in the Teacher list for user to select which attribute to change by selecting a corresponding index from 1 - 7
                                {
                                    Console.WriteLine("\n {0}. (1) Name: {1}, (2) Telephone: {2}, (3) Email: {3}, (4) Role: {4}, (5) Salary: {5}, (6) Primary Subject: {6}, (7) Secondary Subject: {7} \n", b.Id, b.Name, b.Telephone, b.Email, b.Role, b.Salary, b.Primary_Subject, b.Secondary_Subject);
                                    i = i + 1;
                                }


                                int teacherId;
                                Teacher selectedTeacher;

                                while (true)
                                {
                                    Console.Write("\n Enter the ID you want to change: \n");

                                    try
                                    {
                                        teacherId = Convert.ToInt32(Console.ReadLine());
                                        selectedTeacher = Teachers.Find(t => t.Id == teacherId);

                                        if (selectedTeacher == null)
                                        {
                                            Console.WriteLine("\n Error: Invalid ID. Please enter a valid ID. \n"); // Error execption if a user has entered an invalid ID
                                            continue;
                                        }

                                        Console.WriteLine("\n What would you like to change: \n");
                                        string user_select = Convert.ToString(Console.ReadLine());
                                        foreach (Teacher b in Teachers)
                                        {
                                            if (user_select == "1")
                                            {
                                                Console.Write("\n Enter a new teacher name: \n");
                                                string name = Convert.ToString(Console.ReadLine()); // Get the new value for Teacher's name 
                                                b.Name = name;
                                                Console.WriteLine("\n New records have been entered! \n");

                                                break;
                                            }
                                            else if (user_select == "2")
                                            {

                                                Console.Write("\n Enter a new teacher telephone: \n");
                                                int telephone = (int)Convert.ToInt64(Console.ReadLine()); // Get the new value for Teacher's telephone number 
                                                b.Telephone = telephone;
                                                Console.WriteLine("\n New records have been entered! \n");

                                                break;
                                            }
                                            else if (user_select == "3")
                                            {

                                                Console.Write("\n Enter a new teacher email: \n");
                                                string email = Convert.ToString(Console.ReadLine()); // Get the new value for Teacher's email
                                                b.Email = email;
                                                Console.WriteLine("\n New records have been entered! \n");

                                                break;
                                            }
                                            else if (user_select == "4")
                                            {

                                                Console.WriteLine("\n Sorry, the role name cannot be changed! \n"); // Alert message saying that the role name for Teacher can not be changed

                                                break;
                                            }
                                            else if (user_select == "5")
                                            {

                                                Console.Write("\n Enter a new teacher salary: \n");
                                                double salary = Convert.ToDouble(Console.ReadLine()); // Get the new value for Teacher's salary amount
                                                b.Salary = salary;
                                                Console.WriteLine("New records have been entered!");

                                                break;
                                            }
                                            else if (user_select == "6")
                                            {

                                                Console.Write("\n Enter a new first subject: \n");
                                                string first_subject = Convert.ToString(Console.ReadLine()); // Get the new value for Teacher's first subject
                                                b.Primary_Subject = first_subject;
                                                Console.WriteLine("\n New records have been entered! \n");

                                                break;

                                            }
                                            else if (user_select == "7")
                                            {

                                                Console.Write("\n Enter a new second subject: \n");
                                                string second_subject = Convert.ToString(Console.ReadLine()); // Get the new value for Teacher's second subject
                                                b.Secondary_Subject = second_subject;
                                                Console.WriteLine("\n New records have been entered! \n");

                                                break;
                                            }
                                            else if (user_select != "1-7") // Error exception for when a user types in an index that is out of range
                                            {
                                                Console.WriteLine("Sorry index" + " " + user_select + " " + " that you have entered can not be found! Please enter a valid Index");

                                                break;
                                            }
                                        }
                                            Console.WriteLine("New records"); // Display of the new records
                                            Console.WriteLine("\n {0}. (1) Name: {1}, (2) Telephone: {2}, (3) Email: {3}, (4) Role: {4}, (5) Salary: {5}, (6) Primary Subject: {6}, (7) Secondary Subject: {7} \n", selectedTeacher.Id, selectedTeacher.Name, selectedTeacher.Telephone, selectedTeacher.Email, selectedTeacher.Role, selectedTeacher.Salary, selectedTeacher.Primary_Subject, selectedTeacher.Secondary_Subject);

                                          /*
                                            selectedTeacher.Name = Name;
                                            selectedTeacher.Telephone = Telephone;
                                            selectedTeacher.Email = Email;
                                            selectedTeacher.Role = RoleName.Teacher;
                                            selectedTeacher.Salary = Salary;
                                            selectedTeacher.Primary_Subject = First_Subject;
                                            selectedTeacher.Secondary_Subject = Second_Subject;
                                          */

                                        break;
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("Error: Invalid input format. Please enter a valid integer."); // Error exception for inputting wrong data type into the system
                                    }
                                }
                                break;

                            // Delete method that allows user to delete any existing record by selecting the index of a record
                            case 5:
                                // Delete Feature
                                Console.WriteLine("\n Deleting record from List \n"); 
                                Console.Write("Enter Row Number: ");
                                r = Convert.ToInt32(Console.ReadLine());
                                Teachers.RemoveAt(r - 1);
                                break;
                        }
                    }
                }
                // This is the admin section
                else if (z == (int)RoleName.Admin)
                {

                    Console.WriteLine("\n ---Admin--- \n");
                    while (c < 6)
                    {
                        // Main Menu

                        Console.WriteLine("\n Main Menu \n");
                        Console.WriteLine("1. Add New Data");
                        Console.WriteLine("2. View All Admins");
                        Console.WriteLine("3. View Existing Data by User Group (Teachers, Admins, Students)");
                        Console.WriteLine("4. Edit Existing Data");
                        Console.WriteLine("5. Delete Existing Data");
                        Console.WriteLine("6. Exit the Admin Database");
                        c = Convert.ToInt32(Console.ReadLine());
                        switch (c)
                        {
                            case 1:

                                Console.WriteLine("\n Adding new record \n"); // This is the Option 1 for adding new Admin record
                                Admin myAdmin = new Admin();

                                // Enter data
                                Console.Write("Enter Admin name: ");
                                myAdmin.Name = Convert.ToString(Console.ReadLine()); // Get the admin's name

                                Console.Write("Enter Admin telephone number: ");
                                myAdmin.Telephone = (int)Convert.ToInt64(Console.ReadLine()); // Get the admin's telephone number

                                Console.Write("Enter Admin email: ");
                                myAdmin.Email = Convert.ToString(Console.ReadLine()); // Get the admin's email

                                myAdmin.Role = RoleName.Admin;

                                Console.Write("Enter Admin salary: ");
                                myAdmin.Salary = Convert.ToInt32(Console.ReadLine()); // Get the admin's salary 

                                Console.Write("Enter Admin job type (0: Full-time, 1: Part-time): "); // Get the admin's job type 
                                r = Convert.ToInt32(Console.ReadLine());
                                myAdmin.Jobtitle = (JobType)r;

                                Console.Write("Enter Admin working hours: "); 
                                myAdmin.Working_Hours = Convert.ToInt32(Console.ReadLine()); // Get the admin's working hours

                                // Save object to list
                                Admins.Add(myAdmin);
                                break;

                            case 2:
                                Console.WriteLine("List All Records"); // This is Option 2 for listing all records from the Admin list
                                i = 0;
                                foreach (Admin b in Admins) // This is to display each of the record from the Admin list
                                {
                                    Console.WriteLine("{0}. {1} {2} {3} {4} {5} {6}", i, b.Name, b.Telephone, b.Email, b.Role, b.Jobtitle, b.Working_Hours);
                                    i = i + 1;
                                }
                                break;

                            case 3:

                                Console.WriteLine("\n Listing records by Groups \n"); // Option 3 for listing all records in different roles
                                Console.Write("Enter a role (0: Teacher, 1: Admin, 2: Student): "); // User could select a role type to view its records
                                r = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("You selected {0}: ", (RoleName)r); 
                                i = 1;
                                if (r == (int)RoleName.Teacher)
                                {
                                    foreach (Teacher b in Teachers) // This is to display each of the record in Teacher
                                    {
                                        if (r == (int)b.Role)
                                        {
                                            Console.WriteLine("{0}. Name: {1} Telephone: {2} Email: {3} Role:  {4} Primary Subject: {5} Secondary Subject: {6} Salary: £{7}", i, b.Name, b.Telephone, b.Email, b.Role, b.Primary_Subject, b.Secondary_Subject, b.Salary);
                                            i = i + 1;
                                        }
                                    }
                                }
                                else if (r == (int)RoleName.Admin) // This is to display each of the record in Admin
                                {
                                    foreach (Admin b in Admins)
                                    {
                                        if (r == (int)b.Role)
                                        {
                                            Console.WriteLine("{0}. Name: {1}, Telephone: {2}, Email: {3}, Role: {4}, Salary: {5}, Job Type: {6}, Working Hours: {7}", i, b.Name, b.Telephone, b.Email, b.Role, b.Salary, b.Jobtitle, b.Working_Hours);
                                            i = i + 1;
                                        }
                                    }
                                }
                                else if (r == (int)RoleName.Student)
                                {
                                    foreach (Student b in Students) // This is to display each of the record in Student
                                    {
                                        if (r == (int)b.Role)
                                        {
                                            Console.WriteLine("{0}. Name: {1}, Telephone: {2}, Email: {3}, Role: {4}, Current Primary Subject: {5}, Current Secondary Subject: {6}, Previous Primary Subject: {7}, Previous Secondary Subject: {8}", i, b.Name, b.Telephone, b.Email, b.Role, b.Current_first_subject, b.Current_second_subject, b.Previous_first_subject, b.Previous_second_subject);
                                            i = i + 1;
                                        }                          }
                                }
                                break;

                            // Option 4: Edit and overide the existing records by role
          
                            case 4:
                                Console.WriteLine("\n Editing the original data \n");

                                i = 1;
                                Console.WriteLine("List");
                                foreach (Admin b in Admins) // Display of existing records in Admin list for user to select which attribute to change by selecting a corresponding index from 1 - 7
                                {
                                    Console.WriteLine("\n {0}. (1) Name: {1}, (2) Telephone: {2}, (3) Email: {3}, (4) Role: {4}, (5) Salary: {5}, (6) Job Type: {6}, (7) Wokring Hours: {7} \n", b.Id, b.Name, b.Telephone, b.Email, b.Role, b.Salary, b.Jobtitle, b.Working_Hours);
                                    i = i + 1;
                                }

                                int adminId;
                                Admin selectedAdmin;

                                while (true)
                                {
                                    Console.Write("\n Enter the ID you want to change: \n");

                                    try
                                    {
                                        adminId = Convert.ToInt32(Console.ReadLine());
                                        selectedAdmin = Admins.Find(t => t.Id == adminId);

                                        if (selectedAdmin == null)
                                        {
                                            Console.WriteLine("\n Error: Invalid ID. Please enter a valid ID. \n"); // Error execption if a user has entered an invalid ID
                                            continue;
                                        }

                                        Console.WriteLine("\n What would you like to change: \n");
                                        string user_select = Convert.ToString(Console.ReadLine()); 
                                        foreach (Admin b in Admins)
                                        {
                                            if (user_select == "1")
                                            {
                                                Console.Write("\n Enter a new Admin name: \n");
                                                string name = Convert.ToString(Console.ReadLine()); // Get the new value for Admin's name
                                                b.Name = name;
                                                Console.WriteLine("\n New records have been entered! \n");

                                                break;
                                            }
                                            else if (user_select == "2")
                                            {

                                                Console.Write("\n Enter a new Admin telephone: \n");
                                                int telephone = (int)Convert.ToInt64(Console.ReadLine()); // Get the new value for Admin's telephone number
                                                b.Telephone = telephone;
                                                Console.WriteLine("\n New records have been entered! \n");

                                                break;
                                            }
                                            else if (user_select == "3")
                                            {

                                                Console.Write("\n Enter a new Admin email: \n");
                                                string email = Convert.ToString(Console.ReadLine()); // Get the new valaue for Admin's email
                                                b.Email = email;
                                                Console.WriteLine("\n New records have been entered! \n");

                                                break;
                                            }
                                            else if (user_select == "4")
                                            {

                                                Console.WriteLine("\n Sorry, the role name cannot be changed! \n"); // Alert message saying that the role name for Admin can not be changed

                                                break;
                                            } 
                                            else if (user_select == "5")
                                            {

                                                Console.Write("\n Enter a new Admin salary: \n");
                                                double salary = Convert.ToDouble(Console.ReadLine()); // Get the new value for Admin's salary
                                                b.Salary = salary;
                                                Console.WriteLine("\n New records have been entered! \n");

                                                break;
                                            }
                                            else if (user_select == "6")
                                            {

                                                Console.Write("\n Enter a new job type: \n");
                                                string jobtype = Convert.ToString(Console.ReadLine()); // Get the new value for Admin's job type 
                                                b.Jobtitle = (JobType)r;
                                                Console.WriteLine("\n New records have been entered! \n");

                                                break;
                                            }
                                            else if (user_select == "7")
                                            {

                                                Console.Write("\n Enter a new working hours: \n");
                                                int working_hours = Convert.ToInt32(Console.ReadLine()); // Get the new valie for Admin's working hours
                                                b.Working_Hours = working_hours;
                                                Console.WriteLine("\n New records have been entered! \n");

                                                break;
                                            }
                                            else if (user_select != "1-7") // Error exception for when a user types in an index that is out of range
                                            {
                                                Console.WriteLine("Sorry index" + " " + user_select + " " + " that you have entered can not be found! Please enter a valid Index");

                                                break;
                                            }
                                        }
                                        Console.WriteLine("New records"); // Display of the new records
                                        Console.WriteLine("\n {0}. (1) Name: {1}, (2) Telephone: {2}, (3) Email: {3}, (4) Role: {4}, (5) Salary: {5}, (6) Job Type: {6}, (7) Working Hours: {7} \n", selectedAdmin.Id, selectedAdmin.Name, selectedAdmin.Telephone, selectedAdmin.Email, selectedAdmin.Role, selectedAdmin.Salary, selectedAdmin.Jobtitle, selectedAdmin.Working_Hours);

                                        /*
                                          selectedTeacher.Name = Name;
                                          selectedTeacher.Telephone = Telephone;
                                          selectedTeacher.Email = Email;
                                          selectedTeacher.Role = RoleName.Teacher;
                                          selectedTeacher.Salary = Salary;
                                          selectedTeacher.Primary_Subject = First_Subject;
                                          selectedTeacher.Secondary_Subject = Second_Subject;
                                        */

                                        break;
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("Error: Invalid input format. Please enter a valid integer."); // Error exception for inputting wrong data type into the system
                                    }
                                }
                                break;

                            case 5:

                                // Delete method that allows user to delete any existing record by selecting the index of a record
                                Console.WriteLine("\n Deleting record from List \n");
                                Console.Write("Enter Row Number: ");
                                r = Convert.ToInt32(Console.ReadLine());
                                Admins.RemoveAt(r - 1);
                                break;
                        }
                    }
                }

                // This is the student section
                else if (z == (int)RoleName.Student)
                { }

                Console.WriteLine("\n ---Student--- \n");
                while (c < 6)
                {
                    // Main Menu

                    Console.WriteLine("\n Main Menu \n");
                    Console.WriteLine("1. Add New Data");
                    Console.WriteLine("2. View All Students");
                    Console.WriteLine("3. View Existing Data by User Group (Teachers, Admins, Students)");
                    Console.WriteLine("4. Edit Existing Data");
                    Console.WriteLine("5. Delete Existing Data");
                    Console.WriteLine("6. Exit the Student Database");
                    c = Convert.ToInt32(Console.ReadLine());
                    switch (c)
                    {
                        case 1:

                            Console.WriteLine("\n Adding new record \n"); // This is the Option 1 for adding new Student record
                            Student myStudent = new Student();

                            // Enter data
                            Console.Write("Enter student name: ");
                            myStudent.Name = Convert.ToString(Console.ReadLine()); // Get the student's name

                            Console.Write("Enter student telephone number: ");
                            myStudent.Telephone = (int)Convert.ToInt64(Console.ReadLine()); // Get the student's telephone number

                            Console.Write("Enter student email: ");
                            myStudent.Email = Convert.ToString(Console.ReadLine()); // Get the student's email

                            myStudent.Role = RoleName.Student;

                            Console.Write("Enter Current Primary Subject: ");
                            myStudent.Current_first_subject = Convert.ToString(Console.ReadLine()); // Get the student's current primary subject

                            Console.Write("Enter Current Secondary Subject: ");
                            myStudent.Current_second_subject = Convert.ToString(Console.ReadLine()); // Get the student's current secondary subject 

                            Console.Write("Enter Previous Primary Subject: ");
                            myStudent.Previous_first_subject = Convert.ToString(Console.ReadLine()); // Get the student's previous primary subject  

                            Console.Write("Enter Previous Secondary Subject: ");
                            myStudent.Previous_second_subject = Convert.ToString(Console.ReadLine()); // Get the student's previous secondary subject

                            // Save object to list
                            Students.Add(myStudent);
                            break;

                        case 2:
                            Console.WriteLine("List All Records"); // This is Option 2 for listing all records from the Student list
                            i = 0;
                            foreach (Student b in Students) // This is to display each of the record from the Student list
                            {
                                Console.WriteLine("{0}. {1} {2} {3} {4} {5} {6}", i, b.Name, b.Telephone, b.Email, b.Role, b.Current_first_subject, b.Current_second_subject, b.Previous_first_subject, b.Previous_second_subject);
                                i = i + 1;
                            }
                            break;

                        case 3:

                            Console.WriteLine("\n Listing records by Groups \n"); // Option 3 for listing all records in different roles
                            Console.Write("Enter a role (0: Teacher, 1: Admin, 2: Student): "); // User could select a role type to view its records
                            r = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("You selected {0}: ", (RoleName)r);
                            i = 1;
                            if (r == (int)RoleName.Teacher)
                            {
                                foreach (Teacher b in Teachers) // This is to display each of the record in Teacher
                                {
                                    if (r == (int)b.Role)
                                    {
                                        Console.WriteLine("{0}. Name: {1} Telephone: {2} Email: {3} Role:  {4} Primary Subject: {5} Secondary Subject: {6} Salary: £{7}", i, b.Name, b.Telephone, b.Email, b.Role, b.Primary_Subject, b.Secondary_Subject, b.Salary);
                                        i = i + 1;
                                    }
                                }
                            }
                            else if (r == (int)RoleName.Admin) 
                            {
                                foreach (Admin b in Admins) // This is to display each of the record in Admin
                                {
                                    if (r == (int)b.Role)
                                    {
                                        Console.WriteLine("{0}. Name: {1}, Telephone: {2}, Email: {3}, Role: {4}, Salary: {5}, Job Type: {6}, Working Hours: {7}", i, b.Name, b.Telephone, b.Email, b.Role, b.Salary, b.Jobtitle, b.Working_Hours);
                                        i = i + 1;
                                    }
                                }
                            }
                            else if (r == (int)RoleName.Student)
                            {
                                foreach (Student b in Students) // This is to display each of the record in Student
                                {
                                    if (r == (int)b.Role)
                                    {
                                        Console.WriteLine("{0}. Name: {1}, Telephone: {2}, Email: {3}, Role: {4}, Current Primary Subject: {5}, Current Secondary Subject: {6}, Previous Primary Subject: {7}, Previous Secondary Subject: {8}", i, b.Name, b.Telephone, b.Email, b.Role, b.Current_first_subject, b.Current_second_subject, b.Previous_first_subject, b.Previous_second_subject);
                                        i = i + 1;
                                    }
                                }
                            }
                            break;

                        // Option 4: Edit and overide the existing records by role
                        case 4:
                            Console.WriteLine("\n Editing the original data \n");

                            i = 1;
                            Console.WriteLine("List");
                            foreach (Student b in Students) // Display of existing records in Admin list for user to select which attribute to change by selecting a corresponding index from 1 - 8
                            {
                                Console.WriteLine("\n {0}. (1) Name: {1}, (2) Telephone: {2}, (3) Email: {3}, (4) Role: {4}, (5) Current Primary Subject: {5}, (6) Current Secondary Subject: {6}, (7) Previous Primary Subject: {7}, (8) Previous Secondary Subject: {8} \n", b.Id, b.Name, b.Telephone, b.Email, b.Role, b.Current_first_subject, b.Current_second_subject, b.Previous_first_subject, b.Previous_second_subject);
                                i = i + 1;
                            }

                            int studentId;
                            Student selectedStudent;

                            while (true)
                            {
                                Console.Write("\n Enter the ID you want to change: \n");

                                try
                                {
                                    studentId = Convert.ToInt32(Console.ReadLine());
                                    selectedStudent = Students.Find(t => t.Id == studentId);

                                    if (selectedStudent == null)
                                    {
                                        Console.WriteLine("\n Error: Invalid ID. Please enter a valid ID. \n"); // Error execption if a user has entered an invalid ID
                                        continue;
                                    }

                                    Console.WriteLine("\n What would you like to change: \n");
                                    string user_select = Convert.ToString(Console.ReadLine()); 
                                    foreach (Student b in Students)
                                    {
                                        if (user_select == "1")
                                        {
                                            Console.Write("\n Enter a new student name: \n ");
                                            string name = Convert.ToString(Console.ReadLine()); // Get the new value for Student's name
                                            b.Name = name;
                                            Console.WriteLine("\n New records have been entered! \n");

                                            break;
                                        }
                                        else if (user_select == "2")
                                        {

                                            Console.Write("\n Enter a new student telephone: \n");
                                            int telephone = (int)Convert.ToInt64(Console.ReadLine()); // Get the new value for Student's telephone number
                                            b.Telephone = telephone;
                                            Console.WriteLine("\n New records have been entered! \n");

                                            break;
                                        }
                                        else if (user_select == "3")
                                        {

                                            Console.Write("\n Enter a new student email: \n");
                                            string email = Convert.ToString(Console.ReadLine()); // Get the new value for Student's email
                                            b.Email = email;
                                            Console.WriteLine("\n New records have been entered! \n");

                                            break;
                                        }
                                        else if (user_select == "4")
                                        {

                                            Console.WriteLine("\n Sorry, the role name cannot be changed! \n"); // Alert message saying that the role name for Student can not be changed

                                            break;
                                        }
                                        else if (user_select == "5")
                                        {

                                            Console.Write("\n Enter a new current primary subject: \n");
                                            string current_first_subject = Convert.ToString(Console.ReadLine()); // Get the new value for Student's current primary subject
                                            b.Current_first_subject = current_first_subject;
                                            Console.WriteLine("\n New records have been entered! \n");

                                            break;
                                        }
                                        else if (user_select == "6")
                                        {

                                            Console.Write("\n Enter a new current secondary subject: \n");
                                            string current_second_subject = Convert.ToString(Console.ReadLine()); // Get the new value for Student's current secondary subject
                                            b.Current_second_subject = current_second_subject;
                                            Console.WriteLine("\n New records have been entered! \n");

                                            break;
                                        }
                                        else if (user_select == "7")
                                        {

                                            Console.Write("\n Enter a new previous primary subject: \n");
                                            string previous_first_subject = Convert.ToString(Console.ReadLine()); // Get the new value for Student's previous primary subject
                                            b.Previous_first_subject = previous_first_subject;
                                            Console.WriteLine("\n New records have been entered! \n");

                                            break;
                                        }
                                        else if (user_select == "8")
                                        {

                                            Console.Write("\n Enter a new previous secondary subject: \n");
                                            string previous_second_subject = Convert.ToString(Console.ReadLine()); // Get the new value for Student's previous secondary subject
                                            b.Previous_second_subject = previous_second_subject;
                                            Console.WriteLine("\n New records have been entered! \n");

                                            break;
                                        }
                                        else if (user_select != "1-8") // Error exception for when a user types in an index that is out of rang
                                        {
                                            Console.WriteLine("Sorry index" + " " + user_select + " " + " that you have entered can not be found! Please enter a valid Index ");

                                            break;
                                        }
                                    }
                                    Console.WriteLine("New reocrds"); // Display of the new records
                                    Console.WriteLine("\n {0}. (1) Name: {1}, (2) Telephone: {2}, (3) Email: {3}, (4) Role: {4}, (5) Current primary subject: {5}, (6) Current secondary subject: {6}, (7) Previous primary subject: {7}, (8) Previous secondary subject: {8} \n", selectedStudent.Id, selectedStudent.Name, selectedStudent.Telephone, selectedStudent.Email, selectedStudent.Role, selectedStudent.Current_first_subject, selectedStudent.Current_second_subject, selectedStudent.Previous_first_subject, selectedStudent.Previous_second_subject);

                                    /*
                                      selectedTeacher.Name = Name;
                                      selectedTeacher.Telephone = Telephone;
                                      selectedTeacher.Email = Email;
                                      selectedTeacher.Role = RoleName.Teacher;
                                      selectedTeacher.Salary = Salary;
                                      selectedTeacher.Primary_Subject = First_Subject;
                                      selectedTeacher.Secondary_Subject = Second_Subject;
                                    */

                                    break;
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Error: Invalid input format. Please enter a valid integer."); //Error exception for inputting wrong date type into the system
                                }
                            }
                            break;

                        case 5:

                            // Delete method that allows user to delete any existing record by selecting the index of a record
                            Console.WriteLine("\n Deleting record from List \n");
                            Console.Write("Enter Row Number: ");
                            r = Convert.ToInt32(Console.ReadLine());
                            Admins.RemoveAt(r - 1);
                            break;
                    }
                }

                //Option 6 for exiting the program completely or exit to select a new role type
                Console.WriteLine("Exit From Program (yes/no): ");
                string userInput = Convert.ToString(Console.ReadLine());
                if (userInput == "y")
                {
                    break;
                }
            }
        }
    }
}
