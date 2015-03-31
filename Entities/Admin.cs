using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class Admin : User
    {
         public Admin(string userID, 
                        string username, 
                        string surname,
                        string passsword,
                        string role):base(userID,username,surname,passsword,role)
        {
            
        }
    }
}
