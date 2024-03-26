namespace WebApp.Models.ViewModels
{
    public class SignInViewModel

    { 
         public string Title { get; set; } = "Sign In";
    public SignInModel Form { get; set; } = new SignInModel();
        public string? ErrorMesssage { get; set; }
    }
}
