namespace Login_Kata_Blazor.Data;
using System.IO;
using System.Text.Json;
public partial class LocalStorageService{

    public string localdirectory = "";
    public string filepath = "";

    public LocalStorageService(){
       try{
           localdirectory = Directory.GetCurrentDirectory();
           filepath = localdirectory + Path.DirectorySeparatorChar + "users.txt";
        }
        catch(Exception ex){
            Console.WriteLine(ex.Message + ex.StackTrace);
        }
    }
    public async Task<List<User>> ReadAllUsers(){
        List<User> users = new List<User>();
        User varuser = null;
        string[] text = null;
        try{
            if(File.Exists(filepath)){
                text = await File.ReadAllLinesAsync(filepath);
            }
            foreach(string str in text){
                //varuser = new User();
                varuser = JsonSerializer.Deserialize<User>(str);

                if(varuser != null)
                users.Add(varuser);
            }
        }
        catch(Exception ex){
            Console.WriteLine(ex.Message + ex.StackTrace);
        }
        return users;
    }

    public async void WriteUser(User user){
        string text = "";
        try{
            text = JsonSerializer.Serialize(user);

            using StreamWriter file = new(filepath, append: true);
            await file.WriteLineAsync(text);
        }
        catch(Exception ex){
            Console.WriteLine(ex.Message + ex.StackTrace);
        }
    }

    public void UpdateUser(User user){
    List<User> users = new List<User>();
    User varuser = null;
    string[] text = null;
    string updatestring = "";
        try{
            if(File.Exists(filepath)){
                text = File.ReadAllLines(filepath);
            }
            foreach(string str in text){
                //varuser = new User();
                varuser = JsonSerializer.Deserialize<User>(str);

                if(varuser != null)
                    users.Add(varuser);
            }

            foreach(User updateuser in users){
                if(user.Id == updateuser.Id){
                    updateuser.Email = user.Email;
                    updateuser.Nickname = user.Nickname;
                    updateuser.Password = user.Password;
                    updateuser.AccessToken = user.AccessToken;
                    updateuser.LastLoginDate = user.LastLoginDate;
                    updateuser.LastUpdatedDate = DateTime.Now;
                    break;
                }
                updatestring = JsonSerializer.Serialize(users);
                
                using StreamWriter file = new(filepath, append: false);
                file.Write(updatestring);
            }
        }
        catch(Exception ex){
            Console.WriteLine(ex.Message + ex.StackTrace);
        }
    }
}