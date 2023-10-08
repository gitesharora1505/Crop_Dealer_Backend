using Crop_Dealer.Model;
using System.ComponentModel.DataAnnotations;

namespace Crop_Dealer.Repository.DealerUser
{
    public class BuyCrops : IBuyCrops
    {
        CropDealContext _context;
        ISendEmail sendEmail;
        public BuyCrops(CropDealContext context, ISendEmail sendEmail)
        {
            _context = context;
            this.sendEmail = sendEmail;
        }

        public Invoice InvoiceGenerate(int cropId, int dealerId, double quantity)
        {
            Invoice result = new Invoice();
            BankDetail bankDetail = new BankDetail();
            try
            {
                var cropdetails = _context.Crops.FirstOrDefault(c => c.CropId == cropId);
                if(cropdetails.Quatity<quantity)
                {
                    result.InvoiceId = 401;//Not sufficient quantity available
                    return result;
                }
                bankDetail = _context.BankDetails.FirstOrDefault(b => b.FarmerEmail.Equals(cropdetails.FarmerEmail));
                var dealerdetails = _context.Dealers.FirstOrDefault(d => d.DealerId == dealerId);
                double amount = cropdetails.PricePerKg * quantity;
                if (cropdetails != null && dealerdetails != null)
                {
                    result.Amount = amount;
                    result.Date = DateTime.Now;
                    result.FarmerEmail = cropdetails.FarmerEmail;
                    result.DealerEmail = dealerdetails.DealerEmail;
                    result.CropId = cropId;
                    sendEmail.InvoiceMail(cropdetails.FarmerEmail, "Farmer Invoice", result, quantity,bankDetail);
                    sendEmail.InvoiceMail(dealerdetails.DealerEmail, "Dealer Invoice", result, quantity,bankDetail);
                    _context.Invoices.Add(result);
                    _context.SaveChanges();
                }
                cropdetails.Quatity = cropdetails.Quatity - quantity;
                _context.Crops.Update(cropdetails);
                _context.SaveChanges();
                return result;
            }
            catch
            {
                return result;
            }
           
        }
    }
}