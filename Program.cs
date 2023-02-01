// See https://aka.ms/new-console-template for more information
using PostNamespace;
using UserNamespace;
using AdminNamespace;

using NetworkNamespace;
using System.ComponentModel;
using System.Reflection.Emit;
using NotificationNamespace;




//Bu tapshiriqda programin
//AdminNamespace
//UserNamespace
//PostNameSpace bolmelisiniz
////etdiyiniz elaveler uchun 
//meselen:mail uchun networknamespace yarada bilersiniz

//Admin=>id, username, email, password, Posts, Notifications
//User=>id, name, surname, age, email, password
//Post=>id, Content, CreationDateTime, LikeCount, ViewCount

//Notification=>id, Text, DateTime, FromUser(bu hansi user terefinden bu bildirishin geldiyidir)

//Demeli sistemde 2 teref var User ve Admin
//1.program achilanda user ve ya admin kimi daxil olmasi sorushulur
//2.her ikisi de username(ve ya email) ve password daxil edirler
//3.User yalniz umumi postlara baxa biler ve
//Like ede biler(baxmaq ve like procesini ID esasinda apara bilersiniz)
//Meselen: posta baxish uchun id ni daxil edin ve like uchun
//Id daxil edin
//her defe posta baxildiqca ve ya like edildikce postun baxish sayi ve like sayi artir
//ve her defe de admine bildirish gelir her baxish ve ya like edilende
//(BU SISTEMI DAHA DA TEKMILLESHDIRIB MAIL SISTEMI
//YARADA BILERSINIZ MESELEN 
//her defe notificationlar yaransin hem Admin klasindaki notification elave olunsun hem de mail olaraq admine gonderile biler)


User b1 = new User("serxan", "tanriverdi", 20, "saxa@", "11111");

string post1 = "Eger bir adam yalan danishirsa demeli o adam yalachidir ))";
string post2 = "Main Nedir? ";


Post p1 = new Post(post1, "huseyn");
Post p2 = new Post(post2, "rustem");
Network network = new();
network.AddUser(ref b1);
network.AddPost(p1);
network.AddPost(p2);

//network.ShowUser();
//network.ShowPost();
//Thread.Sleep(100000);


string usName = default;





Admin a = new("huseyn", "hm@gmail.com", "12345", post1, "1");



User b = new User();


bool UserMenu()
{
    string[] arr = { "Add Post", "Show Post" };
    int x1 = 0;
Label: 
    while (true)
    {

        print(arr, arr.Length, x1);
        var key1 = Console.ReadKey();
        Console.Clear();
        switch (key1.Key)
        {
            case ConsoleKey.DownArrow:
                x1 = x1 == 1 ? 0 : 1;
                break;
            case ConsoleKey.UpArrow:
                x1 = x1 == 0 ? 1 : 0 ;
                break;

            default:
                break;
        }

        if (key1.Key == ConsoleKey.Enter)
        {
            if (x1 == 0)
            {
                PostAdd();
                goto Label;
            }
    
            else if (x1 ==1)
            {
               Label1:
                
                network.ShowPostAuthor();
                Console.WriteLine("Postu gormek ucun id'sini yazin : ");
                int.TryParse(Console.ReadLine(), out int id1);
                if(id1 <= 0 || id1 > network.posts.Count)
                {
                    Console.WriteLine("Wrong");
                    Thread.Sleep(1000);
                    goto Label;
                }
                network.ShowPostUser(id1);
                network.ViewPost(id1);
            Label2:
                Console.WriteLine("1 - like\n0.Back");
                int.TryParse (Console.ReadLine(), out int ch);
                if (ch == 0)
                    goto Label;
                else if (ch == 1)
                {

                    Console.WriteLine("Post like edildi");
                    network.LikePost(id1);
           
                    Notification notification= new Notification(network.posts[id1 - 1].Content,usName);
                    network.notifications.Add(notification);
                    Thread.Sleep(1500);
                    Console.ReadLine();
                    goto Label;
                }
                else
                {
                    Console.WriteLine("wrong choice");
                    Thread.Sleep(1500);
                    goto Label2;
                }
            }
          

        }
        else if (key1.Key == ConsoleKey.Escape)
        {
            break;

        }

    }
    return true;
}

bool AdminMenu()
{
    Label:
    string[] arr = { "Add Post", "Remove Post", "Show Post", "Show User","Notification" };
    int x1 = 0;

    while (true)
    {

      
        print(arr, arr.Length, x1);
        var key1 = Console.ReadKey();
        Console.Clear();
        //print(arr, arr.Length, x);
        switch (key1.Key)
        {
            case ConsoleKey.DownArrow:
                x1 = x1 == 4 ? 0 : x1 + 1;
                break;
            case ConsoleKey.UpArrow:
                x1 = x1 == 0 ? 4 : x1 - 1;
                break;

            default:
                break;
        }

        if (key1.Key == ConsoleKey.Enter)
        {
            if (x1 == 0)
            {
                PostAdd();
                Console.WriteLine("Post elave olundu");
                Thread.Sleep(1500);
                goto Label;
            }
            else if (x1 == 1)
            {
                if (network.posts.Count == 0)
                {
                    Console.WriteLine("Post yoxdur");
                    Thread.Sleep(1500);
                    goto Label;
                }

                Console.Write("Sileceyiniz Post'un id'sini yazin : ");
                int.TryParse(Console.ReadLine(), out int ID);
                Console.WriteLine("Post silindi");
                PostRemove(ID);
                Thread.Sleep(1500);
                goto Label;
            }
            else if(x1 ==2)
            {
                network.ShowPost();
                Thread.Sleep(1500);
                Console.ReadLine();
                goto Label;
            }
            else if (x1==3)
            {
                network.ShowUser();
                Thread.Sleep(1500);
                Console.ReadLine();
                goto Label;
            }
            else if(x1 == 4)
            {
                if(network.notifications.Count== 0)
                {
                    Console.WriteLine("Bildirish yoxdur");
                    Thread.Sleep(1500);
                   
                    goto Label;
                }

                network.ShowNotification();
                Thread.Sleep(1500);
                Console.ReadLine();
                goto Label;
            }

        }
        else if(key1.Key == ConsoleKey.Escape)
        {
            break;
            
        }
        
    }
    return true;
}
bool PostAdd()
{
    //Console.Write("Post author : ");
    //string a = Console.ReadLine();
    string Author = usName;
    Console.WriteLine("Post : ");
    string p = Console.ReadLine();
    
    Post post = new Post(p,usName);
    network.AddPost(post);
    Console.WriteLine("Post yaradildi");
    Thread.Sleep(1500);
    return true;
}

