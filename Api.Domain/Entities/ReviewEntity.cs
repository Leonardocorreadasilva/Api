using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class ReviewEntity : BaseEntity
    {
  
        public int Rating { get; set; }
        public string Coments { get; set; }
        public string Reviews { get; set; }
        public UserEntity UserReview { get; set; }
        public Guid UserReviewId { get; set; }
        public ProductEntity ProductReview { get; set; }
        public Guid ProductReviewId { get; set; }
    }
}
