using System.Text.Json.Serialization;

namespace UsersBack.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Date { get; set; }
        public string Adress { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
    }
}
