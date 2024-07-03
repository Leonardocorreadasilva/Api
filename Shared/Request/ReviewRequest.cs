namespace Api.Domain.Requests
{
    public class ReviewRequest
    {
        public Guid Id { get; set; }
        public Guid UserReviewId { get; set; }
        public Guid ProductReviewId { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
        public string Reviews { get; set; }
    }
}
