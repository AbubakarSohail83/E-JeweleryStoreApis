using MODEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IManager
{
    public interface UserIManager
    {
        bool addUser(User user);
        List<User> getUsers();

        bool updateUser(User user);
        bool getUser(string email);

    }
}
