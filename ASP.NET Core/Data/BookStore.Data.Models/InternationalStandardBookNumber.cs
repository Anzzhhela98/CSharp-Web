namespace BookStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class InternationalStandardBookNumber
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Prefix { get; set; }

        [Required]
        public string RegistrationGroup { get; set; }

        [Required]
        public string Registrant { get; set; }

        [Required]
        public string Edition { get; set; }

        [Required]
        public string CheckDigit { get; set; }

        [Required]
        public bool IsStillOnNationalAgency { get; set; }
    }
}

////Структура на ISBN
////ISBN представлява поредица от цифри, като съдържа 13 елемента, структурирани в пет групи:
////префикс – 978 – GS1 префикс за ISBN,
////регистрационна група – идентифицира определена страна, географски регион или езикова област; определя се от Международната агенция за ISBN; на България са присъдени регистрационни групи 978-954 и 978-619,
////регистрант – идентифицира конкретен издател; с различна дължина е в зависимост от обема на продукцията на издателя; присъжда се от Националната агенция за ISBN в съответствие с областите (диапазоните), определени от Международната агенция за ISBN; за България издателите могат да получат 2, 3, 4 и 5-цифров индивидуален код. Определен е и общ (споделен) код 978 - 954 - 799 и 978 - 619 - 188,
////издание – идентифицира конкретен формат или издание на дадена монографична публикация. (пример: 978 - 619 - XXXX - 25),
////контролна цифра – предназначена е да валидира номера (пример: 978 - 619 - XXXX - 25 - 0