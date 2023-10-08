using Crop_Dealer.Model;

namespace Crop_Dealer.Repository.CropRepo
{
    public interface IAddCrops
    {
        string AddCrop(Crop crop,int farmerid);
    }
}
