using Microsoft.EntityFrameworkCore;

namespace EMPTodoListBcknd.Models
{
    public partial class DBContext: DbContext
    {

      public DBContext(DbContextOptions <DBContext> options): base(options)
        {}  
        public virtual DbSet<User> User {get;set;}
        public virtual DbSet<State> State {get;set;}
        public virtual DbSet<Category> Category {get;set;}
        public virtual DbSet<Task> Task {get;set;}
        public virtual DbSet<List> List {get;set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
           modelBuilder.Entity<User>(entity => {
               entity.HasKey(k => k.UserId);
           });
           OnModelCreatingPartial(modelBuilder);
       }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}