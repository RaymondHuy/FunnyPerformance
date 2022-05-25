using DemoMediatr.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoMediatr.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public ActionResult Create()
        {
            userService.Create(new CreateUserModel());
            return Ok();
        }

        [HttpPut]
        public ActionResult Update()
        {
            userService.Update(new UpdateUserModel());
            return Ok();
        }
    }
}
