// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Hangfire;
using Hangfire.PostgreSql;
using HangfireSample.Web;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<SimpleJob>();
builder.Services.AddHangfire(configuration =>
  configuration.UsePostgreSqlStorage(options => options.UseNpgsqlConnection(builder.Configuration.GetConnectionString("HANGFIRE"))));
builder.Services.AddHangfireServer();

WebApplication app = builder.Build();
app.UseHangfireDashboard
(
  pathMatch: "/hangfire",
  options  : new DashboardOptions
  {
    Authorization = [new AnonymousAuthorizationFilter()],
  }
);
BackgroundJob.Schedule<SimpleJob>(job => job.Execute("BackgroudJob"), TimeSpan.FromSeconds(10));
RecurringJob.AddOrUpdate<SimpleJob>("RecurringJob", job => job.Execute("RecurringJob"), Cron.Minutely);
app.MapGet("/", () => "Hangfire sample working...");
app.Run();
