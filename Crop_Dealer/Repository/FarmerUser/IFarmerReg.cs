using Crop_Dealer.Model;
using Microsoft.AspNetCore.Mvc;

namespace Crop_Dealer.Repository.FarmerUser
{
    public interface IFarmeReg
    {
        string AddFarmer(Farmer farmer);
    }
}
