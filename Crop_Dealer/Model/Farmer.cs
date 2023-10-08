using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Crop_Dealer.Model;

public partial class Farmer
{
    [Key]
    public int FarmerId { get; set; }
    [Required]
    public string FarmerName { get; set; } = null!;
    [Required]
    [DataType(DataType.EmailAddress)]
    public string FarmerEmail { get; set; } = null!;
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Required]
    [DataType(DataType.PhoneNumber)]
    public long Contact { get; set; }
    public string ActiveStatus { get; set; } = "Active";

    public int? Rating { get; set; }
}
