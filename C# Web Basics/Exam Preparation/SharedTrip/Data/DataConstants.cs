namespace SharedTrip.Data
{
    public class DataConstants
    {
        //User
        public const int MinUsernameLength = 5;
        public const int MaxUsernameLength = 20;

        public const int MinUserPasswordLength = 6;
        public const int MaxUserPasswordLength = 20;

        //Trip
        public const int MinSeatsCount = 2;
        public const int MaxSeatsCount = 6;

        public const int MaxDescriptionLength = 80;
    }
}

//•	Has a Seats – an integer with min value 2 and max value 6 (required)
//•	Has a Description – a string with max length 80 (required)
