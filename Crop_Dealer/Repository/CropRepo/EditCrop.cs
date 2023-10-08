using Crop_Dealer.Model;

namespace Crop_Dealer.Repository.CropRepo
{
    public class EditCrops : IEditCrop
    {
        CropDealContext context;
        public EditCrops(CropDealContext context)
        {
            this.context = context;
        }

        public string EditCrop(Crop crop)
        {
                try
                {
                    if (context.Crops.Any(c=>c.CropId.Equals(crop.CropId)))
                    {
                        context.Crops.Update(crop);
                        context.SaveChanges();
                        return "Updated Successfully";
                    }
                    return "Crop Not Found With This Crop Id";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            
        }
    }
}
