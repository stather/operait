namespace operait.Documents
{
    public class Schedule
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";

        public TimeZone TimeZone { get; set; } = TimeZone.CurrentTimeZone;

        public bool Enabled { get; set; }
        public List<Rotation> Rotations { get; set; }
        public List<Override> Overrides { get; set; }

    }
}
