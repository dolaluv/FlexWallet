using AutoMapper;
using FlexWallet.Abstractions.Helper;
using FlexWallet.Abstractions.Services.Business;
using FlexWallet.Abstractions.Services.Data;
using FlexWallet.Data.Mock;
using FlexWallet.Data.Service;
using FlexWallet.Data.Service.Data;
using FlexWallet.Mapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});




builder.Services.AddScoped<IWalletTransactionService, WalletTransactionService>(); 
builder.Services.AddScoped<IAccountService, AccountService>();
 
AppSettings appSettings = builder.Configuration.GetSection("AppSettings").Get<AppSettings>();
builder.Services.AddSingleton(appSettings);
ConfigurationManager configuration = builder.Configuration;

IMapper mapper = MapConfig.RegristerMapper().CreateMapper();
builder.Services.AddSingleton(mapper);

if (appSettings.UseMock)
{

    builder.Services.AddScoped<IAccountDataService, MockAccountDataService>();
    builder.Services.AddScoped<IWalletTransactionDataService, MockWalletTransactionDataService>();


}
else
{

    builder.Services.AddScoped<IAccountDataService, AccountDataService>();
    builder.Services.AddScoped<IWalletTransactionDataService, WalletTransactionDataService>();

}

// Adding Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

// Adding Jwt Bearer
.AddJwtBearer(options =>
 {
     options.SaveToken = true;
     options.RequireHttpsMetadata = false;
     options.TokenValidationParameters = new TokenValidationParameters()
     {
         ValidateIssuer = true,
         ValidateAudience = true,
         ValidAudience = configuration["JWT:ValidAudience"],
         ValidIssuer = configuration["JWT:ValidIssuer"],
         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
     };
 });

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseAuthorization();

app.MapControllers();

app.Run();
