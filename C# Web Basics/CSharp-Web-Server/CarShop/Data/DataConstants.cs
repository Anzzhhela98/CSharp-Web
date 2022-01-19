namespace CarShop.Data
{
    public class DataConstants 
    {
        public const int IdMaxLenght = 40;
        public const int DefaultMaxLenght = 20;

        //User
        public const int UserMinUserName = 4;
        public const int UserMinPassword = 5;
        public const string UserTypeMechanic = "Mechanic";
        public const string UserTypeClient= "Client";

        //Car
        public const int carModelMinLength = 5;
        public const string carPlateNumberRegularExpression = @"[A-Z]{2}[0-9]{4}[A-Z]{2}";
        public const int minYear = 1990;
        public const int maxYear = 2022;
    }
}
