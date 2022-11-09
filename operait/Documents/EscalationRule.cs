namespace operait.Documents
{
    public enum EscalationAlertStatus
    {
        Acknowledged,
        Closed
    }
    public enum EscalationNotifyOptions
    {
        NotifyUser,
        NotifyOncallUsersInSchedule,
        RouteToTeam,
        NotifyNextUserInRotation,
        NotifyPreviousUserInRotation,
        NotifyALlTeamMembers,
        NotifyTeamAdmins,
        NotifyTeamUsers,
        NotifyRandomTeamMember
    }
    public class EscalationRule
    {
        public EscalationAlertStatus AlertStatus { get; set; }
        public int AfterCreation { get; set; }
        public EscalationNotifyOptions NotifyWho { get; set; }
        public string User { get; set; }
        public string Schedule { get; set; }
        public string Team { get; set; }

    }
}
