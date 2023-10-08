using Crop_Dealer.Model;

namespace Crop_Dealer.Repository.FarmerUser
{
    public interface IFarmerInvoice
    {
        List<Invoice> GetFarmerInvoice(int id);
    }
}
