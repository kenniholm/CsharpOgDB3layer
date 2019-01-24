using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpOgDB3layer
{
    public class Controller
    {
        DBconnector dbcon = new DBconnector();
        public void InsertPet(string PetName, string PetType, string PetBreed, string PetDOB, string PetWeight, string OwnerID)
        {
            dbcon.InsertPet(PetName, PetType, PetBreed, PetDOB, PetWeight, OwnerID);
        }
        public List<string> GetAllPets()
        {
            return dbcon.GetAllPets();
        }
    }
}
