using Core.Features.Vocabulary.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.EnglishContext;

public class EnglishContext : DbContext
{
    public EnglishContext(DbContextOptions<EnglishContext> options)
        : base(options)
    {
    }

    public DbSet<VocabularyEntity> Vocabularies { get; set; } = null!;
}