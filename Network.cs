
using AdminNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UserNamespace;
using AdminNamespace;
using PostNamespace;
using NotificationNamespace;


namespace NetworkNamespace
{

    public class Network 
    {
        public List<Notification> notifications = new();
      public  List<User> users = new();
        public List<Post> posts = new();

        public Network() { }


      public   void AddUser(ref User user)
        {
            users.Add(user);
        }

        public void AddPost(Post post)
        {
            posts.Add(post);
        }


        public void RemovePost(int id)
        {
            posts.Remove(posts[id - 1]);
        }

        public void ShowUser()
        {
            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine($"Id : {i +1}\nName : {users[i].name}\nSurname : {users[i].surname}\nAge : {users[i].Age}\nE-mail : {users[i].email}");
                Console.WriteLine("=========================");
            }
        }


        public void ShowPostAuthor() {
            for (int i = 0; i < posts.Count; i++)
            {
                Console.WriteLine($"Id : {i +1}\nName : {posts[i].AuthorName}");
                Console.WriteLine("=========================");
            }
        }
        public void ShowPost()
        {
            for (int i = 0; i < posts.Count;i++)
            {
                Console.WriteLine($"Id : {i + 1}\nName : {posts[i].AuthorName}\nPost : {posts[i].Content}\nView : {posts[i].ViewCount}\nLike : {posts[i].LikeCount}");
                Console.WriteLine("=========================");

            }
        }

        public void ShowPostUser(int id)
        {
            Console.WriteLine($"Id : {id }\nName : {posts[id - 1].AuthorName}\nPost : {posts[id - 1].Content}\nView : {posts[id - 1].ViewCount}\nLike : {posts[id - 1].LikeCount}");
        }

        public void LikePost(int id)
        {
            posts[id - 1].LikeCount++;
        }
        public void ViewPost(int id)
        {
            posts[id - 1].ViewCount++;
        }


        public void ShowNotification()
        {
            for (int i = 0; i <notifications.Count ; i++)
            {
                Console.WriteLine($"id{i - 1}\n'{notifications[i].text}' postu '{notifications[i].FromUser}' adli istifadechi  terefinden beyenildi\nTarix : {notifications[i].d}");
            }
        }
    }
}