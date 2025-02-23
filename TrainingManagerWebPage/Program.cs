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
	options.AddPolicy("AllowAllOrigins",
		policy => policy.AllowAnyOrigin()  // This allows all origins
						.AllowAnyMethod()  // Allow any HTTP method (GET, POST, etc.)
						.AllowAnyHeader()); // Allow any headers
});


var app = builder.Build();

// https://localhost:7244/swagger/index.html 

if (app.Environment.IsDevelopment()) { 
app.UseSwagger();
app.UseSwaggerUI(options => { 
	options.SwaggerEndpoint("/swagger/v1/swagger.json", "TEST API V1");
});
}
app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
