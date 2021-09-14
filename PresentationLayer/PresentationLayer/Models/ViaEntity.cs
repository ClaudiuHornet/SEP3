using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models
{
    public class ViaEntity
    {
        [Required]
        [Range(0, 9999999, ErrorMessage = "Invalid VIA ID")]
        public int? ViaId { get; set; }
        
        [Required]
        [MinLength(8, ErrorMessage = "Password is too short")]
        public string Password { get; set; }
    }
}