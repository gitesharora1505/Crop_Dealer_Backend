using Crop_Dealer.Model;

namespace Crop_Dealer.Repository.DealerUser
{
    public interface IDealerLogin
    {
        Dealer Login(string email,string password);
    }
}
