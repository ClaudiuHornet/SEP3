using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersistenceServer.Models
{
    public class CreditCard
    {
        [Key, Required, StringLength(16, ErrorMessage = "Invalid credit card number")]
        public string CreditCardNumber { get; set; }
        
        [MaxLength(256), Required, Column("fname")]
        public String FirstName { get; set; }
        
        [MaxLength(256), Required, Column("lname")]
        public String LastName { get; set; }

        [Required, StringLength(2, ErrorMessage = "Invalid credit card expiration month")]
        public string ExpirationMonth { get; set; }
        
        [Required, StringLength(2, ErrorMessage = "Invalid credit card expiration year")]
        public string ExpirationYear { get; set; }

        [Required, Range(000, 999, ErrorMessage = "Invalid credit card security code")]
        public int SecurityCode { get; set; }

        [Required,Range(0, 9000000)]
        public float AmountOfMoney { get; set; }

        [ForeignKey("accountId")]
        public Account Account { get; set; }
    }
}