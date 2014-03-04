using HelloAspAngular.Domain;
using HelloAspAngular.Domain.TodoLists;
using HelloAspAngular.Infra.TodoLists;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HelloAspAngular.Infra
{
    public class AppContext: DbContext
    {
        // EntityFramework.SqlServer.dllがbinにコピーされるようにする。
        private static Type _dummyForDllCopy = typeof(System.Data.Entity.SqlServer.SqlProviderServices);

        static AppContext()
        {
            Database.SetInitializer(new AppDbInitializer());
        }

        public DbSet<TodoList> TodoLists { get; set; }
        public DbSet<Todo> Todos { get; set; }

        public AppContext()
            : base("HelloAspAngular")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TodoListMap());
            modelBuilder.Configurations.Add(new TodoMap());
        }
    }
}
