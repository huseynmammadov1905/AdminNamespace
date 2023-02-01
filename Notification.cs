using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserNamespace;
using PostNamespace;
namespace NotificationNamespace
{
    public class Notification
    {


        public int ID;

        public string text { get; set; }

        public DateTime d => DateTime.Now;


        public string FromUser { get; set; }

      

        public Notification() { }

        public Notification( string text, string fromUser)
        {
       
            this.text=text;
            
            FromUser=fromUser;
           
        }


    
    }
}
