using Crop_Dealer.Model;

namespace Crop_Dealer.Repository.AdminUser
{
    public class AllInvoice : IAllInvoices
    {
        CropDealContext _context;
        public AllInvoice(CropDealContext context)
        {
            _context = context;
        }
        public List<Invoice> GetAllInvoices()
        {
            try
            {
                return _context.Invoices.ToList();
            }
            catch
            {
                return new List<Invoice>();
            }
        }
    }
}
