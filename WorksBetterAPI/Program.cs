using Microsoft.EntityFrameworkCore;
using WorksBetterAPI.Models;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

builder.Configuration.AddEnvironmentVariables().AddJsonFile("appsettings.json");
var connection = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<EmployeesContext>(opt => opt.UseSqlServer(connection));
builder.Services.AddDbContext<CustomersContext>(opt => opt.UseSqlServer(connection));
builder.Services.AddDbContext<JobOrdersContext>(opt => opt.UseSqlServer(connection));
builder.Services.AddDbContext<AssignmentsContext>(opt => opt.UseSqlServer(connection));
builder.Services.AddDbContext<UsersContext>(opt => opt.UseSqlServer(connection));
builder.Services.AddDbContext<BranchesContext>(opt => opt.UseSqlServer(connection));
builder.Services.AddDbContext<TimecardsContext>(opt => opt.UseSqlServer(connection));
builder.Services.AddDbContext<TaxSetupContext>(opt => opt.UseSqlServer(connection));
builder.Services.AddDbContext<LoginAuditContext>(opt => opt.UseSqlServer(connection));
builder.Services.AddDbContext<ProofingSessionContext>(opt => opt.UseSqlServer(connection));
builder.Services.AddDbContext<TimecardsContext>(opt => opt.UseSqlServer(connection));
builder.Services.AddDbContext<CheckRegisterContext>(opt => opt.UseSqlServer(connection));
builder.Services.AddDbContext<InvoiceRegisterContext>(opt => opt.UseSqlServer(connection));
builder.Services.AddDbContext<TransactionsContext>(opt => opt.UseSqlServer(connection));
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

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();