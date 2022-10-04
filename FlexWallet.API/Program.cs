using FlexWallet.Abstractions.Helper;
using FlexWallet.Abstractions.Services.Business;
using FlexWallet.Abstractions.Services.Data;
using FlexWallet.Data.Mock;
using FlexWallet.Data.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IWalletTransactionService, WalletTransactionService>();

var getSection = builder.Configuration;
var appSettingsSection = getSection.GetSection("AppSettings");
var appSettings = appSettingsSection.Get<AppSettings>();


//IMapper mapper = MapConfig.RegristerMapper().CreateMapper();
//builder.Services.AddSingleton(mapper);

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



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
