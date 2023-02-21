namespace operait.Documents
{
    public class Schedule
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";

        public TimeZoneInfo TimeZone { get; set; } = TimeZoneInfo.Local;

        public bool Enabled { get; set; }
        public List<Rotation> Rotations { get; set; } = new List<Rotation>();
        public List<Override> Overrides { get; set; } = new List<Override>();

    }
}
