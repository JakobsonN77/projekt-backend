using System.Runtime.Serialization;

namespace WebApi.Models
{
    [DataContract]
    public class User
    {
        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Role { get; set; }

        [DataMember]
        public string EmailAddress { get; set; }

        public User(string firstName, string lastName, string role, string emailAddress)
        {
            FirstName = firstName;
            LastName = lastName;
            Role = role;
            EmailAddress = emailAddress;
        }
    }
}