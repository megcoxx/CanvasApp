using CanvasApp.Services;
using CanvasApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasApp.helpers.old
{
    public class CourseHelper
    {
        private PersonService studentSvc = PersonService.Current;
        private CourseService CourseService = CourseService.Current;

        public CourseHelper() { }

        public void AddCourse()
        {
            Console.WriteLine("Choose a client to add a Course:");
            studentSvc.Students.ToList().ForEach(Console.WriteLine);

            var chosenStudent = studentSvc.Students.FirstOrDefault();
            Console.WriteLine("Name:");
            var name = Console.ReadLine();

            CourseService.Add(new Course { StudentId = chosenStudent?.Id ?? Guid.Empty, Name = name });
        }

        public void UpdateInfo()
        {
            int count = 0;
            CourseService.Current.Courses.ToList().ForEach(c => Console.WriteLine($"{++count}. {c}"));

            var choice = Console.ReadLine();

            if (int.TryParse(choice, out int intChoice))
            {
                var CourseToUpdate = CourseService.Current.Courses.ElementAt(intChoice);

                Console.WriteLine("What is the new Name?");
                CourseToUpdate.Name = Console.ReadLine();
            }

        }
    }
}
