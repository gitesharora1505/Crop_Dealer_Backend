using Crop_Dealer.Model;

namespace Crop_Dealer.Repository.DealerUser
{
    public class ViewAllCrops : IViewAllCrops
    { 
         CropDealContext context;
        public ViewAllCrops(CropDealContext context)
        {
            this.context = context;
        }

        public List<Crop> ViewCrop()
        {
            return context.Crops.ToList();
        }
    }
}
