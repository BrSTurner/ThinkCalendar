namespace Think.Calendar.Domain.Model
{
    public abstract class Entity<T>
    {
        public T Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set;}

        public virtual bool IsValid() => true;
    }
}
