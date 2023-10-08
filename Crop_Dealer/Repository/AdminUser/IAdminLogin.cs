using Crop_Dealer.Model;

namespace Crop_Dealer.Repository.AdminUser
{
    public interface IAdminLogin
    {
        Admin Login(string eamil, string password);
    }
}
