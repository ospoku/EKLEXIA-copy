namespace EKLEXIA.Models
{
    public class Message
    {
        public Message()
        {
                
        }

        public string MessageId { get; set; }
        public string Subject { get; set; }
        public string Sender { get; set; }
        public string Reciever { get; set; }
        public string Body { get; set; }
        public byte IsRead { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
