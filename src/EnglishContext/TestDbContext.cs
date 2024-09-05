using Core.Features.Group.Entities;
using Core.Features.Topic.Entities;
using Core.Features.Vocabulary.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.EnglishContext;

public class TestDbContext : DbContext, IEnglishContext
{
    public virtual DbSet<VocabularyEntity> Vocabularies { get; set; } = null!;
    public virtual DbSet<TopicEntity> Topics { get; set; } = null!;
    public virtual DbSet<GroupEntity> Groups { get; set; } = null!;
}