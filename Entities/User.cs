using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public abstract class User
    {
        private String userID;
        private String surname;
        private String name;
        private String password;
        private String role;

        public User(String userID,String name,String surname, String password, String role)
        {
            this.userID = userID;
            this.name = name;
            this.surname = surname;
            this.password = password;
            this.role = role;
        }

        public String getID()
        {
            return userID;
        }

        public String getName()
        {
            return name;
        }

        public String getPassword()
        {
            return password;
        }

        public String getRole()
        {
            return role;
        }

        public string getSurname()
        {
            return surname;
        }
    }
}
