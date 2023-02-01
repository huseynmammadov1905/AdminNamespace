
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Post=>id, Content, CreationDateTime, LikeCount, ViewCount
namespace PostNamespace
{
    public class Post
    {



        public int ID;

    

        public string? Content { get; set; }

        public DateTime d => DateTime.Now;

        public int LikeCount { get; set; }


        public int ViewCount { get; set; }

        public string ? AuthorName { get; set; }


      public  Post() { }

      
public Post(string? content, string? authorName)
        {

          
            Content=content;
            
            LikeCount=0;
            ViewCount=0;
            AuthorName=authorName;
        }
    }
}