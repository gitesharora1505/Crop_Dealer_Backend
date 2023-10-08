using Crop_Dealer.Model;

namespace Crop_Dealer.Repository.DealerUser
{
    public class DealerInvoice:IDealerInvoice
    {
        CropDealContext context;
        public DealerInvoice(CropDealContext context)
        {
            this.context = context;
        }
        public List<Invoice> GetDealerInvoice(int id)
        {
            var tempdealer = context.Dealers.FirstOrDefault(f => f.DealerId == id);
            try
            {
                List<Invoice> result = new List<Invoice>();
                result = context.Invoices.Where(c => c.DealerEmail.Equals(tempdealer.DealerEmail)).ToList();
                return result;
            }
            catch (Exception ex)
            {
                return new List<Invoice>();
            }
        }
    }
}
