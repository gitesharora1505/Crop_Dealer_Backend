using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Crop_Dealer.Model;

public partial class CropDealContext : DbContext
{


    public CropDealContext(DbContextOptions<CropDealContext> options)
        : base(options)
    {
    }

    public DbSet<Admin> Admins { get; set; }

    public DbSet<BankDetail> BankDetails { get; set; }

    public DbSet<Crop> Crops { get; set; }

    public DbSet<Dealer> Dealers { get; set; }

    public DbSet<Farmer> Farmers { get; set; }

    public DbSet<Invoice> Invoices { get; set; }

    public DbSet<Subscribe> Subscribes { get; set; }

    public DbSet<Type> Types { get; set; }
}

   