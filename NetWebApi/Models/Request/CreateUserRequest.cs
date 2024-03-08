using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace NetWebApi.Models.Request
{
    public class CreateUserRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
