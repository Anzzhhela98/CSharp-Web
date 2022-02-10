namespace SMS.Data
{
    public class DataConstants
    {
        //User
        public const int MinUsernameLength = 5;
        public const int MinUserPasswordLength = 6;
        public const int MaxUserLength = 20;

        //Product
        public const int MinNameLength = 4;
        public const int MaxNameLength = 20;

        public const decimal MinPrice = 0.05M;
        public const decimal MaxPrice = 1000M;
    }
}
