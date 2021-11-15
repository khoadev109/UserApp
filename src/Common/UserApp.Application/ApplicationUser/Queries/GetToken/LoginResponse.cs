using UserApp.Application.Dto;

namespace UserApp.Application.ApplicationUser.Queries.GetToken
{
    public class LoginResponse
    {
        public ApplicationUserDto User { get; set; }

        public string Token { get; set; }
    }
}
