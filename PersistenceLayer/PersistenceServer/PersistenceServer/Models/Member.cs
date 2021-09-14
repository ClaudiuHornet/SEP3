using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersistenceServer.Models
{
    public class Member : ViaEntity
    {
        [MaxLength(256), Required, Column("fname")]
        public String FirstName { get; set; }
        [MaxLength(256), Required, Column("lname")]
        public String LastName { get; set; }
        [Required, StringLength(10, ErrorMessage = "Invalid CPR")]
        public long Cpr { get; set; }
    }
}