using UsersApi.Extensions.Container;
using UsersApi.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.InstallServicesInAssembly(builder.Configuration);

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddResponseCompression(options => options.EnableForHttps = true);

builder.Services.AddAuthentication();

builder.Services
    .AddMvc(options =>
    {
        options.EnableEndpointRouting = false;
        options.Filters.Add<ValidationFilter>();
        options.Filters.Add<ExceptionFilter>();
    });

builder.Services.AddAutoMapper(typeof(Program));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGenNewtonsoftSupport(); // explicit opt-in

var app = builder.Build();

app.UseHsts();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseResponseCompression();

app.UseAuthorization();

app.MapControllers();

app.Run();