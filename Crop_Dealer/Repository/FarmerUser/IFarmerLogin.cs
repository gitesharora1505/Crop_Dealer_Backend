using Crop_Dealer.Model;

namespace Crop_Dealer.Repository.FarmerUser
{
    public interface IFarmerLogin
    {
        Farmer Login(string email,string password);
    }
}
