using Core.Features.Group.Entities;
using Core.Features.Topic.Entities;
using Core.Features.Vocabulary.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.EnglishContext;

public class EnglishContext : DbContext, IEnglishContext
{
    public EnglishContext(DbContextOptions<EnglishContext> options)
        : base(options)
    {
    }

    public DbSet<VocabularyEntity> Vocabularies { get; set; } = null!;
    public DbSet<TopicEntity> Topics { get; set; } = null!;
    public DbSet<GroupEntity> Groups { get; set; } = null!;
}