bool PostRemove(int id)
{
    if(id > network.posts.Count)
    {
        Console.WriteLine("Wrong");
        Thread.Sleep(1500);
        return false;
    }
    network.RemovePost(id);
    return true;
}

bool AdminSignIn()
{

    Console.Write("username yaxud email : ");
    string usnm = Console.ReadLine();
    Console.Write("password : ");
    string pass = Console.ReadLine();

    if (usnm == a.email || usnm == a.username)
    {
    
        if (pass == a.password)
        {
            Console.WriteLine("Successfull");
            Thread.Sleep(1500); 
            return true;
        }
        else
        {
            Console.WriteLine("wrong password");
            Thread.Sleep(1500);
            return false;
        }
    }
    else
    {
        Console.WriteLine("wrong email or username");
        Thread.Sleep(1500);
        return false;
       
    }
}




bool UserSignIn()
{
    Console.Write("(0 - back)username yaxud email : ");
    string usnm = Console.ReadLine();
    Console.Write("password : ");
    string pass = Console.ReadLine();

    for (int i = 0; i < network.users.Count; i++)
    {

        if (usnm == "0")
            return false;
        else if (usnm == network.users[i].name || usnm == network.users[i].email)
        {

            if (pass == network.users[i].password)
            {
                Console.WriteLine("Successfull");
                Thread.Sleep(1500);
                usName = usnm;
                return true;
            }
            else
            {
                Console.WriteLine("wrong password");
                Thread.Sleep(1500);
                return false;
            }
        }

            
        
    }
    Console.WriteLine("wrong email");
    Thread.Sleep(1500);
    return false;
}

bool UserSingUp()
{
   
    
    Console.Write("Ad : ");
    string name = Console.ReadLine();
   
    Console.Write("Soyad : ");
    string surname = Console.ReadLine();
    Label1:
    Console.Write("Yas : ");
    int.TryParse(Console.ReadLine(), out int age);
    if (age < 0 || age > 150)
    {
        Console.WriteLine("yash duzgun deyil");
        Thread.Sleep(1500);
        goto Label1;
    }
    else if (age == 0)
    {
        return false;
    }

    Console.WriteLine("E-mail : ");
string email = Console.ReadLine();
    Console.WriteLine("Password : ");
    string password = Console.ReadLine();

    for (int i = 0; i < network.users.Count; i++)
    {
        if (name == network.users[i].name && surname  == network.users[i].surname)
        {
            Console.WriteLine("Bu add artiq movcuddur");
            
            Thread.Sleep(1500);
            return false;
        }

        
    }
    network.users.Add(new User(name,surname,age,email,password));
    return true;
}

void print(string[] arr, int size, int x)
{
    for (int i = 0; i < size; i++)
    {
        if (i == x)
        {
            Console.ForegroundColor = ConsoleColor.Green; 
        }
        Console.WriteLine(arr[i]);
        Console.ForegroundColor = ConsoleColor.White;
    }
}



string[] arr = { "Admin", "User Sign in","User Sign up" };

int x = 0;
LabelMenu:

//Console.WriteLine("Hello, World!");
//Console.WriteLine("===================");
while (true)
{

    //Console.Clear();
    Console.Clear();
    print(arr, arr.Length, x);

    var key = Console.ReadKey();
  

   
    //Console.WriteLine(key.Key);
    

    //print(arr, arr.Length, x);
    switch (key.Key)
    {
        case ConsoleKey.DownArrow: x = x == 2 ? 0 : x + 1;
            break;
        case ConsoleKey.UpArrow: x = x == 0 ? 2 : x - 1;
            break;
         
        default:
            break;
    }

    if (key.Key == ConsoleKey.Enter)
    {


        Console.Clear();

        if (x == 0)
        {
            if (AdminSignIn())
            {
                AdminMenu();
            }
            goto LabelMenu;
        }
        else if (x == 1)
        {
           if(UserSignIn())
            {

                UserMenu();
               
            }
           goto LabelMenu;
        }
        else if (x == 2)
        {
        Label2:
            if (UserSingUp())
            {
                Console.WriteLine("Qeydiyyatdan ugurla kecdiniz !!! ");

                Thread.Sleep(1500);

                goto LabelMenu;
            }
            goto Label2;


        }
        break;
    }
    else if(key.Key == ConsoleKey.Escape)
    {
        break;
    }
}
