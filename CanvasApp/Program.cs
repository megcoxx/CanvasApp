using CanvasApp.Models;
using System;
using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;
using CanvasApp.helpers;
using CanvasApp.Services;

namespace CanvasApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool stillOn = true;
            int optionPicked;
            //create ListStudents database of all students
            List<Person> ListStudents = [];
            //create ListCourses database of all courses
            List<Course> ListCourses = new();
            while (stillOn.Equals(true))
            {
                Console.WriteLine("Options: ");
                Console.WriteLine("1. Create a course.");
                Console.WriteLine("2. Create a student.");
                Console.WriteLine("3. Add a student to a course.");
                Console.WriteLine("4. Remove a student from a course.");
                Console.WriteLine("5. View all courses.");
                Console.WriteLine("6. Search for a course.");
                Console.WriteLine("7. View all students.");
                Console.WriteLine("8. Search for a student.");
                Console.WriteLine("9. View courses a student is enrolled in.");
                Console.WriteLine("10. Update a course's information.");
                Console.WriteLine("11. Update a student's information.");
                Console.WriteLine("12. Add a new assignment to a course.");
                Console.WriteLine("13. Quit Program.");
                Console.WriteLine("");
                Console.WriteLine("Please choose your option: ");
                optionPicked = Int32.Parse(Console.ReadLine());

                var studentHlpr = new PersonHelper();
                var courseHlpr = new CourseHelper();
                switch (optionPicked)
                {
                    case 1:
                        AddCourse(ListCourses);
                        break;
                    case 2:
                        studentHlpr.AddStudent();
                        break;
                    case 3:
                        AddStudenttoCourse(ListStudents, ListCourses);
                        break;
                    case 4:
                        studentHlpr.DeletePerson();
                        break;
                    case 5:
                        WriteCourses(ListCourses);
                        break;
                    case 6:
                        SearchCourses(ListCourses);
                        break;
                    case 7:
                        WriteStudents(ListStudents);
                        break;
                    case 8:
                        SearchAllStudents(ListStudents);
                        break;
                    case 9:
                        StudentCourses(ListCourses);
                        break;
                    case 10:
                        UpdateCourseInfo(ListCourses);
                        break;
                    case 11:
                        studentHlpr.UpdateInfo();
                        break;
                    case 12:
                        CreateAddAssignment(ListCourses);
                        break;
                    case 13:
                        stillOn = false;
                        break;
                }
            }
        }

        //Create a course and add it to a list of courses
        public static void AddCourse(List<Course> listCourses)
        {
            Console.WriteLine("Please enter the name of the course: ");
            string? N = Console.ReadLine();
            while (N == null)
            {
                Console.WriteLine("Please enter a valid name: ");
                N = Console.ReadLine();
            }
            Console.WriteLine("Please enter the code asssociated with the course: ");
            string? C = Console.ReadLine();
            Console.WriteLine("Please provide a description of the course: ");
            string? D = Console.ReadLine();

            Course newCourse = new(C, N, D);
            listCourses.Add(newCourse);
            Console.WriteLine("");
        }
        // Create a student and add it to a list of students
        public static void AddStudent(List<Person> listStudents)
        {
            Console.WriteLine("Please enter the name of the student: ");
            string? N = Console.ReadLine();
            while (N == null)
            {
                Console.WriteLine("Please enter a valid name: ");
                N = Console.ReadLine();
            }
            Console.WriteLine("Please enter the classification level of the student: ");
            string? C = Console.ReadLine();

            Person newStudent = new(N, C);
            listStudents.Add(newStudent);
            Console.WriteLine("");
        }

        // Add a student from the list of students to a specific
        //       course
        public static void AddStudenttoCourse(List<Person> listStudents, List<Course> listCourses)
        {
            int indexCourse = 0;
            int indexStudent = 0;
            bool foundCourse = false;
            bool foundStudent = false;
            while (foundCourse.Equals(false))
            {
                Console.WriteLine("What course would you like to add a student to? ");
                string? C = Console.ReadLine();
                foreach (var item in listCourses)
                {
                    if (item.Name.Equals(C))
                    {
                        foundCourse = true;
                        break;
                    }
                    else
                    {
                        indexCourse++;
                    }
                }
            }
            Console.Write("You want to add a student to ");
            Console.WriteLine(listCourses[indexCourse].Name);
            while (foundStudent.Equals(false))
            {
                Console.WriteLine("Which student would you like to add to this course?");
                string? S = Console.ReadLine();
                while (S == null)
                {
                    Console.WriteLine("Please enter a valid name: ");
                    S = Console.ReadLine();
                }
                foreach (var item in listStudents)
                {
                    if (item.Name.Equals(S))
                    {
                        foundStudent = true;
                        listCourses[indexCourse].Roster.Add(item);
                        break;
                    }
                    else
                    {
                        indexStudent++;
                    }
                }
            }
            Console.Write("Adding ");
            Console.Write(listStudents[indexStudent].Name);
            Console.Write(" to ");
            Console.WriteLine(listCourses[indexCourse].Name);
            Console.WriteLine("");
        }
        // Create an assignment and add it to the list of 
        //       assignments for a course
        public static void CreateAddAssignment(List<Course> listCourses)
        {
            int indexCourse = 0;
            bool foundCourse = false;
            while (foundCourse.Equals(false))
            {
                Console.WriteLine("What course would you like to add an assignment to? ");
                string? C = Console.ReadLine();
                foreach (var item in listCourses)
                {
                    if (item.Name.Equals(C))
                    {
                        foundCourse = true;
                        break;
                    }
                    else
                    {
                        indexCourse++;
                    }
                }
            }
            Assignment addition = new Assignment();
            Console.WriteLine("What is the assignment's title?");
            addition.Name = Console.ReadLine();
            Console.WriteLine("What is the description of the assignment?");
            addition.Description = Console.ReadLine();
            Console.WriteLine("How many total points are available?");
            addition.TotalAvailablePoints = Int32.Parse(Console.ReadLine());
            Console.WriteLine("When is the due date of the assignment?");
            addition.DueDate = Console.ReadLine();
            listCourses[indexCourse].Assignments.Add(addition);
            Console.WriteLine("");
        }

        // List all courses
        public static void WriteCourses(List<Course> courses)
        {
            foreach (var item in courses)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("");
        }
        // List all students
        public static void WriteStudents(List<Person> students)
        {
            foreach (var item in students)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("");
        }
        // List all courses a student is taking
        public static void StudentCourses(List<Course> courseList)
        {
            Console.WriteLine("Search for a student's courseload. Enter the student's name: ");
            String studentName = Console.ReadLine();
            foreach (var item in courseList)
            {
                item.SearchName(studentName);
            }
            Console.WriteLine("");
        }
        // Search for courses by name or description        
        public static void SearchCourses(List<Course> courseList)
        {
            Console.WriteLine("Search for a course here: ");
            String searchCriteria = Console.ReadLine();
            foreach (var item in courseList)
            {
                item.SearchCourses(searchCriteria);
            }
            Console.WriteLine("");
        }
        // Search for a student by name
        public static void SearchAllStudents(List<Person> studentList)
        {
            Console.WriteLine("Search for a student by name: ");
            String searchCriteria = Console.ReadLine();
            foreach (var item in studentList)
            {
                item.SearchStudentList(searchCriteria);
            }
            Console.WriteLine("");
        }

        public static void RemoveStudentFromCourse(List<Course> courseList)
        {
            Console.WriteLine("Which course would you like to remove a student from?");
            String courseName = Console.ReadLine();
            Console.WriteLine("Enter the student's name you would like to remove from the course: ");
            String studentName = Console.ReadLine();

            foreach (var item in courseList)
            {
                if (item.Name.Equals(courseName))
                {
                    item.RemoveStudent(studentName);
                }
            }
            Console.WriteLine("");
        }
        // Update a course’s information        
        public static void UpdateCourseInfo(List<Course> courseList)
        {
            Console.WriteLine("Please enter the name of the course you would like to update: ");
            String courseName = Console.ReadLine();
            foreach (var item in courseList)
            {
                if (item.Name.Equals(courseName))
                {
                    item.UpdateInfo();
                }
            }
        }
        // Update a student’s information        
        // public static void UpdateStudentInfo(List<Person> studentList)
        // {
        //     Console.WriteLine("Please enter the name of the student you would like to update: ");
        //     String studentName = Console.ReadLine();
        //     foreach (var item in studentList)
        //     {
        //         if (item.Name.Equals(studentName))
        //         {
        //             item.UpdateInfo();
        //         }
        //     }
        // }
    }
}
