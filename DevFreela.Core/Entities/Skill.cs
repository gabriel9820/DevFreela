namespace DevFreela.Core.Entities
{
    public class Skill : BaseEntity
    {
        public string Description { get; private set; }

        public Skill(string description)
        {
            Description = description;
        }

        public Skill(int id, string description) : base(id)
        {
            Description = description;
        }
    }
}
