using DemoMediatr.Services;

namespace DemoMediatr.Decorators
{
    public class LoggingUserServiceDecorator : IUserService
    {
        private IUserService _userService;

        public LoggingUserServiceDecorator(IUserService userService)
        {
            _userService = userService;
        }

        public void Create(CreateUserModel model)
        {
            Console.WriteLine($"Logging Create start at {DateTime.Now}");
            _userService.Create(model);
            Console.WriteLine($"Logging Create end at {DateTime.Now}");
        }

        public void Update(UpdateUserModel model)
        {
            Console.WriteLine($"Logging Update start at {DateTime.Now}");
            _userService.Update(model);
            Console.WriteLine($"Logging Update end at {DateTime.Now}");
        }
    }
}
