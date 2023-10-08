using Crop_Dealer.Model;

namespace Crop_Dealer.Repository.FarmerUser
{
    public class EditFarmerDetails:IEditFarmerDetails
    {
        CropDealContext _context;
        public EditFarmerDetails(CropDealContext context)
        {
            _context = context;
        }

        public string NewDetails(Farmer details)
        {
            try
            {
                if (_context.Farmers.Any(f => f.FarmerId.Equals(details.FarmerId)))
                {
                    _context.Farmers.Update(details);
                    _context.SaveChanges();
                    return "Farmer Updated Successfully";
                }
                return "Farmer Id Not Found";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
