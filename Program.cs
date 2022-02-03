using Microsoft.OpenApi.Models;
using SamplePaymentService.Services;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
//builder.Services.AddGrpc();
 builder.Services.AddGrpcHttpApi();

//builder.Services.AddScoped<IGreeterService, GreeterService>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});
builder.Services.AddGrpcSwagger();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<GreeterService>();
});

// Configure the HTTP request pipeline.
//app.MapGrpcService<GreeterService>();
////app.MapGrpcService<PaymentService>();
//app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

//app.Run();
