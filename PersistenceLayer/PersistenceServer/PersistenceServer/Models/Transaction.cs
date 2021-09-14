using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersistenceServer.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        [Required, ForeignKey("receiver")]
        public Account ReceiverAccount { get; set; }
        [Required, ForeignKey("sender")]
        public Account SenderAccount { get; set; }
        [Required, Range(0, 298000)] 
        public float Amount { get; set; }
        public string Comment { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
    } 
}