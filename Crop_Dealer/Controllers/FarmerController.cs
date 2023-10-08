using Crop_Dealer.Model;
using Crop_Dealer.Repository.CropRepo;
using Crop_Dealer.Repository.FarmerUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Crop_Dealer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmerController : ControllerBase
    {
        IFarmeReg farmerReg;
        IAddCrops addCrops;
        IEditCrop editCrop;
        IDeleteCrops deleteCrop;
        IViewCrops viewCrops;
        IBankDetails bankDetails;
        IEditFarmerDetails editFarmerDetails;
        IFarmerInvoice farmerInvoice;
        public FarmerController(IFarmeReg farmerReg,IAddCrops addCrops,IEditCrop editCrop,IDeleteCrops deleteCrops,IViewCrops viewCrops,
            IBankDetails bankDetails,IEditFarmerDetails editFarmerDetails, IFarmerInvoice farmerInvoice)
        {
            this.farmerReg = farmerReg;
            this.addCrops = addCrops;
            this.editCrop = editCrop;
            this.deleteCrop= deleteCrops;
            this.viewCrops = viewCrops;
            this.bankDetails = bankDetails;
            this.editFarmerDetails = editFarmerDetails;
            this.farmerInvoice = farmerInvoice;
        }
        
        #region registraion
        [HttpPost("Farmer_Registration")]
        [AllowAnonymous]
        public ActionResult AddFarmer(Model.Farmer farmer)
        {
            string result = farmerReg.AddFarmer(farmer);
            if(result == "Farmer Added Successfully")
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion
        #region Add crop
        [HttpPost("Add_Crop")]
        [Authorize(Roles ="Farmer,Admin")]
        public ActionResult AddCrop(Model.Crop crop)
        {
            var farmerclaim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            int farmerid = int.Parse(farmerclaim.Value);
            string result= addCrops.AddCrop(crop,farmerid);
            if(result== "Crop Added Successfully")
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion
        #region Edit crop
        [HttpPut("Edit_Crop")]
        [Authorize(Roles = "Farmer")]
        public ActionResult EditCrop(Model.Crop crop)
        {
            string result = editCrop.EditCrop(crop);
            if (result == "Updated Successfully")
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion
        #region delete crop
        [HttpDelete("Delete_Crop")]
        [Authorize(Roles = "Farmer,Admin")]
        public ActionResult DeleteCrop(int id)
        {
            string result = deleteCrop.DeleteCrop(id);
            if (result == "Deleted Successfully")
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion
        #region ViewCrops
        [HttpGet("View_Crop")]
        [Authorize(Roles = "Farmer")]
        public IActionResult ViewCrop()
        {
            var farmerclaimId= HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            int farmerId = int.Parse(farmerclaimId.Value);
            List<Crop> result = viewCrops.ViewCrop(farmerId);
            if (result.Count>0)
            {
                return Ok(result);
            }
            return NotFound("No Crops By This Farmer Id");
        }
        #endregion
        #region Add bank details
        [HttpPost("Bank_Details")]
        [AllowAnonymous]
        public IActionResult AddBankDetails(BankDetail bankdetails)
        {
            string result = bankDetails.AddDetails(bankdetails);
            if(result== "Bank Details Added Successfully")
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion
        #region Edit bank details
        [HttpPut("Edit_Bank_Details")]
        [Authorize(Roles ="Farmer,Admin")]
        public IActionResult EditBankDetails(BankDetail bankdetails)
        {
            string result = bankDetails.EditDetails(bankdetails);
            if (result == "Bank Details Updated Successfully")
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion
        #region Edit profile
        [HttpPut("Edit_Farmer_Profile")]
        [Authorize(Roles = "Farmer,Admin")]
        public ActionResult EditProfile(Farmer farmer)
        {
            string result = editFarmerDetails.NewDetails(farmer);
            if (result == "Farmer Updated Successfully")
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion
        #region Invoice
        [HttpGet("View_Farmer_Invoice")]
        [Authorize(Roles = "Farmer")]
        public IActionResult ViewFarmerInvoice()
        {
            var farmerclaimId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            int farmerId = int.Parse(farmerclaimId.Value);
            List<Invoice> result = farmerInvoice.GetFarmerInvoice(farmerId);
            if (result.Count > 0)
            {
                return Ok(result);
            }
            return NotFound("No Invoice By This Farmer Id");
        }
        #endregion
    }
}
//If the id can go to frontend edit crop table by removing farmeremail and add farmerid
//remove rating from farmer table