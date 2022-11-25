using System;
using System.Collections.Generic;

namespace operait.Documents
{
    public enum RotationType
    {
        Daily,
        Weekly,
        Custom
    }
    public enum ShiftUnit
    {
        Hours,
        Days,
        Weeks
    }

    public enum TimeIntervalRestrictionType
    {
        TimeOfDay,
        WeekdayAndTimeOfDay
    }

    public class TimeIntervalRestriction
    {
        public TimeIntervalRestrictionType RestrictionType { get; set; }
        public TimeSpan? IntervalStart { get; set; }
        public TimeSpan? IntervalEnd { get; set; }
        public List<ShiftInterval> Intervals { get; set; } = new List<ShiftInterval>();
    }
    public class ShiftInterval
    {
        public DayOfWeek FromDay { get; set; } = DayOfWeek.Monday;
        public TimeSpan? FromTime { get; set; }
        public DayOfWeek ToDay { get; set; } = DayOfWeek.Monday;
        public TimeSpan? ToTime { get; set; }
    }
    public class Rotation
    {
        public string Name { get; set; }
        public List<TeamMember> Participants { get; set; } = new List<TeamMember>();
        public RotationType RotationType { get; set; }
        public int ShiftLength { get; set; }
        public ShiftUnit ShiftUnit { get; set; }
        public DateTime? StartOnDate { get; set; } = DateTime.Today;
        public TimeSpan? StartOnTime { get; set; }
        public bool HasEndDate { get; set; }
        public DateTime? EndDate { get; set; } = DateTime.Today;
        public TimeSpan? EndTime { get; set; }
        public bool RestrictToTimeIntervals { get; set; }
        public TimeIntervalRestriction TimeIntervalRestriction { get; set; } = new TimeIntervalRestriction();




    }
}
