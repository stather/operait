namespace operait.Documents
{
    public enum RoutingMatch
    {
        AllAlerts,
        OneOrMoreConditions,
        AllConditions
    }
    public enum RoutingItem
    {
        Actions,
        Alias,
        Description,
        Entity,
        Details,
        DetailsKV,
        Message,
        Priority,
        Responders,
        Source,
        Tags
    }
    public enum ConditionOperator
    {
        Regex,
        Contains,
        IsEmpty,
        StartsWith,
        EndsWith,
        Equals,
        EqualsIgnoreWhiteSpace,
        ContainsKey,
        ContainsValue,
        GreaterThan,
        LessThan
    }


    public class RoutingCondition
    {
        public static Dictionary<RoutingItem,List<ConditionOperator>> AllowedOperators = new Dictionary<RoutingItem, List<ConditionOperator>> 
        {
            {RoutingItem.Actions,new List<ConditionOperator>{ConditionOperator.Regex,ConditionOperator.Contains,ConditionOperator.IsEmpty  } },
            {RoutingItem.Alias, new List<ConditionOperator>{ConditionOperator.Regex,ConditionOperator.Equals, ConditionOperator.Contains, ConditionOperator.StartsWith, ConditionOperator.EndsWith, ConditionOperator.IsEmpty, ConditionOperator.EqualsIgnoreWhiteSpace } },
            {RoutingItem.Description, new List<ConditionOperator>{ConditionOperator.Regex,ConditionOperator.Equals, ConditionOperator.Contains, ConditionOperator.StartsWith, ConditionOperator.EndsWith, ConditionOperator.IsEmpty, ConditionOperator.EqualsIgnoreWhiteSpace } },
            {RoutingItem.Entity, new List<ConditionOperator>{ConditionOperator.Regex,ConditionOperator.Equals, ConditionOperator.Contains, ConditionOperator.StartsWith, ConditionOperator.EndsWith, ConditionOperator.IsEmpty, ConditionOperator.EqualsIgnoreWhiteSpace } },
            {RoutingItem.Details, new List<ConditionOperator>{ConditionOperator.Contains, ConditionOperator.ContainsKey, ConditionOperator.ContainsValue, ConditionOperator.IsEmpty } },
            {RoutingItem.DetailsKV, new List<ConditionOperator>{ConditionOperator.Regex,ConditionOperator.Equals, ConditionOperator.Contains, ConditionOperator.StartsWith, ConditionOperator.EndsWith, ConditionOperator.IsEmpty, ConditionOperator.EqualsIgnoreWhiteSpace } },
            {RoutingItem.Message, new List<ConditionOperator>{ConditionOperator.Regex,ConditionOperator.Equals, ConditionOperator.Contains, ConditionOperator.StartsWith, ConditionOperator.EndsWith, ConditionOperator.IsEmpty, ConditionOperator.EqualsIgnoreWhiteSpace } },
            {RoutingItem.Priority, new List<ConditionOperator>{ConditionOperator.Equals, ConditionOperator.GreaterThan, ConditionOperator.LessThan } },
            {RoutingItem.Responders, new List<ConditionOperator>{ConditionOperator.Regex, ConditionOperator.Contains, ConditionOperator.IsEmpty } },
            {RoutingItem.Source, new List<ConditionOperator>{ConditionOperator.Regex,ConditionOperator.Equals, ConditionOperator.Contains, ConditionOperator.StartsWith, ConditionOperator.EndsWith, ConditionOperator.IsEmpty, ConditionOperator.EqualsIgnoreWhiteSpace } },
            {RoutingItem.Tags, new List<ConditionOperator>{ConditionOperator.Regex, ConditionOperator.Contains, ConditionOperator.IsEmpty } },
        }; 
        public RoutingItem Item { get; set; }
        public string Key { get; set; }
        public bool NotCondition { get; set; }
        public ConditionOperator Operator { get; set; }
        public string Value { get; set; }


    }
    public enum RoutingTargetType
    {
        Other,
        Schedule,
        Escalation
    }
    public class RoutingRule
    {
        public string Name { get; set; }
        public RoutingMatch RoutingMatch { get; set; }
        public List<RoutingCondition> Conditions { get; set; } = new List<RoutingCondition>();

        public bool RestrictToTimeIntervals { get; set; }
        public TimeIntervalRestriction RestrictionType { get; set; }
        public DateTime IntervalStart { get; set; }
        public DateTime IntervalEnd { get; set; }
        public List<ShiftInterval> Intervals { get; set; } = new List<ShiftInterval>();
        public RoutingTargetType TargetType { get; set; }
        public string Target { get; set; }

    }
}
