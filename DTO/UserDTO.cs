using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        [MaxLength(100),MinLength(2)]
        public string Name { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? Password { get; set; }



    }
}
