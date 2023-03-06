using AboutMe.Backend.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterBuilder();
var app = builder.Build();
app.RegisterApplication();
app.Start();