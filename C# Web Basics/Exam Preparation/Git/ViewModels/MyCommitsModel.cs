namespace Git.ViewModels
{
    public class MyCommitsModel
    {
        public string Id { get; set; }
        public string Repository { get; set; }

        public string RepositoryName { get; set; }

        public string CreatedOn { get; set; }

        public string Description { get; set; }
    }
}