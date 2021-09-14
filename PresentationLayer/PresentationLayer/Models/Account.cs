using System;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        
        public ViaEntity ViaEntity { get; set; }

        public Role AccountType { get; set; }

        [Required,MinLength(8, ErrorMessage = "Password is too short.")]
        public String ApplicationPassword { get; set; }
        
        public float Balance { get; set; }
        
    }
}