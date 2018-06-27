using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;

namespace BL
{
     public class AService
     {
        public ADAL addDal;
        public AService()
        {
            addDal = new ADAL();
            addDal.UsersDAOMySQL();
        }

        public void addAdd(Add add)
        {
            addDal.addAdd(add);
        }

        public void deleteAdd(string addID)
        {
            addDal.deleteAdd(addID);
        }

        public string readAdd(string addID)
        {
            string adaad;
            adaad= addDal.readAdd(addID);
            return adaad;
        }

        public void updateAdd(string addID, string title, string description)
        {
            addDal.updateAdd(addID, title, description);
        }

        public bool doesItExist(string addID)
        {
            addDal.UsersDAOMySQL();
            return addDal.doesItExist(addID);
        }
    }
}
