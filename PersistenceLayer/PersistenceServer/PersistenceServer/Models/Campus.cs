using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersistenceServer.Models
{
    public class Campus
    {
        [Required, MaxLength(256)]
        public string City { get; set; }

        [Required, MaxLength(256)]
        public string Street { get; set; }

        [Required, StringLength(4, ErrorMessage = "Invalid postcode"), Column("postcode")]
        public string PostCode { get; set; }

        [Required, MaxLength(256)]
        public string Name { get; set; }
    }
}