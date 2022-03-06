namespace Login_Kata_Blazor.Data;

public class User {
	public string Id { get; set; }
	public string Email { get; set; }
	public string Nickname { get; set; }
    public bool Confirmed { get; set; }
	public DateTime RegistrationDate { get; set; }
	public DateTime LastLoginDate { get; set; }
	public DateTime LastUpdatedDate { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public string Password { get; set; }
}