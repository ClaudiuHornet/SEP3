using System;

namespace PresentationLayer.Models
{
    public class Transaction
    {   
        public Account ReceiverAccount { get; set; }
        public Account SenderAccount { get; set; }
        public float Amount { get; set; }
        public string Comment { get; set; }
        public string Type { get; set; }
        public DateTime Timestamp { get; set; }
    }
}