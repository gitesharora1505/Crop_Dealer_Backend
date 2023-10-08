using Crop_Dealer.Model;

namespace Crop_Dealer.Repository.DealerUser
{
    public interface IDealerInvoice
    {
        List<Invoice> GetDealerInvoice(int id);
    }
}
