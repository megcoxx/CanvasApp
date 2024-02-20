namespace CanvasApp.Models
{
    public class Person
    {
        public string Name { get; set; }

        public string? Classification { get; set; }

        public string? Grade { get; set; }

        Person()
        {
            Name = "N/A";
        }
        public Person(string name, string? classlvl)
        {
            Name = name;
            Classification = classlvl;
        }

        public override string ToString()
        {
            return Name;
        }

        public void SearchStudentList(string searched)
        {
            if (Name.Equals(searched))
            {
                Console.WriteLine(this);
                Console.WriteLine("Year: " + Classification);
                Console.WriteLine("Grade: " + Grade);
                Console.WriteLine("");
            }
        }

        public void UpdateInfo()
        {
            Console.WriteLine("Please choose what you would like to update: ");
            Console.WriteLine("STUDENT'S CLASS");
            Console.WriteLine("STUDENT'S NAME");
            Console.WriteLine("STUDENT'S GRADE");
            String changeOption = Console.ReadLine().ToUpper();
            Console.WriteLine("You chose " + changeOption + ". Please enter what you would like to change the current " + changeOption + " to.");
            String newChange = Console.ReadLine();
            switch (changeOption)
            {
                case "STUDENT'S CLASS":
                case "CLASS":
                    Classification = newChange;
                    break;
                case "STUDENT'S NAME":
                case "NAME":
                    Name = newChange;
                    break;
                case "STUDENT'S GRADE":
                case "GRADE":
                    Grade = newChange;
                    break;
            }
            Console.WriteLine("");
        }
    }

}