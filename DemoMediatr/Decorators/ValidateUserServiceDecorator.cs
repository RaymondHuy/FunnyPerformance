using DemoMediatr.Services;

namespace DemoMediatr.Decorators
{
    public class ValidateUserServiceDecorator : IUserService
    {
        private readonly IUserService _userService;

        public ValidateUserServiceDecorator(IUserService userService)
        {
            _userService = userService;
        }

        public void Create(CreateUserModel model)
        {
            Console.WriteLine("Validation");
            _userService.Create(model);
        }

        public void Update(UpdateUserModel model)
        {
            Console.WriteLine("Validation");
            _userService.Update(model);
        }
    }
}
