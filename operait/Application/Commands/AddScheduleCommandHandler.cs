using MediatR;
using operait.Documents;
using operait.Services;

namespace operait.Application.Commands
{
    public class AddScheduleCommandHandler
        : IRequestHandler<AddScheduleCommand, bool>
    {
        readonly DatabaseService databaseService;
        public AddScheduleCommandHandler(DatabaseService databaseService)
        {
            this.databaseService = databaseService;
        }
        public async Task<bool> Handle(AddScheduleCommand request, CancellationToken cancellationToken)
        {
            var s = new Schedule
            {
                Name = request.Name,
                Description = request.Description,
                Enabled = request.Enabled
            };
            var team = await databaseService.GetTeamAsync(request.TeamId);
            team.Schedules.Add(s);
            await databaseService.UpdateTeamAsync(team);
            return true;
        }
    }
}
