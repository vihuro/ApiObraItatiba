using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ObraItatiba.Context;
using ObraItatiba.Dto.Time;
using ObraItatiba.Interface.Login;
using ObraItatiba.Interface.NotasRadar;
using ObraItatiba.Interface.NotasTHR;
using ObraItatiba.Interface.Time;
using ObraItatiba.Service.Claims;
using ObraItatiba.Service.JWT;
using ObraItatiba.Service.Mapping.ClaimForUser;
using ObraItatiba.Service.Mapping.ClaimType;
using ObraItatiba.Service.Mapping.ListClaimsForUser;
using ObraItatiba.Service.Mapping.Notas;
using ObraItatiba.Service.Mapping.Times;
using ObraItatiba.Service.Mapping.Usuario;
using ObraItatiba.Service.NotasFiscais;
using ObraItatiba.Service.Time;
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
builder.Services.AddScoped<ITimeService, TimeService>();
builder.Services.AddScoped<INotasRadarService, NotasFiscaisTxt>();
builder.Services.AddScoped<INotasThrService, NotasThrService>();
builder.Services.AddScoped<IparcelasService, ParcelasService>();
builder.Services.AddScoped<IProdutoServicoService, ProdutoServicoService>();


builder.Services.AddAutoMapper(x =>
{
    x.AddProfile(typeof(RetornoUsuarioMapping));
    x.AddProfile(typeof(RetornoClaimMapping));
    x.AddProfile(typeof(ClaimsForUserMapping));
    x.AddProfile(typeof(ClaimsForUserDtoMappgin));
    x.AddProfile(typeof(ListClaimsForUserMapping));
    x.AddProfile(typeof(RetornoTimeMapping));
    x.AddProfile(typeof(RetornoNotaThrMapping));
    x.AddProfile(typeof(NumeroDocumentoMapping));
    x.AddProfile(typeof(ProdutoResumidoMapping));
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
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("corsPolicy");

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
