
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

//getting my connection string
var connectionString = builder.Configuration.GetConnectionString("MyDbConnection");
SqlConnection connection = new SqlConnection(connectionString);


// Add services to the container.
builder.Services.AddSingleton(connection);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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
