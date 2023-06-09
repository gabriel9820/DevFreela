namespace DevFreela.Core.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; private set; }
        public DateTime CreatedAt { get; private set; }

        protected BaseEntity()
        {
            CreatedAt = DateTime.Now;
        }

        protected BaseEntity(int id)
        {
            Id = id;
            CreatedAt = DateTime.Now;
        }
    }
}
