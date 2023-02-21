namespace operait.Documents
{
    public class Override
    {
        public string Participant { get; set; }
        public List<string> Rotations { get; set; } = new List<string>();

        public DateTime StartsOn { get; set; }
        public DateTime EndsOn { get; set; }

    }
}
