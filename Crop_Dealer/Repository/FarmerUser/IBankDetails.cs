using Crop_Dealer.Model;

namespace Crop_Dealer.Repository.FarmerUser
{
    public interface IBankDetails
    {
        string AddDetails(BankDetail bankDetail);
        string EditDetails(BankDetail bankDetail);
    }
}
