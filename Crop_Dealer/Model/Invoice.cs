using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crop_Dealer.Model;

public partial class Invoice
{
    [Key]
    public int InvoiceId { get; set; }

    [Required]
    public double Amount { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    public string FarmerEmail { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    public string DealerEmail { get; set; }

    [Required]
    public int CropId { get; set; }
}
