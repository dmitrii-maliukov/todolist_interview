using Microsoft.EntityFrameworkCore;

namespace TodoList.EntityFrameworkRepository;

public class TodoListDbContext : DbContext
{
    public DbSet<TodoListEntity> TodoLists => Set<TodoListEntity>();
    public DbSet<TodoListItemEntity> TodoListItems => Set<TodoListItemEntity>();

    public TodoListDbContext(DbContextOptions<TodoListDbContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoListEntity>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Title).IsRequired().HasMaxLength(50);
            entity.Property(x => x.Description).HasMaxLength(100);
            entity.Property(x => x.CreatedAt).IsRequired();

            entity
                .HasMany(x => x.Items)
                .WithOne(x => x.TodoList)
                .HasForeignKey(x => x.TodoListId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<TodoListItemEntity>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Title).IsRequired().HasMaxLength(50);
            entity.Property(x => x.Description).HasMaxLength(100);
            entity.Property(x => x.IsCompleted).IsRequired().HasDefaultValue(false);
            entity.Property(x => x.CreatedAt).IsRequired();
        });

        DataSeeding.SeedInitialData(modelBuilder);
    }
}