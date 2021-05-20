using System;
using System.Collections.Generic;
using System.Text;

namespace ListingsApp.Users
{
    class UserController
    {
        private UserService userServiceObj;
        public UserController()
        {
            userServiceObj = new UserService();
        }

        internal bool addUser(string user)
        {
            return userServiceObj.addUser(user);
        }

        internal bool isUserExisting(string v)
        {
            return userServiceObj.isUserExisting(v);
        }
    }
}
