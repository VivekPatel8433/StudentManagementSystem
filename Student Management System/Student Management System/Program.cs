using System; 

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

        public Person (string name, int id)
        {
            Name = name;
            Id = id;
        }

    }


    class Student : Person // Student is a person 
    {
        public int Marks { get; set; }
        public Student(string Name, int Id, int marks) : base(Name, Id) 
        {
            Marks = Marks;
        }      
    }

    class Instructors: Person // Instructors are person
    {
        public string CoursesTaught{ get; set; }

        public Instructors(string Name, int Id, string coursestaught): base(Name, Id)
        {
            CoursesTaught = coursestaught;
        }
    }

    class Staff
    {

    }
    class MarkConvert : IMarkConversion
    {
        public virtual string MarkConvertor(int marks)
        {

            if (marks >= 90) return "A";
            if (marks >= 75) return "B";
            if (marks >= 60) return "C";
            if (marks >= 50) return "D";
            return "F";

        }
    }


    internal class StudentsDetails
    {
        private Student[] students = new Student[10]; // Maximum of 10 Students Stored
        private int initialStudents = 0;

        public void AddStudent(string name, int id, int mark)
        {
            students[initialStudents] = new Student(name, id, mark);
            initialStudents++;
        }
     
    }

    
class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--Welcome To Student Management System!--");

            Console.Write("Enter Your Name: ");
            string name = Console.ReadLine().Trim();

            Console.Write("Enter Your Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Your Marks: ");
            int marks = Convert.ToInt32(Console.ReadLine());

            


            StudentsDetails studentdetails =  new StudentsDetails();
            MarkConvert markconvertor = new MarkConvert();

            Console.WriteLine("--Student Grade--");
            Console.WriteLine(markconvertor.MarkConvertor(marks));


            studentdetails.AddStudent(name, id , marks);
            

        }
    }
}