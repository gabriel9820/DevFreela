namespace DevFreela.Application.Queries.GetAllSkills
{
    public class SkillOutputModel
    {
        public int Id { get; private set; }
        public string Description { get; private set; }

        public SkillOutputModel(int id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}
