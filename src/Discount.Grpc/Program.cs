using Discount.Grpc.Interceptors;
using Discount.Grpc.Services.v1;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc(options =>
{
    options.EnableDetailedErrors = true;
    options.Interceptors.Add<ExceptionInterceptor>();
});
builder.Services.AddGrpcReflection();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<DiscountService>();

// Enable gRPC reflection
app.MapGrpcReflectionService();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
