namespace Places.App.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public class UserEditModel
    {
        [DataMember(Name="id")]
        public int Id { get; set; }

        [DataMember(Name = "nickname")]
        public string Nickname { get; set; }

        [DataMember(Name = "role")]
        public int Role { get; set; }
    }
}