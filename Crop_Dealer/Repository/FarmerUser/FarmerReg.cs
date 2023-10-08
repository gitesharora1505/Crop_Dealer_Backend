using Crop_Dealer.Model;
using Microsoft.AspNetCore.Mvc;

namespace Crop_Dealer.Repository.FarmerUser
{
    public class FarmerReg : IFarmeReg
    {
        CropDealContext _context;
        public FarmerReg(CropDealContext context)
        {
            this._context = context;
        }
        public string AddFarmer(Farmer farmer)
        {
            try
            {
                string email = farmer.FarmerEmail;
                if (_context.Farmers.Any(a => a.FarmerEmail == email))
                {
                    string error = "Farmer already exist";
                    return error;
                }
                _context.Farmers.Add(farmer);
                _context.SaveChanges();
                return "Farmer Added Successfully";
            }
            catch (Exception ex)
            {
                return "Not Able To Add Farmer Retry";
            }
        }
    }
}
