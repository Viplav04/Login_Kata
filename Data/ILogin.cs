namespace Login_Kata_Blazor.Data;

public interface ILogin {
	public Task<string> LoginAsync(string loginname, string password);
	public bool Is_login_valid(string token);
	//public void Request_password_reset(string email);
	//public void Reset_password(string resetRequestNumber);
}