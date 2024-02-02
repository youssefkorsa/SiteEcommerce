using System.Text.Json.Serialization;

namespace admin.Models
{
    public class Customer
    {
        [JsonPropertyName("id")]
       public  int Id { get; set; }
        [JsonPropertyName("firstName")]
        public  string FirstName { get; set; }
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
        
        [JsonPropertyName("createdDate")]
        public DateTime CreatedDate { get; set; }

        public Customer(string firstName,string lastName) { 
        FirstName = firstName;
        LastName = lastName;
        }
    }
}
