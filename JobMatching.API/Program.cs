using JobMatching.API.Configurations;
using JobMatching.Application.DependencyInjection;
using JobMatching.DataAccess.Context;
using JobMatching.Infrastructure.DatabaseContext;
using JobMatching.Infrastructure.DependencyInjection;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.SuppressAsyncSuffixInActionNames = false);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterApplicationServices();
builder.Services.RegisterDomainServices();
builder.Services.RegisterInfrastructureServices();
builder.Services.RegisterMediatrRequestHandlers();
builder.Services.RegisterDbContextService();

builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorization();

builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();

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