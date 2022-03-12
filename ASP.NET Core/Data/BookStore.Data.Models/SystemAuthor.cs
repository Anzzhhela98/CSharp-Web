namespace BookStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class SystemAuthor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        ////регистрант – идентифицира конкретен издател; с различна дължина е в зависимост от обема на продукцията на издателя; присъжда се от Националната агенция за ISBN в съответствие с областите (диапазоните), определени от Международната агенция за ISBN; за България издателите могат да получат 2, 3, 4 и 5-цифров индивидуален код. Определен е и общ (споделен) код 978 - 954 - 799 и 978 - 619 - 188,
        public string Registrant { get; set; }

        [Required]
        public string CreatedByUserId { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }
    }
}
