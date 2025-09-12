using System; 

namespace StudentManagementSystem
{
    public interface IMarkConversion
    {
        string MarkConvertor(int mark);
    }
    class Student
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public double Marks { get; set; }

        public Student(string name, int id, double marks)
        {
            Name = name;
            Id = id;
            Marks = marks;
        }
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
        private Student[] students = new Student[10];
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
            string name = Console.ReadLine();

            Console.Write("Enter Your Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Your Marks: ");
            int marks = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("--Student Grade--");

            Console.WriteLine("Grade Equivalent: ");

            StudentsDetails studentdetails =  new StudentsDetails();
            MarkConvert markconvertor = new MarkConvert();      
            

            studentdetails.AddStudent(name, id , marks);

            
        }
    }
}