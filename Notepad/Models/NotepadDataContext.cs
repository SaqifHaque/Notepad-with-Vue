using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notepad.Models
{
    public class NotepadDataContext : DbContext
    {
        public NotepadDataContext(DbContextOptions <NotepadDataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        virtual public DbSet<User> Users { get; set; }

    }
}
