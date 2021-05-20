using System;
using System.Collections.Generic;
using System.Text;

namespace ListingsApp.Users
{
    class UserRepository
    {
        Dictionary<string, UserModel> users= new Dictionary<string, UserModel>(StringComparer.InvariantCultureIgnoreCase);
        internal bool addUser(string user, bool isAdmin = false)
        {
            if (users.ContainsKey(user.ToLower()))
            {
                return false; //Or should i throw an exception?
            }
            else
            {
                UserModel um = new UserModel(user, isAdmin);
                users.Add(user.ToLower(), um);
            }
            return true;
        }

        internal bool isUserExisting(string v)
        {
            return users.ContainsKey(v);
        }

        internal Dictionary<string, UserModel> getAllUsers()
        {
            return users;
        }
    }
}
