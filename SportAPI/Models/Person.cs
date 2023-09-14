using DAL.Entities;
using System.Reflection.Metadata.Ecma335;

namespace SportAPI.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Mail { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string? Password_reset_token { get; set; }
        public string Auth_key { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public bool Is_validate { get; set; }
        public int Id_type_person { get; set; }
        public int Id_country { get; set; }


        public string? Token { get; set; }
    }
}
