using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crop_Dealer.Model;

public partial class Crop
{
    [Key]
    public int CropId { get; set; }
    [Required]
    public string CropName { get; set; }
    [Required]
    public string Crop_Type { get; set; }
    [Required]
    public double Quatity { get; set; }
    [Required]
    public double PricePerKg { get; set; }
    [Required]
    [DataType(DataType.EmailAddress)]
    public string FarmerEmail { get; set; }

    [Required]
    public string CropLocation { get; set; }

}
