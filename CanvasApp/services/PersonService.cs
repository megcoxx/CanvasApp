using CanvasApp.Models;

namespace CanvasApp.Services
{
    public class PersonService
    {
        private IList<Person> students;

        private string? query;
        private static object _lock = new();
        private static PersonService? instance;
        public static PersonService Current
        {
            get
            {
                lock (_lock)
                {
                    instance ??= new PersonService();
                }
                return instance;
            }
        }

        public IEnumerable<Person> Students
        {
            get
            {
                return students.Where(
                    c =>
                        c.Name.ToUpper().Contains(query ?? string.Empty));
            }
        }

        private PersonService()
        {
            students = new List<Person>();
        }

        public IEnumerable<Person> Search(string query)
        {
            this.query = query;
            return Students;
        }

        public void Add(Person student)
        {
            students.Add(student);
        }

        public void Delete(Person studentToDelete)
        {
            students.Remove(studentToDelete);
        }
    }
}