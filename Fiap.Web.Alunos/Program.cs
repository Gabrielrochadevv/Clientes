using AutoMapper;
using Fiap.Web.Alunos.Data;
using Fiap.Web.Alunos.Data.Repository;
using Fiap.Web.Alunos.Models;
using Fiap.Web.Alunos.Services;
using Fiap.Web.Alunos.ViewModel;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Configuracao do  DB
var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<DatabaseContext>(
    
    opt => opt.UseOracle(connectionString).EnableSensitiveDataLogging(true)
    );
#endregion

#region
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IRepresentanteRepository, RepresentanteRepository>();

builder.Services.AddScoped<IRepresentanteService, RepresentanteService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
#endregion


#region AutorMapper
var mapperConfig = new AutoMapper.MapperConfiguration( c =>
{ 
    c.AllowNullCollections = true;
    c.AllowNullDestinationValues = true;

    c.CreateMap<ClienteModel, ClienteCreateViewModel>();
    c.CreateMap<ClienteCreateViewModel, ClienteModel>();

}
);
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
#endregion


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
