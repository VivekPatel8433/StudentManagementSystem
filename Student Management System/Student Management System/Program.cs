using System;
using System.Xml.Linq;

namespace StudentManagementSystem
{
    public interface IMarkConversion
    {
        string MarkConvertor(int mark);
    }

    class Person // Common
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public Person(string name, int id)
        {
            Name = name;
            Id = id;
        }

    }

    interface IJobs // Defines Jobs available at the campus, interface allows multiple inheritance, methods and properties only. 
    {
        public int JobId { get; set; } // JobId
        public string JobTittle { get; set; } // JobName


    }


    class Student : Person // Student is a person 
    {
        public int Marks { get; set; }
        public Student(string Name, int Id, int marks) : base(Name, Id)
        {
            Marks = marks;
        }
    }

    class Instructors : Person // Instructors are person
    {
        public string CoursesTaught { get; set; }

        public Instructors(string Name, int Id, string coursestaught) : base(Name, Id)
        {
            CoursesTaught = coursestaught;
        }
    }

    class Staff : Person, IJobs // Staff stores StaffName, StaffId, JobId, JobTittle
    {
        public int JobId { get; set; } // JobId
        public string JobTittle { get; set; } // JobName
        public Staff(string Name, int Id, int jobId, string jobTittle) : base(Name, Id)
        {

            JobId = jobId;
            JobTittle = jobTittle;
        }

    }

    internal class Studentinfo
    {
        private Student[] students = new Student[10]; // Maximum of 10 Students Stored
        private int initialStudents = 0;

        public void AddStudent(string name, int id, int mark)
        {
            students[initialStudents] = new Student(name, id, mark);
            initialStudents++;
        }

        public void DisplayStudentDetails()
        {
            foreach (Student s in students) 
            {
                if (s != null) // Ensure null check to avoid accessing uninitialized elements
                {
                    Console.WriteLine($"Name: {s.Name}, ID: {s.Id}, Marks: {s.Marks}");
                }
            }
        }

    }

    internal class Instructorinfo
    {
        private Instructors[] instructor = new Instructors[10];
        private int initialInstructors = 0;

        public void AddInstructor(string instructorName, int instructorId, string coursesTaught)
        {
            instructor[initialInstructors] = new Instructors(instructorName, instructorId, coursesTaught);
            initialInstructors++;
        }

        public void DisplayInstructorDetails()
        {
            foreach(Instructors i in instructor)
            {
                if (i != null) // Ensure null check to avoid accessing uninitialized elements
                {
                    Console.WriteLine($"Name: {i.Name}, ID: {i.Id}, CoursesTaught: {i.CoursesTaught}");
                }
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--Welcome To Student Management System!--");

            // Student Section
            Console.WriteLine("--Student Details--");

            Console.Write("Enter Your Name: ");
            string name = Console.ReadLine().Trim();

            Console.Write("Enter Your Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Your Marks: ");
            int marks = Convert.ToInt32(Console.ReadLine());

            Studentinfo studentInfo = new Studentinfo();
            studentInfo.AddStudent(name, id, marks);

            Console.WriteLine("--Students--");
            studentInfo.DisplayStudentDetails();

            // Instructors Sections
            Console.WriteLine("--Instructors Details--");

            Console.Write("Instructor Name: ");
            string instructorName = Console.ReadLine().Trim();

            Console.Write("Instructor ID: ");
            int instructorId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Courses Taught: ");
            string coursesTaught = Console.ReadLine();

            Instructorinfo instructorInfo = new Instructorinfo();
            instructorInfo.AddInstructor(instructorName, instructorId, coursesTaught);

            Console.WriteLine("--Instructors--");
            instructorInfo.DisplayInstructorDetails();

        }
    }
}
