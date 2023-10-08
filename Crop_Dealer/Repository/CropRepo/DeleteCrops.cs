using Crop_Dealer.Model;

namespace Crop_Dealer.Repository.CropRepo
{
    public class DeleteCrops : IDeleteCrops
    {

        CropDealContext context;
        public DeleteCrops(CropDealContext context)
        {
            this.context = context;
        }
        public string DeleteCrop(int id)
        {
            try
            {
                var temp = context.Crops.Find(id);
                if (temp!=null)
                {
                    context.Crops.Remove(temp);
                    context.SaveChanges();
                    return "Deleted Successfully";
                }
                return "Crop Not Found";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
