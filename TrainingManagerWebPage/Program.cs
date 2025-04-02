using System.Text.Json.Serialization;
using TrainingManagerAPI.BusinessLogic;
using TrainingManagerAPI.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

//DI IConfiguartion
builder.Services.AddScoped<TrainingDocumentLogic>();
builder.Services.AddScoped<TrainingDocumentAccess>();

builder.Services.AddScoped<EmployeeTrainingDocumentLogic>();
builder.Services.AddScoped<EmployeeTrainingDocumentAccess>();

builder.Services.AddScoped<EmployeeLogic>();
builder.Services.AddScoped<EmployeeAccess>();

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowOrigins",
		policy => policy.WithOrigins("http://localhost:5173") //react origin
						.AllowAnyMethod()  
						.AllowAnyHeader()); 
});

builder.Services.AddControllers()
	.AddJsonOptions(options =>
	{
		options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
	});

var app = builder.Build();

// https://localhost:7244/swagger/index.html 

if (app.Environment.IsDevelopment()) { 
app.UseSwagger();
app.UseSwaggerUI(options => { 
	options.SwaggerEndpoint("/swagger/v1/swagger.json", "TEST API V1");
});
}
app.UseCors("AllowOrigins");

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
