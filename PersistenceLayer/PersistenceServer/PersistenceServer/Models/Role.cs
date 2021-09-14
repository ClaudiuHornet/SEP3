using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersistenceServer.Models
{
    public class Role
    {
        [Key, Required]
        public int RoleId { get; set; }

        [Required]
        public String RoleType { get; set; }
    }
}