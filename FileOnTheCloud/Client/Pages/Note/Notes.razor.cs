﻿using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using System;

namespace FileOnTheCloud.Client.Pages.Note
{
    public partial class Notes
    {
        List<FileOnTheCloud.Shared.DbModel.SavedFile> savedFiles = new List<FileOnTheCloud.Shared.DbModel.SavedFile>();

        [CascadingParameter]
        public Task<AuthenticationState> AuthState { get; set; }
      
        private string email;


        FileOnTheCloud.Shared.DbModel.User user = new();

        protected override async Task OnInitializedAsync()
        {
            var authstate = await AuthState;

            if (authstate.User.Identity.IsAuthenticated)
            {
                email = authstate.User.FindFirst(System.Security.Claims.ClaimTypes.Email).Value;

                string role = authstate.User.FindFirst(System.Security.Claims.ClaimTypes.Role).Value;

                string geturl = role == "admin" ? "api/savedfile/get" : $"api/savedfile/getbyuser/{email}";

                savedFiles = await helper.GetListTsAsync<FileOnTheCloud.Shared.DbModel.SavedFile>(geturl);

            }
        }

        private FileOnTheCloud.Shared.DbModel.SavedFile selectedItemSavedFile = null;

        private string searchStringSavedFile = string.Empty;
        private bool FilterFuncSavedFile(FileOnTheCloud.Shared.DbModel.SavedFile element) => FilterFuncSavedFile(element, searchStringSavedFile);

        private bool FilterFuncSavedFile(FileOnTheCloud.Shared.DbModel.SavedFile element, string searchStringsavedFile)
        {
            if (string.IsNullOrWhiteSpace(searchStringsavedFile))
                return true;
            if (element.filename.Contains(searchStringsavedFile, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.department.Contains(searchStringsavedFile, StringComparison.OrdinalIgnoreCase))
                return true; 
            if (element.grade.Contains(searchStringsavedFile, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.semester.Contains(searchStringsavedFile, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.midtermandfinal.Contains(searchStringsavedFile, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }
    }
}
