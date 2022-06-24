using System.Text.Encodings.Web;
using System.Text.Unicode;
using Blogfa.Infrastructure.Configuration;
using Framework.Application;
using Framework.Application.SecurityUtil.Hashing;
using Framework.Presentation.Api;
using Framework.Presentation.Api.JwtTools;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var service = builder.Services;


#region html encoder

service.AddSingleton<HtmlEncoder>(HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.BasicLatin, UnicodeRanges.Arabic }));

#endregion

// Add services to the container.
builder.Services.AddControllersWithViews().
    ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            var result = new ApiResult()
            {
                IsSuccess = false,
                MetaData = new()
                {
                    Status = ApiStatusCode.BadRequest,
                    Message = Tools.HandleBadRequestErrors(context)
                }
            };
            return new BadRequestObjectResult(result);
        };
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
service.AddEndpointsApiExplorer();
service.AddSwaggerGen();

//Add Project Dependencies
service.Configuration(builder.Configuration.GetConnectionString("Default"));
FrameworkBootstrapper.Init(builder.Services);
builder.Services.AddTransient<IPasswordHasher, PasswordHasher>();
builder.Services.AddTransient<IJwtHelper, JwtHelper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
