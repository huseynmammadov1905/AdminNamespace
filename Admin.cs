using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminNamespace
{
    public class Admin
    {



       


        public string? username { get; set; }

        public string? email { get; set; }

        public string? password { get; set; }


        public string? posts { get; set; }

        public string? notification { get; set; }

        Admin() { }

        public Admin(string? username, string? email, string? password, string? posts, string? notification)
        {
            this.username=username;
            this.email=email;
            this.password=password;
            this.posts=posts;
            this.notification=notification;
        }

 



    }
}
