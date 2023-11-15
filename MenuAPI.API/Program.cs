using KissLog;
using KissLog.AspNetCore;
using KissLog.CloudListeners.Auth;
using KissLog.CloudListeners.RequestLogsListener;
using KissLog.Formatters;
using MenuAPI.API;
using MenuAPI.Utils.MappingProfiles;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddDataBaseIndentiy(builder.Configuration);
builder.Services.AddDefaultIdentity();
builder.Services.WorkUnit();
builder.Services.AddRepository();
builder.Services.AddBusiness();
builder.Services.AddIdentity();
builder.Services.AddServices();
builder.Services.AddAuthentication(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddHealthCheck(builder.Configuration);
builder.Services.AddLogging(provider =>
{
    provider
        .AddKissLog(options =>
        {
            options.Formatter = (FormatterArgs args) =>
            {
                if (args.Exception == null)
                    return args.DefaultValue;

                string exceptionStr = new ExceptionFormatter().Format(args.Exception, args.Logger);
                return string.Join(Environment.NewLine, new[] { args.DefaultValue, exceptionStr });
            };
        });
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddSwagger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseHealthChecks("/HelthCheks", new HealthCheckOptions
{
    Predicate = _ => true,
});

app.UseHealthChecksUI(options => { options.ApiPath = "/HelthCheks-UI"; });

app.UseKissLogMiddleware(options => {
    options.Listeners.Add(new RequestLogsApiListener(new Application(
        builder.Configuration["KissLog.OrganizationId"],
        builder.Configuration["KissLog.ApplicationId"])
    )
    {
        ApiUrl = builder.Configuration["KissLog.ApiUrl"]
    });
});

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
