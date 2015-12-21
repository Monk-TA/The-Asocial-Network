namespace TheAsocialNetwork.UI.UWP.Services.Data.Parse
{
    using System;
    using System.Threading.Tasks;
    using global::Parse;
    using TheAsocialNetwork.UI.UWP.Models.Parse;

    public class ParseAuthenticationService
    {
        // TODO: validate input and send notification before use this method
        public async Task<bool> RegisterAsync(string username, string password, string emial)
        {
            try
            {
                var newUser = new UserParse()
                {
                    Username = username,
                    Password = password,
                    Email = emial
                };

                await newUser.SignUpAsync();

                return true;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;

                return false;
            }
        }

        public async Task<bool> RegisterAsync(UserParse user)
        {
            try
            {
                await user.SignUpAsync();

                return true;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;

                return false;
            }
        }

        public async Task<bool> LogInAsync(string username, string password)
        {
            try
            {
                await ParseUser.LogInAsync(username, password);

                return true;
            }
            catch (Exception ex) 
            {
                var msg = ex.Message;

                return false;
            }
        }

        public async Task<bool> LogOutAsync()
        {
            try
            {
                await ParseUser.LogOutAsync();

                return true;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;

                return false;
            }
        }

    }
}
