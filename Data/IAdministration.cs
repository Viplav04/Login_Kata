namespace Login_Kata_Blazor.Data;

public interface IAdministration {
	public User Current_user(string token);
	public void Rename(string userId, string email, string nickname);
	public void Change_password(string userId, string password);
	public void Delete(string userId, string password);
}