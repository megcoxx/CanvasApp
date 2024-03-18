using CanvasApp.Models;
using CanvasApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasApp.helpers
{
    public class PersonHelper
    {
        private PersonService studentSvc = PersonService.Current;
        public void AddStudent()
        {
            Console.WriteLine("Name:");
            var name = Console.ReadLine();

            Console.WriteLine("Classification:");
            var classification = Console.ReadLine();

            Console.WriteLine("Grade:");
            var grade = Console.ReadLine();

            Person myStudent;
            
            myStudent = new Person { Name = name, Classification = classification, Grade = grade };

            studentSvc.Add(myStudent);
        }

        public void UpdateInfo()
        {
            int count = 0;
            PersonService.Current.Students.ToList().ForEach(c => Console.WriteLine($"{++count}. {c}"));

            var choice = Console.ReadLine();

            if (int.TryParse(choice, out int intChoice))
            {
                var PersonToUpdate = PersonService.Current.Students.ElementAt(intChoice-1);

                Console.WriteLine("What is the new Name?");
                PersonToUpdate.Name = Console.ReadLine();
            }

        }
    
        public void DeletePerson()
        {
            int count = 0;
            PersonService.Current.Students.ToList().ForEach(c => Console.WriteLine($"{++count}. {c}"));

            var choice = Console.ReadLine();

            if (int.TryParse(choice, out int intChoice))
            {
                var PersonToDelete = PersonService.Current.Students.ElementAt(intChoice);

                studentSvc.Delete(PersonToDelete);
            }
        }

        public void ListPersons()
        {
            studentSvc.Students.ToList().ForEach(Console.WriteLine);
        }
    }
}