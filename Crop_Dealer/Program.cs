using Crop_Dealer.Model;
using Crop_Dealer.Repository;
using Crop_Dealer.Repository.AdminUser;
using Crop_Dealer.Repository.CropRepo;
using Crop_Dealer.Repository.DealerUser;
using Crop_Dealer.Repository.FarmerUser;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<CropDealContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));
#region dependency
builder.Services.AddScoped<IFarmeReg,FarmerReg>();
builder.Services.AddScoped<IDealerReg, DealerReg>();
builder.Services.AddScoped<IFarmerLogin, FarmerLogin>();
builder.Services.AddScoped<IDealerLogin, DealerLogin>();
builder.Services.AddScoped<IAdminLogin, AdminLogin>();
builder.Services.AddScoped<IAddCrops, AddCrops>();
builder.Services.AddScoped<ISendEmail, SendEmail>();
builder.Services.AddScoped<IEditCrop, EditCrops>();
builder.Services.AddScoped<IDeleteCrops, DeleteCrops>();
builder.Services.AddScoped<IViewCrops, ViewCrops>();
builder.Services.AddScoped<IBankDetails, BankDetails>();
builder.Services.AddScoped<IEditFarmerDetails, EditFarmerDetails>();
builder.Services.AddScoped<IEditDealerDetails, EditDealerDetails>();
builder.Services.AddScoped<IFarmerInvoice, FarmerInvoice>();
builder.Services.AddScoped<IDealerInvoice, DealerInvoice>();
builder.Services.AddScoped<IViewAllCrops, ViewAllCrops>();
builder.Services.AddScoped<IBuyCrops, BuyCrops>();
builder.Services.AddScoped<ISub,Sub>();
builder.Services.AddScoped<IAllInvoices, AllInvoice>();
builder.Services.AddScoped<IAllDealer, AllDealer>();
builder.Services.AddScoped<IAllFarmer, AllFarmer>();
builder.Services.AddScoped<IDeleteinvoice, Deleteinvoice>();
builder.Services.AddScoped<IDeleteFarmer, Deletefarmers>();
builder.Services.AddScoped<IDeleteDealer, Deletedealer>();
builder.Services.AddScoped<IDeleteBankDetails,DeleteBankDetails>();
#endregion


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
