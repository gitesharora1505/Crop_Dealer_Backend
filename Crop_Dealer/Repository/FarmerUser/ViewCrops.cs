using Crop_Dealer.Model;

namespace Crop_Dealer.Repository.FarmerUser
{
    public class ViewCrops : IViewCrops
    {
        CropDealContext context;
        public ViewCrops(CropDealContext context)
        {
            this.context = context;
        }

        public List<Crop> ViewCrop(int id)
        {
            var tempfarmer=context.Farmers.FirstOrDefault(f=>f.FarmerId==id);
            try
            {
                List<Crop> result = new List<Crop>();
                result = context.Crops.Where(c => c.FarmerEmail.Equals(tempfarmer.FarmerEmail)).ToList();
                return result;
            }catch (Exception ex)
            {
                return new List<Crop>();
            }
            
        }
    }
}
