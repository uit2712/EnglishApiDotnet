using Core.EnglishContext;
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

builder.Services.AddScoped<TopicRepositoryInterface, TopicRepository>();
builder.Services.AddScoped<CachedTopicRepositoryInterface, CachedTopicRepository>();

builder.Services.AddScoped<GetListVocabulariesByTopicIdUseCase, GetListVocabulariesByTopicIdUseCase>();

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
