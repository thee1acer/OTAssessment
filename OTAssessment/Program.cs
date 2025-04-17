using OT.Assessment.Database;
using OT.Assessment.Database.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOptions<ConnectionString>().BindConfiguration("REFERENCE_DB");
builder.Services.AddDbContext<OTAssessmentContext>((provider, options) =>
{
    var connectionDetails = provider.GetRequiredService<IOptions<ConnectionString>>();
    var connectionString = ConnectionStringBuilder.BuildConnectionString(connectionDetails.Value);

    options.UseSqlServer(connectionString, ops => ops.EnableRetryOnFailure());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<OTAssessmentContext>();

    context.Database.Migrate();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
