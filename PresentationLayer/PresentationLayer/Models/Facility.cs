using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models
{
    public class Facility : ViaEntity
    {
        [Required, MaxLength(256)]
        public string Name { get; set; }
        public Campus Campus { get; set; }
        public Account Account { get; set; }
        
    }
}