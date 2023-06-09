namespace DevFreela.Application.Queries.GetAllProjects
{
    public class ProjectOutputModel
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public ProjectOutputModel(int id, string title, string description, DateTime createdAt)
        {
            Id = id;
            Title = title;
            Description = description;
            CreatedAt = createdAt;
        }
    }
}
