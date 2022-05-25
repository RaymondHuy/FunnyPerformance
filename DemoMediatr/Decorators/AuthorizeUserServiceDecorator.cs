using DemoMediatr.Services;

namespace DemoMediatr.Decorators
{
    public class AuthorizeUserServiceDecorator : IUserService
    {
        private readonly IUserService _userService;

        public AuthorizeUserServiceDecorator(IUserService userService)
        {
            _userService = userService;
        }

        public void Create(CreateUserModel model)
        {
            // Condition Authorize
            Console.WriteLine("Checking Authorization");
            Console.WriteLine("Authorization Permitted");
            _userService.Create(model);
        }

        public void Update(UpdateUserModel model)
        {
            // Condition Authorize
            Console.WriteLine("Checking Authorization");
            Console.WriteLine("Authorization Permitted");
            _userService.Update(model);
        }
    }
}
