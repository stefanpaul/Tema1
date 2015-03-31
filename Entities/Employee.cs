using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class Employee : User
    {
        public int adds = 0;
        public Employee(string userID, 
                        string username, 
                        string surname,
                        string passsword,
                        string role):base(userID,username,surname,passsword,role)
        {
            
        }

        public void addAdd()
        {
            adds++;
        }

        public int getAdds()
        {
            return adds;
        }
    }
}
