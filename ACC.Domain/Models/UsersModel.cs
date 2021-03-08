using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class UsersModel
    {
        public int Id { get; set; }
        public byte RoleId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string MidInitial { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

    }
}
