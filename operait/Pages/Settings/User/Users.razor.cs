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
using operait.Services;
using operait.Documents;
using Blazorise.DataGrid;

namespace operait.Pages.Settings.User
{
    public partial class Users
    {
        private Modal? addUserRef;

        private string? email;

        private string? name;
        private List<operait.Documents.User> userList { get; set; } = new List<Documents.User> { };

        private operait.Documents.User selectedUser;

        [Inject]
        protected DatabaseService DatabaseService { get; set; }

        private Task ShowAddUser()
        {
            return addUserRef.Show();
        }

        private Task HideAddUser()
        {
            return addUserRef.Hide();
        }

        private async Task AddUserAsync()
        {
            var newUser = new operait.Documents.User
            {
                Email = email,
                Name = name
            };
            await DatabaseService.AddUserAsync(newUser);
        }

        protected override async Task OnInitializedAsync()
        {
            var res = await DatabaseService.GetAllUsers();
            userList = res;
        }

        void UserUpdated(operait.Documents.User user)
        {

        }

    }
}