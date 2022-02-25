namespace FootballManager.Data
{
    public class DataConstants
    {
        //User
        public const int MinUsernameLength = 5;
        public const int MinUserPasswordLength = 6;
        public const int MaxUserLength = 20;

        public const int MinUserEmail = 10;
        public const int MaxUserEmail = 60;

        //Player
        public const int MinPalyerFullNameLength = 5;
        public const int MaxPalyerFullNameLength = 80;

        public const int MinPalyerPositionLength = 5;
        public const int MaxPalyerPositionLength = 20;


        public const int MinPalyerSpeedLength = 0;
        public const int MaxPalyerSpeedLength = 10;


        public const int MinPalyerEnduranceLength = 0;
        public const int MaxPalyerEnduranceLength = 10;

        public const int MaxPalyerDescriptionLength = 200;
    }
}


//•	Has Id – an int, Primary Key
//•	Has FullName – a string (required); min.length: 5, max.length: 80
//•	Has ImageUrl – a string (required)
//•	Has Position – a string (required); min.length: 5, max.length: 20
//•	Has Speed – a byte (required); cannot be negative or bigger than 10
//•	Has Endurance – a byte (required); cannot be negative or bigger than 10
//•	Has a Description – a string with max length 200 (required)
//•	Has UserPlayers collection