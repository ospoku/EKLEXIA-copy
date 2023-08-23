namespace EKLEXIA.Models
{
    public class Message
    {
        public Message()
        {
                
        }

        public int Id { get; set; } 
        public string Title { get; set; }   
        public string Body { get; set; }    
        public byte IsRead { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }

        public string MessageId { get; set; }
        public string Subject { get; set; }
     
        public string Reciever { get; set; }
     

    }
}
