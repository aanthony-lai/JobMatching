using JobMatching.API.Configurations;
using JobMatching.DataAccess.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.SuppressAsyncSuffixInActionNames = false);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationLayerServices();
builder.Services.AddDomainServices();

builder.Services.AddDbContextService();
var app = builder.Build();
app.ConfigureApplicationMiddlewares().Run();