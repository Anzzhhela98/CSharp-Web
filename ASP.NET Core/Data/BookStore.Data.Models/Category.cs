namespace BookStore.Data.Models
{
    using BookStore.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        public string Type { get; set; }
    }
}
