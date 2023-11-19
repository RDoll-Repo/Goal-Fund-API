using GoalFundApi.Models;
using OmniGLM_API.db;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// TODO: Cleanup later
builder.Services.AddScoped<IQuestService, QuestService>();
builder.Services.AddScoped<IGoalService, GoalService>();
builder.Services.AddScoped<IQuestRepository, QuestRepository>();
builder.Services.AddScoped<IGoalRepository, GoalRepository>();
builder.Services.AddScoped(typeof(IEFCoreService<,>), typeof(EFCoreService<,>));


var configManager = builder.Configuration;
var config = new ApplicationConfig();
configManager.Bind("Application", config);
builder.Services.AddSingleton<ApplicationConfig>(provider => config);

builder.Services.AddDbContext<ApplicationContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
