using MediatR;
using System.Runtime.Serialization;

namespace operait.Application.Commands
{
    [DataContract]
    public class AddScheduleCommand
        : IRequest<bool>
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public bool Enabled { get; set; }
        [DataMember]
        public string TeamId { get; set; }

        public AddScheduleCommand( string name, string description, bool enabled, string teamId) 
            :this()
        { 
            Name= name;
            Description= description;
            Enabled= enabled;
            TeamId= teamId;
        }

        public AddScheduleCommand()
        {
        }
    }
}
