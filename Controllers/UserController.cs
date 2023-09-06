using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        //Login
        //Update User Account
        //Delete User Account


    }
}