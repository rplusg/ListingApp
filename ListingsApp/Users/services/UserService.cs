
using System;
using System.Collections.Generic;
using System.Text;

namespace ListingsApp.Users
{
    class UserService
    {
        private UserRepository userRepositoryobj;
        public UserService()
        {
            userRepositoryobj = new UserRepository();
        }

        internal bool addUser(string user)
        {
            return userRepositoryobj.addUser(user);
        }

        internal bool isUserExisting(string v)
        {
            return userRepositoryobj.isUserExisting(v);
        }
    }
}
