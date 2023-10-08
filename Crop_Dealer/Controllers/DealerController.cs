using Crop_Dealer.Model;
using Crop_Dealer.Repository.DealerUser;
using Crop_Dealer.Repository.FarmerUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Crop_Dealer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealerController : ControllerBase
    {
        IDealerReg dealerReg;
        IEditDealerDetails editDealerDetails;
        IDealerInvoice dealerInvoice;
        IViewAllCrops viewAllCrops;
        IBuyCrops buyCrops;
        ISub sub;
        public DealerController(IDealerReg dealerReg,IEditDealerDetails editDealerDetails, IDealerInvoice dealerInvoice, IViewAllCrops viewAllCrops, 
            IBuyCrops buyCrops,ISub sub)
        {
            this.dealerReg = dealerReg;
            this.editDealerDetails = editDealerDetails;
            this.dealerInvoice = dealerInvoice;
            this.viewAllCrops = viewAllCrops;
            this.buyCrops = buyCrops;
            this.sub = sub;
        }
        #region Registration
        [HttpPost("Dealer Registration")]
        [AllowAnonymous]
        public ActionResult AddDealer(Model.Dealer dealer)
        {
            string result = dealerReg.AddDealer(dealer);
            if (result == "Dealer Added Successfully")
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion
        #region Edit Profile
        [HttpPut("Edit_Dealer_Profile")]
        [Authorize(Roles ="Dealer,Admin")]
        public IActionResult EditProfile(Dealer dealer)
        {
            string result=editDealerDetails.NewDetails(dealer);
            if(result== "Dealer Updated Successfully")
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion
        #region Invoice
        [HttpGet("View_Dealer_Invoice")]
        [Authorize(Roles = "Dealer")]
        public IActionResult ViewDealerInvoice()
        {
            var dealerclaimId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            int dealerId = int.Parse(dealerclaimId.Value);
            List<Invoice> result = dealerInvoice.GetDealerInvoice(dealerId);
            if (result.Count > 0)
            {
                return Ok(result);
            }
            return NotFound("No Invoice By This Dealer Id ");
        }
        #endregion
        #region ViewAllCrops
        [HttpGet("View_All_Crops")]
        [Authorize(Roles ="Dealer,Admin")]
        public IActionResult AllCrops()
        {
            List<Crop> result = viewAllCrops.ViewCrop();
            if (result.Count > 0)
            {
                return Ok(result);
            }
            return NotFound("No Crops");
        }
        #endregion
        #region BuyCrops
        [HttpPost("Buy_Crops")]
        [Authorize(Roles ="Dealer")]
        public IActionResult BuyCrops(int cropId,double quantity)
        {
            var dealerclaim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            int dealerid = int.Parse(dealerclaim.Value);
            Invoice generated=buyCrops.InvoiceGenerate(cropId,dealerid,quantity);
            if(generated!=null)
            {
                if(generated.InvoiceId==401)
                {
                    return BadRequest("Quantity Not Available");
                }
                return Ok(generated);
            }
            return BadRequest("Error occured please retry");
        }
        #endregion
        #region Subscribe
        [HttpPost("Subscribe_Crop")]
        [Authorize(Roles ="Dealer")]
        public IActionResult AddSub(string cropname)
        {
            var dealerclaim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            int dealerid = int.Parse(dealerclaim.Value);
            string result=sub.AddSubscription(cropname, dealerid);
            if(result.Equals("Subscribed to " + cropname))
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion
        #region Unsubscribe
        [HttpDelete("Unsubscribe_Crop")]
        [Authorize(Roles = "Dealer,Admin")]
        public IActionResult UnSub(string cropname, string dealermail)
        {
            string result = sub.deleteSubscription(cropname, dealermail);
            if (result.Equals("Unsubscribed " + cropname))
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion
    }
}
