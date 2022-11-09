namespace operait.Documents
{
    public enum RotationType
    {
        Daily,
        Weekly,
        Custom
    }
    public enum TimeIntervalRestriction
    {
        TimeOfDay,
        WeekdayAndTimeOfDay
    }
    public class ShiftInterval
    {
        public DayOfWeek FromDay { get; set; }
        public DateTime FromTime { get; set; }
        public DayOfWeek ToDay { get; set; }
        public DateTime ToTime { get; set; }
    }
    public class Rotation
    {
        public string Name { get; set; }
        public List<string> Participants { get; set; } = new List<string>();
        public RotationType RotationType { get; set; }

        public DateTime StartOn { get; set; }
        public bool HasEndDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool RestrictToTimeIntervals { get; set; }
        public TimeIntervalRestriction RestrictionType { get; set; }
        public DateTime IntervalStart { get; set; }
        public DateTime IntervalEnd { get; set; }
        public List<ShiftInterval> Intervals { get; set; } = new List<ShiftInterval>();




    }
}
