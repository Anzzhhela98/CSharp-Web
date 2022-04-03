namespace BookStore.Web.ViewModels.Books
{
    using System;
    using System.Collections.Generic;

    public class BooksInListModel
    {
        public IEnumerable<BookInListModel> Books { get; set; }

        public int PageNumber { get; set; }

        public bool HasPreviousPage => this.PageNumber > 1;

        public bool HasNextPage => this.PageNumber < this.PagesCount;

        public int PreviousPageNumber => this.PageNumber - 1;

        public int NextPageNumber => this.PageNumber + 1;

        public int PagesCount => (int)Math.Ceiling((double)this.BooksCount / this.ItemsPerPage);

        public int BooksCount { get; set; }

        public int ItemsPerPage { get; set; }
    }
}
