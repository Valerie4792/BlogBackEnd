using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogBackEnd.Models.DTO
{
    public class CreateAccountDTO
    {
        public string? Username{get; set;}
        public int Id { get; set; }
        public string? Password { get; set; }
    }
}