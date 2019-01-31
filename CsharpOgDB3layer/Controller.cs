using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpOgDB3layer
{
    public class Controller : IPublisher, ISubscriber
    {
        DBconnector dbcon = new DBconnector();
        List<ISubscriber> subscribers = new List<ISubscriber>();

        public Controller()
        {
            dbcon.RegisterSubscriber(this);
        }
        public void InsertPet(string PetName, string PetType, string PetBreed, string PetDOB, string PetWeight, string OwnerID)
        {
            dbcon.InsertPet(PetName, PetType, PetBreed, PetDOB, PetWeight, OwnerID);
        }
        public List<string> GetAllPets()
        {
            return dbcon.GetAllPets();
        }

        public void Update(IPublisher publisher, string message)
        {
            NotifySubscribers(message);
        }

        public void RegisterSubscriber(ISubscriber observer)
        {
            subscribers.Add(observer);
        }

        public void RemoveSubscriber(ISubscriber observer)
        {
            subscribers.Remove(observer);
        }

        public void NotifySubscribers(string message)
        {
            foreach (ISubscriber sub in subscribers)
            {
                sub.Update(this, message);
            }
        }
    }
}
