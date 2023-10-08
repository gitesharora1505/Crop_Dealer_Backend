using Crop_Dealer.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;

namespace Crop_Dealer.Repository
{
    public class SendEmail : ISendEmail
    {
        private IConfiguration configuration;
        public SendEmail(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void CropNotify(string email, string subject, string message)
        {
            var emailSettings = configuration.GetSection("EmailSettings");
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(emailSettings["Username"], emailSettings["Password"])
            };
            using (var emailMessage = new MailMessage())
            {
                emailMessage.To.Add(new MailAddress(email));
                emailMessage.From = new MailAddress(emailSettings["FromAddress"]);
                emailMessage.Subject = subject;
                emailMessage.Body = message;
                emailMessage.IsBodyHtml = true;
                client.Send(emailMessage);
            }
        }

        public void InvoiceMail(string email, string subject,Invoice invoice,double quantity, BankDetail bankDetail)
        {
            var emailSettings = configuration.GetSection("EmailSettings");
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(emailSettings["Username"], emailSettings["Password"])
            };
            using (var emailMessage = new MailMessage())
            {
                emailMessage.To.Add(new MailAddress(email));
                emailMessage.From = new MailAddress(emailSettings["FromAddress"]);
                emailMessage.Subject = subject;
                emailMessage.Body = $"Successfull Transaction\nInvoice Id: {invoice.InvoiceId}\r\n-------------------------------------------- " +
                    $"Amount: {invoice.Amount}\r\n--------------------------------------------" +
                    $"Crop Qty: {quantity}\r\n--------------------------------------------" +
                    $"Date & Time: {invoice.Date}\r\n--------------------------------------------" +
                    $"Farmer Mail: {invoice.FarmerEmail}\r\n--------------------------------------------" +
                    $"Dealer Mail: {invoice.DealerEmail}\r\n--------------------------------------------" +
                    $"Crop Id: {invoice.CropId}\r\n--------------------------------------------" +
                    $"Bank Account Number :{bankDetail.AccountNum}\r\n--------------------------------------------" +
                    $"Account Holder Name :{bankDetail.HolderName}";

                emailMessage.IsBodyHtml = true;
                client.Send(emailMessage);
            }
        }
    }
}