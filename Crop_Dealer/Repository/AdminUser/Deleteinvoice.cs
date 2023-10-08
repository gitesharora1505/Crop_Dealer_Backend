using Crop_Dealer.Model;

namespace Crop_Dealer.Repository.AdminUser
{
    public class Deleteinvoice:IDeleteinvoice
    {
        CropDealContext context;
        public Deleteinvoice(CropDealContext context)
        {
            this.context = context;
        }

        public string DeleteInvoice(int id)
        {
            try
            {
                var temp = context.Invoices.Find(id);
                if (temp != null)
                {
                    context.Invoices.Remove(temp);
                    context.SaveChanges();
                    return "Deleted Successfully";
                }
                return "Invoice Not Found";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
