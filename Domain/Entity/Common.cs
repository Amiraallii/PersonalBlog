namespace Personal.Domain.Entity
{
    public class Common<TKey>
    {
        public TKey Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
    }
}
