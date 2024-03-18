namespace CanvasApp.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public string? Classification { get; set; }

        public string? Grade { get; set; }

        public Person() { }
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

        
    }

}