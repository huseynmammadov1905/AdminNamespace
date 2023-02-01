using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace UserNamespace
{
    public class User
    {



        public int ID;
       

        public int Age;

        public string? name { get; set; }
        public string? surname { get; set; }

        public int age { get { return Age; } set { Age =  (value > 0 && value < 150) ? value : 18; } }

        public string? email { get; set; }

        public string? password { get; set; }


       public User() { }

        public User(string? name, string? surname, int age, string? email, string? password)
        {

            
            this.name=name;
            this.surname=surname;
            this.age=age;
            this.email=email;
            this.password=password;
        }


       


    }
}