using System;
using System.ComponentModel.DataAnnotations;

namespace PersistenceServer.Models
{
    public class ViaEntity
    {
        [Key, Required, Range(0, 9999999, ErrorMessage = "Invalid VIA ID")]
        public int ViaId { get; set; }
        [Required, StringLength(64)]
        public string Password { get; set; }
        
    }
}