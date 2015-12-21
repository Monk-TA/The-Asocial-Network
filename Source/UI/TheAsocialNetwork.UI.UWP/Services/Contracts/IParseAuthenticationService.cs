namespace TheAsocialNetwork.UI.UWP.Services.Contracts
{
    using System.Threading.Tasks;
    using TheAsocialNetwork.UI.UWP.Models.Parse;

    public interface IParseAuthenticationService
    {
        Task<bool> RegisterAsync(string username, string password, string emial);
        Task<bool> RegisterAsync(UserParse user);
        Task<bool> LogInAsync(string username, string password);
        Task<bool> LogOutAsync();
    }
}