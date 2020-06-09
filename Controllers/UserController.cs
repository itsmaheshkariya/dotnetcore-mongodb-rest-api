using System.Collections.Generic;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController:ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService){
            _userService = userService;
        }
        [HttpGet]
        public ActionResult<List<User>> GetUsers()=>_userService.GetUsers();

        [HttpGet("{id:length(24)}",Name="GetUser")]
        public ActionResult<User> GetUser(string id)=>_userService.GetUser(id);

        [HttpPost]
        public ActionResult<User> PostUser(User user){
                _userService.PostUser(user);
                return user;
        }
        [HttpPut("{id:length(24)}")]
        public ActionResult<User> PutUser(string id, User user){
            _userService.PutUser(id,user);
            return user;
        }
        [HttpDelete("{id:length(24)}")]
        public IActionResult DeleteUser(string id){
            _userService.DeleteUser(id);
            return NoContent();
        }

    }
}
