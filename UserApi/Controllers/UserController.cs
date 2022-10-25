using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Abstractions;
using Models.Requests;
using Services.Interfaces;
using System.Net;
using UserApi.Responses;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsers();
                if (users == null || users.Count() == 0)
                    return Ok(new StandarResponse<List<User>>(HttpStatusCode.NotFound, null,"No Users"));
                return Ok(new StandarResponse<List<User>>(HttpStatusCode.OK, users,"Lista de usuarios"));
            }

            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            try
            {
                var user = await _userService.GetAllUsers(id);
                if (user == null)
                    return Ok(new StandarResponse<User>(HttpStatusCode.NotFound, null, "No User"));
                return Ok(new StandarResponse<User>(HttpStatusCode.OK, user, "Usuario"));
            }

            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostUser(CreateOrUpdateUserRequest request)
        {
            try
            {
                var response = await _userService.AddUser(request);
                if (response == null)
                {
                    return Ok(new StandarResponse<User>(HttpStatusCode.BadRequest, null, "Something went wrong"));
                }

                return Ok(new StandarResponse<User>(HttpStatusCode.OK, response, "User added succesfully"));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
