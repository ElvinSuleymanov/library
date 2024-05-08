using library.API;
using library.Application;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddMediator();
builder.Services.AddDependencies();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapSwagger();
app.MapControllers();

app.Run();
