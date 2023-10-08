using Crop_Dealer.Model;

namespace Crop_Dealer.Repository.FarmerUser
{
    public interface IViewCrops
    {
        List<Crop> ViewCrop(int id);
    }
}
