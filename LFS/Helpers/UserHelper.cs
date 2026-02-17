using OmniGov.Core.Repositories;
using OmniGov.Core.Factories;
using System;
using System.Collections.Generic;

namespace LFS.Helpers
{
    public class UserHelper
    {
        public static UserHelper loggedUser;

        private Dictionary<string, string> userDt;

        internal int Id;
        internal string Prefix;
        internal string Suffix;
        internal string FirstName;
        internal string MiddleName;
        internal string LastName;
        internal string FullName;
        internal int? RoleId;
        internal string RoleName;
        internal string UserName;
        internal string Password;
        internal bool isSuper;
        internal string[] UserPriviledges;

        public UserHelper(Dictionary<string, string> userDt)
        {
            bool isValidRoleId = int.TryParse(userDt["roles_id"], out int roleId);

            this.userDt = userDt;
            Id = int.Parse(userDt["id"]);
            FullName = GetUserFullName(Id);
            Prefix = userDt["prefix"];
            Suffix = userDt["suffix"];
            FirstName = userDt["first_name"];
            MiddleName = userDt["mid_initial"];
            LastName = userDt["last_name"];
            UserName = userDt["username"];
            Password = userDt["password"];
            RoleId = isValidRoleId ? roleId : null;
            RoleName = userDt["role_name"].ToString();
            isSuper = Convert.ToByte(userDt["is_super"]) == 1;
            UserPriviledges = isValidRoleId ? PrivilegesHelper.UserPrivileges(Convert.ToInt32(roleId)) : [];
            loggedUser = this;
        }

        private string GetUserFullName(int userId)
        {
            var dictUser = Factory.UsersRepository().GetRecordByID(userId);
            return Helper.GenerateFullName(null, dictUser["first_name"], dictUser["mid_initial"], dictUser["last_name"], "");
        }
    }
}

