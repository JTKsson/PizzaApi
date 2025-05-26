namespace CloudDB.Domain.DTO
{
    public class UserCreateDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    public class UserUpdateDTO
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    public class UserLoginDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UserGetDTO
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
