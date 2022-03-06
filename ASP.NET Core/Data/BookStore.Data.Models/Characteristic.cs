namespace BookStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using BookStore.Data.Common.Models;

    public class Characteristic : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(50)]
        public string Author { get; set; }

        [Required]
        [MaxLength(3000)]
        public int Pages { get; set; }

        [Required]
        [MaxLength(20)]
        public string Cover { get; set; }

        [Required]
        [MaxLength(30)]
        public string Language { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string DateOfPublication { get; set; }

        [Required]
        [MaxLength(6)]
        public string IdOfBook { get; set; }

        [Required]
        [MinLength(14)]
        [MaxLength(14)]
        public string ISBN { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
//Автор сър Артър Конан Дойл
//Страници 141
//Корица мека
//Език български
//Година 2022
//Дата на получаване 24.02.2022 г.
//Издателство Фама +
//ID на книга 614126
//ISBN 9786191781263
//Категории Световна класика