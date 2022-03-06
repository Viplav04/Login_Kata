namespace Login_Kata_Blazor.Data;

public partial class Registration : IRegistration{

    LocalStorageService _storageService = new LocalStorageService();
    public async Task<bool> Register(string email, string password, string nickname){
        bool result = false;
        List<User> users = null;
        User varuser = new User();
        try{
            users = await _storageService.ReadAllUsers();

            result = true;
            foreach(User user in users){
                if(email == user.Email){
                    result = false;
                    break;               
                }
            }
            if(result == true){
                varuser.Email = email;
                varuser.Confirmed = true;
                varuser.Nickname = email;
                varuser.Password = password;
                varuser.RegistrationDate = DateTime.Now;
                varuser.LastLoginDate = DateTime.Now;
                varuser.LastUpdatedDate = DateTime.Now;
                varuser.Id =  System.Guid.NewGuid().ToString();

                _storageService.WriteUser(varuser);
            }
        }
        catch(Exception ex){
            Console.WriteLine(ex.Message + ex.StackTrace);
        }
        return result;
    }
}