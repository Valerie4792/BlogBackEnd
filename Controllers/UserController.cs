using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogBackEnd.Models;
using BlogBackEnd.Models.DTO;
using BlogBackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BlogBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        
        //Add a user
        //create account dto is the type
         //create variable with a type of service
         private readonly UserService _data;
         public UserController(UserService dataFromService){
            _data = dataFromService;

         }

         [HttpPost("AddUsers")]
        public bool AddUser(CreateAccountDTO UserToAdd){
            return _data.AddUser(UserToAdd);
        
         
        }
            //if user exists already
            //if user does not exist, then account needed to be created
            //else throw error

            [HttpGet("GetAllUsers")]
            //Get Users endpoint
            public IEnumerable<UserModel> GetAllUsers(){
                return _data.GetAllUsers();
            }

        //userLogin
         [HttpPost("Login")]
         public IActionResult Login([FromBody]LoginDTO User){
            return _data.Login(User);
            
         }
        
        //Update User Account
        [HttpPost("UpdateUser")]
        public bool UpdateUser(int id, string username){
            return _data.UpdateUsername(id, username);
        }


        //Delete User Account
        [HttpPost("DeleteUser/{userToDelete}")]
        public bool DeleteUser(string userToDelete){
            return _data.DeleteUser(userToDelete);
        }
    }
    
       
      
}