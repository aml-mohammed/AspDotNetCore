namespace WebApp.Models.ViewModels
{
    public class AccountDetailsViewModel
    {
        public string Title { get; set; } = "Account Details";
        public AccountDteailsModel BasicInfo { get; set; } = new AccountDteailsModel()
        {
            ProfileImage="/images/profile.jpg",
            FirstName="Mohamed",
            LastName="Rafael",
            Eamil="mohamed@gmail.com"
        };
        public AccountAddressInfoModel AddressInfo { get; set; } = new AccountAddressInfoModel();
    }
}
