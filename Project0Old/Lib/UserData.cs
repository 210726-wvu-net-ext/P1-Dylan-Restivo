// using System.Text.Json;
// using System.IO;
// using System.Threading.Tasks;
// using System.Collections.Generic;

// namespace Lib
// {
//     /// <summary>
//     /// Reading and writing data to a text file UserData.txt
//     /// SCRAPPED FOR NOW - Project0.db --> [table] USERS((INT)ID, (TEXT)NAME)
//     /// </summary>
//     /// 
    



//     public class UserData
//     {
//         public static void CallDatabaseCon(){
//             using(DatabaseConnection connection=new DatabaseConnection()){
//                 System.Console.WriteLine("Using connection");
//             }           
//         }
//         public static List<User> UsersInit(){
//         List<User> users = new List<User>(){
//             new User(12345, "Mike"),
//             new User(12365, "Bill"),
//             new User(13245, "Frank")
//         };
//         return users;
//         }
//         public static void Serialize_Json_Users(){
//             var users=UsersInit();
//             if(users.Count>0){
//                 UserToFromJson.AddUsers(users);
//             }
//         }
//         public static void Deserialize_Json(){
//             var users=UserToFromJsonGetUsers().Result;
//             System.Console.WriteLine("Reading from Json...");
//             foreach (var user in users)
//             {
//                Console.WriteLine($"{user.Id} {user.Name}");
//             }
//         }
        
        
//     }

//     public class UserToFromJson{

//         private static string path= "UserData.Json";
//         public static async void AddUsers(List<User> users){
//             using (FileStream stream= File.Create(path))
//             {
//                 try
//                 {
//                    await JsonSerializer.SerializeAsync(stream,users);
//                 }
//                 catch(DriveNotFoundException){
//                     throw;
//                 }
//                 catch (System.Exception)
//                 {
                    
//                     throw;
//                 }
                
//                 System.Console.WriteLine("User data stored in file");
//             }
//         }
//         public static async Task<List<User>> GetUsers(){
//             using (FileStream stream=File.OpenRead(path))
//             {
//                 var users= await JsonSerializer.DeserializeAsync<List<User>>(stream);
//                 return users;
//             }
//         }
//     }
// } 