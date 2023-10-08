using Crop_Dealer.Model;

namespace Crop_Dealer.Repository.AdminUser
{
    public class Deletefarmers : IDeleteFarmer
    {
        CropDealContext context;
        public Deletefarmers(CropDealContext context)
        {
            this.context = context;
        }

        public string Deletefarmer(int id)
        {
            try
            {
                var temp = context.Farmers.Find(id);
                if (temp != null)
                {
                    context.Farmers.Remove(temp);
                    context.SaveChanges();
                    return "Deleted Successfully";
                }
                return "Farmer Not Found";
            }catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
