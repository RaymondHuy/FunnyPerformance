namespace DemoMediatr.Services
{
    public interface IUserService
    {
        void Create(CreateUserModel model);

        void Update(UpdateUserModel model);
    }

    public class UserService : IUserService
    {

        public void Create(CreateUserModel model)
        {
            Console.WriteLine("Core UserService Called Create");
        }

        public void Update(UpdateUserModel model)
        {
            Console.WriteLine("Core UserService Called Update");
        }
    }

    public class CreateUserModel
    {
    }

    public class UpdateUserModel
    {
    }

}
