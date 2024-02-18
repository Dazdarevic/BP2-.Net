namespace NBP.Application.DTOs
{
    public class CommentDto
    {
        public int Id { get; set; }
        public int TrainerId { get; set; }
        public int MemberId { get; set; }
        public string? Text { get; set; }
    }
}
