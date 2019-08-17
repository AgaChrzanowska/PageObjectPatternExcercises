namespace PageObjectPatternExcercises.Tests.Login
{
    public class LoginHelper
    {
        /// <summary>
        /// Url logowania
        /// </summary>
        public static string Url = "http://zero.webappsecurity.com/login.html";

        

        /// <summary>
        /// Poprawny login
        /// </summary>
        public static string UsernameValue = "username";

        /// <summary>
        /// Poprawne hasło
        /// </summary>
        public static string PasswordValue = "password";

        /// <summary>
        /// Url po poprawnym zalogowaniu
        /// </summary>
        public static string LoggedInUrl = "http://zero.webappsecurity.com/bank/account-summary.html";

        /// <summary>
        /// Błędne dane logowania
        /// </summary>
        public static string WrongUsernameValue = "wrongLogin";
        public static string WrongPasswordValue = "wrongPassword";
        public static string WrongLoginMessage = "Login and/or password are wrong.";
    }
    
}