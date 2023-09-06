using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogBackEnd.Models;
using BlogBackEnd.Models.DTO;
using BlogBackEnd.Services.Context;
using System.Security.Cryptography;

namespace BlogBackEnd.Services
{
    public class UserService

    {
        private readonly DataContext _context;
        //create a constructor
        public UserService(DataContext context)
        {
            _context = context;
            
        }
        //Helper function DoesUserExist(string username)
        public bool DoesUserExist(string username){
            //will check tables to see if the username exists
            //if one item matches our condition, that item will be returned
            //if no match, returns null
            //if multiple items match, will return an error
            return _context.UserInfo.SingleOrDefault(user => user.Username == username) != null;
            // UserModel foundUser =  _context.UserInfo.SingleOrDefault(user => user.Username == username);
            // if(foundUser == null){
            //     //the user exists in the table
               
            // }
            // else{
            //      //the user does not exist
                
            // }
        }
        public bool AddUser(CreateAccountDTO UserToAdd){
            
            bool result = false;
            //if user already exists
            if(!DoesUserExist(UserToAdd.Username)){
                //if true need to create a new instance of our UsserModel
                UserModel newUser = new UserModel();
                var newHashedPassword = HashPassword(UserToAdd.Password);
                newUser.Id = UserToAdd.Id;
                newUser.Username = UserToAdd.Username;
                newUser.Salt = newHashedPassword.Salt;
                newUser.Hash = newHashedPassword.Hash;
                //now need to add to our data base
                _context.Add(newUser);
                //we need to 
                _context.SaveChanges();
            }
            return result;
            //if does not need to create account
            //else throw false error

        }
        public PasswordDTO HashPassword(string password){
            //logic where we feed in a password, and protext it with hash and salt

            //create a password dto this is what we will return
            //need a new instance created of password dto
            PasswordDTO newHashedPassword = new PasswordDTO();

            //need to create a vaiable type byte
            //salt bytes size of our Salt Bytes is 64
            byte[] SaltBytes =  new byte[64]; 

//RNGCryptoServiceProvider is an instance of the system. secure. cryptography and creates random numbers
            var provider = new RNGCryptoServiceProvider();
            //now we are going to exclude all the zeros
            provider.GetNonZeroBytes(SaltBytes);
            //encrypts our 64 string and encrypts is for us
            var Salt = Convert.ToBase64String(SaltBytes);

            //we will us below to creat the hash, 1st is password, 2nd is byte, 3rd is the iterations
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, SaltBytes, 10000);

            //Now we need to create our hash
            var Hash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));
            //return newHashedPassword.Salt = salt
            newHashedPassword.Salt = Salt;
            newHashedPassword.Hash = Hash;

            return newHashedPassword;
        }

        public bool VerifyUserPassword(string? Password, string? StoredHash, string? StoredSalt){
            var SaltBytes = Convert.FromBase64String(StoredSalt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(Password, SaltBytes, 10000);
            var newHash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));
            return newHash == StoredHash;

        }

       
    }
}