var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// https://localhost:7244/swagger/index.html 

if (app.Environment.IsDevelopment()) { 
app.UseSwagger();
app.UseSwaggerUI(options => { 
	options.SwaggerEndpoint("/swagger/v1/swagger.json", "TEST API V1");
});
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
