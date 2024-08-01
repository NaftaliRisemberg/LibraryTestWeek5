using Microsoft.EntityFrameworkCore;
using LibraryTestWeek5.Models;

namespace LibraryTestWeek5.DAL

{
    public class DataLayer : DbContext
    {
        public DataLayer(string ConnectionString) : base(GetOptions(ConnectionString))
        {
            Database.EnsureCreated();

            Seed();
        }

        private void Seed()
        {
            if (libraries.Count() > 0)
            {
                return;
            }

            Library firstLibrary = new Library();
            firstLibrary.Genre = "חסידות";
            
            Shelf s = new Shelf(); 
            s.Width = 25;
            s.Height = 25;
            s.Library = firstLibrary;
            s.Name = "a1";
            s.LibId = 1;
            Book b = new Book();
            b.Title = "Balh";
            b.Shelf = s;
            b.Library = firstLibrary;
            b.Height = 25;
            b.Width = 25;
            libraries.Add(firstLibrary);
            shelves.Add(s);
            books.Add(b);
            SaveChanges();

        }

        
        public DbSet<Library> libraries { get; set; }

        public DbSet<Shelf> shelves { get; set; }

        public DbSet<Book> books { get; set; }

        private static DbContextOptions GetOptions(string ConnectionString)
        {
            return SqlServerDbContextOptionsExtensions
                .UseSqlServer(new DbContextOptionsBuilder(), ConnectionString)
                .Options;
        }
    }
}
