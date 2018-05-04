using Microsoft.EntityFrameworkCore;

namespace TutoPoint.Models
{
    /*A DbContext instance represents a session with the database
     and can be used to query and save instances of your entities. 
     DbContext is a combination of the Unit Of Work and Repository patterns.*/
    // https://docs.microsoft.com/en-us/ef/core/api/microsoft.entityframeworkcore.dbcontext
    public class FirstAppDemoDbContext : DbContext
    {
        /*Each DbSet will map to a table in the database.
         If you have a property DbSet of employee, and the name of 
         that property is Employees, the Entity Framework will by default 
         look for an Employees table inside your database.*/
        /*A DbSet<TEntity> can be used to query and save instances of TEntity.
         LINQ queries against a DbSet<TEntity> will be translated into 
         queries against the database.*/
        public virtual DbSet<Employee> Employee { get; set; }
        public FirstAppDemoDbContext()
        {
        }

        /// <summary>
        /// https://docs.microsoft.com/en-us/ef/core/miscellaneous/configuring-dbcontext
        /// https://blog.oneunicorn.com/2016/10/24/ef-core-1-1-creating-dbcontext-instances/
        /// OnConfiguring is called every time a new context instance is initialized
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Gets a value indicating whether any options have been configured.
            // https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontextoptionsbuilder.isconfigured?view=efcore-2.0#Microsoft_EntityFrameworkCore_DbContextOptionsBuilder_IsConfigured
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                // https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-strings
                optionsBuilder.UseSqlServer(@"Data Source=(local);Initial Catalog=eftuto;Integrated Security=True");

                /*optionsBuilder
    .UseSqlServer(connectionString, providerOptions=>providerOptions.CommandTimeout(60))
    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);*/
            }
        }
        public FirstAppDemoDbContext(DbContextOptions<FirstAppDemoDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);
            });
        }

    }
}
