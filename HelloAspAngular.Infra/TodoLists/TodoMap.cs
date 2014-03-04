using HelloAspAngular.Domain.TodoLists;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloAspAngular.Infra.TodoLists
{
    internal class TodoMap : EntityTypeConfiguration<Todo>
    {
        public TodoMap()
        {
            this.ToTable("Todos");

            this.HasKey(t => t.Id);

            this.Property(t => t.Text).IsRequired();
        }
    }
}
