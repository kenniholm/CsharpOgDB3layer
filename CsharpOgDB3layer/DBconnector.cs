using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CsharpOgDB3layer
{
    public class DBconnector : IPublisher, ISubscriber
    {
        List<ISubscriber> subscribers = new List<ISubscriber>();
        private static string connectionString = "Server=EALSQL1.eal.local; Database= B_DB16_2018; User Id=B_STUDENT16; Password=B_OPENDB16;";

        public void InsertPet(string PetName, string PetType, string PetBreed, string PetDOB, string PetWeight, string OwnerID)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            string Data = $"{PetName};{PetType};{PetBreed};{PetDOB};{PetWeight};{OwnerID}";

            parameters["@PetName"] = PetName;

            parameters["@PetType"] = PetType;

            parameters["@PetBreed"] = PetBreed;

            parameters["@PetDOB"] = PetDOB;

            parameters["@PetWeight"] = PetWeight;

            parameters["@OwnerID"] = OwnerID;

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                try
                {
                    connect.Open();
                    SqlCommand insertPet = new SqlCommand("InsertPet", connect);
                    insertPet.CommandType = CommandType.StoredProcedure;
                    foreach (var key in parameters.Keys)
                    {
                        if (key.Equals("@PetDOB"))
                        {
                            insertPet.Parameters.Add(new SqlParameter(key, Convert.ToDateTime(parameters[key])));
                        }
                        else
                        {
                            insertPet.Parameters.Add(new SqlParameter(key, parameters[key]));
                        }
                    }
                    insertPet.ExecuteNonQuery();
                    NotifySubscribers(Data);
                }
                catch (SqlException e)
                {
                    throw new ArgumentException("Der gik noget galt" + e.Message);
                }
            }

        }
        public List<string> GetAllPets()
        {
            string readerText = string.Empty;
            List<string> data = new List<string>();
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                try
                {
                    connect.Open();
                    SqlCommand getPets = new SqlCommand("GetPets", connect);
                    getPets.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = getPets.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string petId = reader["PetID"].ToString();
                            string petName = reader["PetName"].ToString();
                            string petType = reader["PetType"].ToString();
                            string petBreed = reader["PetBreed"].ToString();
                            string petDOB = reader["PetDOB"].ToString();
                            string petWeight = reader["PetWeight"].ToString();
                            string ownerId = reader["OwnerID"].ToString();
                            data.Add(readerText = petId + "/" + petName + "/" + petType + "/" + petBreed + "/" + petDOB + "/" +
                                petWeight + "/" + ownerId);
                        }
                    }
                }
                catch (SqlException e)
                {
                    throw new ArgumentException("Der gik noget galt" + e.Message);
                }
                return data;
            }
            
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

        public void Update(IPublisher publisher, string message)
        {
            NotifySubscribers(message);
        }
    }
}
