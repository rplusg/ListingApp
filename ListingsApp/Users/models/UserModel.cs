using System;
using System.Collections.Generic;
using System.Text;

namespace ListingsApp.Users
{
    class UserModel
    {
        private string userName;
        private bool isAdmin;

        public UserModel(string user, bool isAdmin)
        {
            this.userName = user;
            this.isAdmin = isAdmin;
        }

        public string UserName { get => userName; set => userName = value; }
        public bool IsAdmin { get => isAdmin; set => isAdmin = value; }
    }
}
