namespace PlayZone.PL.ViewModels
{
    public class GameViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Cover { get; set; }

        public string CategoryName { get; set; }

        public List<string> Devices { get; set; } = new();
    }
}
