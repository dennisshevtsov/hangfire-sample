using Hangfire;
using Hangfire.PostgreSql;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddHangfire(configuration =>
  configuration.UsePostgreSqlStorage(options => options.UseNpgsqlConnection(builder.Configuration.GetConnectionString("HANGFIRE"))));

WebApplication app = builder.Build();
app.UseHangfireDashboard();
app.MapGet("/", () => "Hangfire sample working...");
app.Run();
