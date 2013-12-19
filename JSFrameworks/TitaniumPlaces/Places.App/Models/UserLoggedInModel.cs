namespace Places.App.Models
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class UserLoggedInModel
    {
        [DataMember(Name = "nickname")]
        public string Nickname { get; set; }

        [DataMember(Name = "sessionKey")]        
        public string SessionKey { get; set; }
    }
}