using Crop_Dealer.Model;

namespace Crop_Dealer.Repository.DealerUser
{
    public interface IBuyCrops
    {
        Invoice InvoiceGenerate(int cropId, int dealerId, double quantity);
    }
}
