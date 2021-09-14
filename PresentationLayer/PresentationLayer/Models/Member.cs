using System;

namespace PresentationLayer.Models
{
    public class Member : ViaEntity
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public long Cpr { get; set; }
        
    }
}