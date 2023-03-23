using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using ObraItatiba.Context;
using ObraItatiba.Interface.Login;
using ObraItatiba.Service.Claims;
using ObraItatiba.Service.JWT;
using ObraItatiba.Service.Mapping.ClaimForUser;
using ObraItatiba.Service.Mapping.ClaimType;
using ObraItatiba.Service.Mapping.ListClaimsForUser;
using ObraItatiba.Service.Mapping.Usuario;
using ObraItatiba.Service.Usuario;
using ObraItatiba.Settings;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("ObraItatiba");

builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<ContextBase>(options =>
    {
        options.UseNpgsql(connectionString);
        options.UseLazyLoadingProxies(true);
    });

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IClaimTypeService, ClaimTypeService>();
builder.Services.AddScoped<IClaimsForUserService, ClaimsForUserService>();
builder.Services.AddScoped<ITokenService, CreateToken>();

builder.Services.AddAutoMapper(x =>
{
    x.AddProfile(typeof(RetornoUsuarioMapping));
    x.AddProfile(typeof(RetornoClaimMapping));
    x.AddProfile(typeof(ClaimsForUserMapping));
    x.AddProfile(typeof(ClaimsForUserDtoMappgin));
    x.AddProfile(typeof(ListClaimsForUserMapping));
});

//JWT

var appSettingSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingSection);

var appSettings = appSettingSection.Get<AppSettings>();

var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(appSettings.Secret));

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = key,
        ValidateIssuer = false,
        ValidateAudience = false

    };
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(x => x.AddPolicy("corsPolicy", build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("corsPolicy");
app.UseHttpsRedirection();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
