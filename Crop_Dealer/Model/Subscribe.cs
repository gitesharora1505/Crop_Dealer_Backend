using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crop_Dealer.Model;

public partial class Subscribe
{
    [Key]
    public int SubscribeId { get; set; }
    [Required]
    public string Subscribed { get; set; } = "Not Subscribed";
    [Required]
    [DataType(DataType.EmailAddress)]
    public string DealerEmail { get; set; }

    [Required]
    public string CropName { get; set; }

}
