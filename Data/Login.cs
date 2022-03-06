namespace Login_Kata_Blazor.Data;

public partial class Login: ILogin{
    public List<User> users = null;
    public User activeuser = new User();
    LocalStorageService _storageService = new LocalStorageService();
    public Login(){
             Init();
    }
    
     async void Init(){
        try{
            users = await _storageService.ReadAllUsers();
        }
         catch(Exception ex){
            Console.WriteLine(ex.Message + ex.StackTrace);
        }      
    }

    public async Task<string> LoginAsync(string loginname, string password){
        string token = "";    
        try{
            
            if(users != null){
                foreach(User user in users){
                    if((user.Email == loginname ||
                        user.Nickname == loginname) &&
                        user.Password == password){
                           user.AccessToken = System.Guid.NewGuid().ToString();
                           user.LastLoginDate = DateTime.Now;
                           token = user.AccessToken;
                           activeuser = user;
                           _storageService.UpdateUser(activeuser);
                           //NavigationManager.NavigateTo("/profile");
                           break;
                       }
                }
            }

        }
        catch(Exception ex){
            Console.WriteLine(ex.Message + ex.StackTrace);
        }      
         return token;
    }

    public bool Is_login_valid(string token){
        bool result = false;
        try
        {          
            if(activeuser.AccessToken == token &&
                DateTime.Now < activeuser.LastLoginDate.AddMinutes(15)){                         
                    result = true;
            }
        }
        catch(Exception ex){
            Console.WriteLine(ex.Message + ex.StackTrace);
        }
        return result;
    }
}