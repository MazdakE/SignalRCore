using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace SignalRCoreChat.Mvc.Models
{
    public class ChatUser : IdentityUser
    {
        public virtual ICollection<Message> Messages { get; set; }
    }
}