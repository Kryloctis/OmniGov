using ACC.Data;
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
        internal int RoleId;
        internal string RoleName;
        internal string UserName;
        internal string Password;
        internal string[] UserPriviledges;

        public UserHelper(Dictionary<string, string> userDt)
        {
            this.userDt = userDt;
            Id = int.Parse(userDt["id"]);
            FullName = GetUserFullName(Id);

            var dictRole = AccFactory.UsersRepository().GetRecordByID(Id);

            RoleId = int.Parse(dictRole["roles_id"]);
            RoleName = dictRole["role_name"].ToString();
            UserPriviledges = PrivilegesHelper.UserPrivileges(RoleId);
            loggedUser = this;
        }

        private string GetUserFullName(int userId)
        {
            var dictUser = AccFactory.UsersRepository().GetRecordByID(userId);
            return Helper.GenerateFullName(null, dictUser["first_name"], dictUser["mid_initial"], dictUser["last_name"], "");
        }
    }
}