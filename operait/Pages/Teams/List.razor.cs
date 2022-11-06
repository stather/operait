using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using operait;
using operait.Shared;
using Blazorise;
using Blazorise.DataGrid;
using operait.Services;
using operait.Documents;

namespace operait.Pages.Teams
{

    public partial class List
    {
        private Modal? addTeamRef;
        private string name;
        private string description;
        private List<User> addedUsers = new List<User>();
        private List<User> allUsers;
        private string selectedUserId;

        private List<Team> teamList;
        private Team selectedTeam;

        [Inject]
        protected DatabaseService DatabaseService { get; set; }

        private Task ShowAddTeam()
        {
            return addTeamRef.Show();
        }

        private Task HideAddTeam()
        {
            return addTeamRef.Hide();

        }

        private async Task AddTeamAsync()
        {
            var newTeam = new operait.Documents.Team
            {
                Name = name,
                Description = description,
                Users = addedUsers.Select(x => x.Id).ToList(),
            };
            await DatabaseService.AddTeamAsync(newTeam);
            await addTeamRef.Hide();
        }

        protected override async Task OnInitializedAsync()
        {
            var res = await DatabaseService.GetAllUsersAsync();
            allUsers = res;
            var teams = await DatabaseService.GetAllTeamsAsync();
            teamList = teams;
        }

        void SelectedUserChanged(User user)
        {
            if (user != null)
            {
                addedUsers.Add(user);
            }
        }

        void TeamUpdated(Team team)
        {

        }

        void TeamSelected(Team team)
        {
            selectedTeam = team;
        }
        

    }
}