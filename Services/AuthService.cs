namespace ChartSync.Services
{
    public class AuthService
    {
        public bool IsLoggedIn { get; private set; }

        // Call this when user logs in/out
        public void SetLoggedIn(bool loggedIn)
        {
            IsLoggedIn = loggedIn;
        }
    }
}
