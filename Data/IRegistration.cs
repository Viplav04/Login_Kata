namespace Login_Kata_Blazor.Data;

public interface IRegistration {
	public Task<bool> Register(string email, string password, string nickname);
	//public void Confirm(string registrationNumber);
}