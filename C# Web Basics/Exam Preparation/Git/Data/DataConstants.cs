namespace Git.Data
{
    public class DataConstants
    {
        //User
        public const int MinUserNameLength = 5;
        public const int MaxUserNameLength = 20;

        public const int MinUserPasswordLength = 6;
        public const int MaxUserPasswordLength = 20;

        //Repository
        public const int MinRepoNameLength = 3;
        public const int MaxRepoNameLength = 10;

        //Commit
        public const int MinCommitDescriptionLength = 5;
    }
}