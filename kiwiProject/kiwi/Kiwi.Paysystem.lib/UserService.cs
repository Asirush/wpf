using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiwi.Paysystem.lib
{
    public class UserService
    {
        EntityModel db = new EntityModel();
        public bool CheckUser(string login, string password)
        {
            return db.Users.Any(w => w.Login == login & w.Password == password);
        }
    }
}

