using Crop_Dealer.Model;
using Crop_Dealer.Repository.AdminUser;
using Crop_Dealer.Repository.DealerUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crop_Dealer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class AdminController : ControllerBase
    {
        IAllInvoices allInvoices;
        IAllFarmer allFarmer;
        IAllDealer allDealer;
        IDeleteDealer deleteDealer;
        IDeleteFarmer deleteFarmer;
        IDeleteinvoice deleteinvoice;
        IDeleteBankDetails deletebankdetails;
        public AdminController(IAllInvoices allInvoices, IAllFarmer allFarmer, IAllDealer allDealer, IDeleteDealer deleteDealer, 
            IDeleteFarmer deleteFarmer, IDeleteinvoice deleteinvoice, IDeleteBankDetails deletebankdetails)
        {
            this.allInvoices = allInvoices;
            this.allFarmer = allFarmer;
            this.allDealer = allDealer;
            this.deleteDealer = deleteDealer;
            this.deleteFarmer = deleteFarmer;
            this.deleteinvoice = deleteinvoice;
            this.deletebankdetails = deletebankdetails;
        }

        #region InvoiceAll
        [HttpGet("All_Invoice")]
        public IActionResult AllInvoice()
        {
            List<Invoice> result = allInvoices.GetAllInvoices();
            if (result.Count > 0)
            {
                return Ok(result);
            }
            return NotFound("No Invoice");
        }
        #endregion
        #region DeleteInvoice
        [HttpDelete("Delete_Invoice")]
        public IActionResult DeleteInvoices(int id)
        {
            string result = deleteinvoice.DeleteInvoice(id);
            if (result == "Deleted Successfully")
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion
        #region ViewFarmers
        [HttpGet("All_Farmers")]
        public IActionResult AllFarmers()
        {
            List<Farmer> result = allFarmer.GetAllFarmers();
            if (result.Count > 0)
            {
                return Ok(result);
            }
            return NotFound("No Farmer");
        }
        #endregion
        #region ViewDealers
        [HttpGet("All_Dealers")]
        public IActionResult AllDealers()
        {
            List<Dealer> result = allDealer.GetAllDealers();
            if (result.Count > 0)
            {
                return Ok(result);
            }
            return NotFound("No Dealer");
        }
        #endregion
        #region DeleteFarmers
        [HttpDelete("Delete_Farmer")]
        public IActionResult DeleteFarmers(int id)
        {
            string result = deleteFarmer.Deletefarmer(id);
            if (result == "Deleted Successfully")
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion
        #region DeleteDealers
        [HttpDelete("Delete_Dealer")]
        public IActionResult DeleteDealers(int id)
        {
            string result = deleteDealer.DeleteDealer(id);
            if (result == "Deleted Successfully")
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion
        #region Delete Bank Details
        [HttpDelete("Delete_Bank_Details")]
        public IActionResult DeleteBank(int id)
        {
            string result = deletebankdetails.deleteBankdetail(id);
            if (result == "Deleted Successfully")
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion
    }
}
