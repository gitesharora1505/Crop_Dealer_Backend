using Crop_Dealer.Model;

namespace Crop_Dealer.Repository.AdminUser
{
    public class Deletedealer:IDeleteDealer
    {
        CropDealContext context;
        public Deletedealer(CropDealContext context)
        {
            this.context = context;
        }

        public string DeleteDealer(int id)
        {
            try
            {
                var temp = context.Dealers.Find(id);
                if (temp != null)
                {
                    context.Dealers.Remove(temp);
                    context.SaveChanges();
                    return "Deleted Successfully";
                }
                return "Dealer Not Found";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
