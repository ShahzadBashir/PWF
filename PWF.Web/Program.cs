using Microsoft.EntityFrameworkCore;
using PWF.Services.Mail;
using PWF.Services.Settings;
using PWF.Web.Data;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddDbContext<PWFContext>(option => option.UseSqlServer("Server=DESKTOP-T42HDB4\\SQLEXPRESS; Database=PWFDb; Trusted_Connection=True;"));
builder.Services.AddRazorPages();

builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EMailSettings"));
builder.Services.AddSingleton<IMailService, EmailService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
