namespace CanvasApp.Models
{
    public class Course
    {

        public string? Code { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public List<Person> Roster;

        public List<Assignment> Assignments;

        public List<Module> Modules;

        public Course()
        {
            Roster = new List<Person>();
            Assignments = new List<Assignment>();
            Modules = new List<Module>();
        }

        public Course(string? code, string name, string? description)
        {
            Code = code;
            Name = name;
            Description = description;
            Roster = new List<Person>();
            Assignments = new List<Assignment>();
            Modules = new List<Module>();
        }

        // Remove a student from a course’s roster
        public void RemoveStudent(string? name)
        {
            for (int i = 0; i < Roster.Count; i++)
            {
                Person? item = Roster[i];
                if (item.Name.Equals(name))
                {
                    Roster.Remove(item);
                }
            }
        }

        public override String ToString()
        {
            return Name + " " + Code;

        }

        public void SearchName(String searched)
        {
            foreach (var item in Roster)
            {
                if (item.Name.Equals(searched))
                {
                    Console.WriteLine(this);
                    Console.WriteLine("");
                }
            }
        }

        public void SearchCourses(String searched)
        {
            if (Name.Equals(searched) || Description.Equals(searched))
            {
                Console.WriteLine(this);
                Console.WriteLine(Description);
                foreach(var item in Roster){
                    Console.WriteLine(item);
                }
                foreach(var item in Assignments){
                    Console.WriteLine(item);
                }
                foreach(var item in Modules){
                    Console.WriteLine(item);
                }
                Console.WriteLine("");
            }
        }

        public void UpdateInfo()
        {
            Console.WriteLine("Please choose what you would like to update: ");
            Console.WriteLine("COURSE CODE");
            Console.WriteLine("COURSE NAME");
            Console.WriteLine("COURSE DESCRIPTION");
            String changeOption = Console.ReadLine().ToUpper();
            Console.WriteLine("You chose " + changeOption + ". Please enter what you would like to change the current " + changeOption + " to.");
            String newChange = Console.ReadLine();
            switch (changeOption)
            {
                case "COURSE CODE":
                case "CODE":
                    Code = newChange;
                    break;
                case "COURSE NAME":
                case "NAME":
                    Name = newChange;
                    break;
                case "COURSE DESCRIPTION":
                case "DESCRIPTION":
                    Description = newChange;
                    break;
            }
            Console.WriteLine("");
        }
    }
}
