using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Crop_Dealer.Model;

public partial class Dealer
{
    [Key]
    public int DealerId { get; set; }

    [Required]
    public string DealerName { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    public string DealerEmail { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [DataType(DataType.PhoneNumber)]
    public long Contact { get; set; }
    public string ActiveStatus { get; set; } = "Active";
}
