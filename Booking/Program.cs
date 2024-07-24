var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region Custom Cors

builder.Services.AddCors(options =>
{
    options.AddPolicy("customPolicy",r =>r.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});
#endregion

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
app.UseCors("customPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
