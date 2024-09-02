using Core.EnglishContext;
using Core.Features.Group.DependencyInjection;
using Core.Features.Topic.DependencyInjection;
using Core.Features.Topic.InterfaceAdapters;
using Core.Features.Topic.Repositories;
using Core.Features.Topic.UseCases;
using Core.Features.Vocabulary.InterfaceAdapters;
using Core.Features.Vocabulary.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EnglishContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("RedisConStr");
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<VocabularyRepositoryInterface, VocabularyRepository>();
builder.Services.AddScoped<CachedVocabularyRepositoryInterface, CachedVocabularyRepository>();

TopicDependencyInjection.Init(builder.Services);
GroupDependencyInjection.Init(builder.Services);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://0.0.0.0:8080")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles(); // 🔴 here it is
app.UseRouting(); // 🔴 here it is

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
