namespace FanApp.Common.Models.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
    }
}
