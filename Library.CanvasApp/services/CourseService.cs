using CanvasApp.Models;

namespace CanvasApp.Services
{

    public class CourseService
    {
        private static CourseService? instance;
        public static CourseService Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new CourseService();
                }
                return instance;
            }
        }

        private IList<Course> courses;

        public IEnumerable<Course> Courses
        {
            get
            {
                return courses;
            }
        }
        private CourseService()
        {
            courses = new List<Course>();
        }

        // public IEnumerable<Course> GetByStudent(Guid studentId) {
        //     return courses.Where(p => p.StudentId == studentId);
        // }

        public void Add(Course course)
        {
            courses.Add(course);
        }
    }

}