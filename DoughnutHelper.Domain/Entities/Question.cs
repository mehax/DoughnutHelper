namespace DoughnutHelper.Domain.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? ParentId { get; set; }

        public Question? Parent { get; set; }
    }
}