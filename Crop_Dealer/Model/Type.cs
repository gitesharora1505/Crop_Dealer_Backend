using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Crop_Dealer.Model;

public partial class Type
{
    [Key]
    public int TypeId { get; set; }

    public string Crop_type { get; set; } 
}
