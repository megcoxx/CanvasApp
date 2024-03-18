namespace CanvasApp.Models
{
    public class Assignment
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public int? TotalAvailablePoints { get; set; }

        public string? DueDate { get; set; }

        public Assignment()
        {

        }

        public Assignment(string name, string? description, int? totalpointavail, string? duedate)
        {
            Name = name;
            Description = description;
            TotalAvailablePoints = totalpointavail;
            DueDate = duedate;
        }

        public override string ToString()
        {
            return Name.ToString();
        }

    }
}