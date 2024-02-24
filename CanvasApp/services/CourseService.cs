using CanvasApp.Models;

namespace CanvasApp.Services
{
    public class CourseService
    {
        private IList<Course> courses;

        private string? query;
        private static object _lock = new();
        private static CourseService? instance;
        public static CourseService Current
        {
            get
            {
                lock (_lock)
                {
                    instance ??= new CourseService();
                }
                return instance;
            }
        }

        public IEnumerable<Course> Courses
        {
            get
            {
                return courses.Where(
                    c =>
                        c.Name.ToUpper().Contains(query ?? string.Empty)
                        || c.Code.ToUpper().Contains(query ?? string.Empty));
            }
        }

        private CourseService()
        {
            courses = new List<Course>();
        }

        public IEnumerable<Course> Search(string query)
        {
            this.query = query;
            return Courses;
        }

        public void Add(Course course)
        {
            courses.Add(course);
        }

        public void Delete(Course courseToDelete)
        {
            courses.Remove(courseToDelete);
        }
    }
}