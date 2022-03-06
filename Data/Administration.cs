namespace Login_Kata_Blazor.Data;

public partial class Administration : IAdministration{

    LocalStorageService _storageService = new LocalStorageService();

    public List<User> users = null;

    public User activeuser = new User();

    public Administration(){
        Init();
    }

    async void Init(){
        try
        {
            users = await _storageService.ReadAllUsers();
        }
         catch(Exception ex){
            Console.WriteLine(ex.Message + ex.StackTrace);
        }      
    }

    public User Current_user(string token){
        User varuser = new User();
        try{
            if(users != null){
                foreach(User user in users){
                    if(user.AccessToken == token)
                    varuser = user;
                    break;
                }
            }
        }
        catch(Exception ex){
            Console.WriteLine(ex.Message + ex.StackTrace);
        }
    return varuser;   
    }

	public void Rename(string userId, string email, string nickname){
        try{
            if(activeuser.Id == userId){
                activeuser.Email = email;
                activeuser.Nickname = nickname;
                _storageService.UpdateUser(activeuser);
            }
        }
        catch(Exception ex){
            Console.WriteLine(ex.Message + ex.StackTrace);
        }
    }

	public void Change_password(string userId, string password){
        try{
            if(activeuser.Id == userId){
                activeuser.Password = password;
                _storageService.UpdateUser(activeuser);
            }
        }
        catch(Exception ex){
            Console.WriteLine(ex.Message + ex.StackTrace);
        }
    }

	public void Delete(string userId, string password){
        try{
            if(activeuser.Id == userId &&
               activeuser.Password == password){
                activeuser = new User();
                // _storageService.UpdateUser(activeuser);
            }
        }
        catch(Exception ex){
            Console.WriteLine(ex.Message + ex.StackTrace);
        }
    }
}