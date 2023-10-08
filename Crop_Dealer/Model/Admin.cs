using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Crop_Dealer.Model;

public partial class Admin
{
    [Key]
    public int AdminId { get; set; }

    public string Email { get; set; }
    public string Password { get; set; } 
}
