using LibraryTestWeek5.Models;
//using NuGet.LibraryModel;

namespace LibraryTestWeek5.viewModels
{
    public class viewModelToCreateBook
    {
        public List<Library>? libraries { get; set; }

        public List<Shelf>? shelves { get; set; }

        public Book? book { get; set; }

        public int? ShelfId { get; set; }
        public int? LibId { get; set; }

    }
}
