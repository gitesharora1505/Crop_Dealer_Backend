using Crop_Dealer.Model;

namespace Crop_Dealer.Repository.FarmerUser
{
    public class FarmerInvoice : IFarmerInvoice
    {
        CropDealContext context;
        public FarmerInvoice(CropDealContext context)
        {
            this.context = context;
        }
        public List<Invoice> GetFarmerInvoice(int id)
        {
            var tempfarmer = context.Farmers.FirstOrDefault(f => f.FarmerId == id);
            try
            {
                List<Invoice> result = new List<Invoice>();
                result = context.Invoices.Where(c => c.FarmerEmail.Equals(tempfarmer.FarmerEmail)).ToList();
                return result;
            }
            catch (Exception ex)
            {
                return new List<Invoice>();
            }
        }
    }
}
