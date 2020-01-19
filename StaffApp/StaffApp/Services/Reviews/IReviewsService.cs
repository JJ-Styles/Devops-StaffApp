using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffApp.Web.Services.Reviews
{
    interface IReviewsService
    {
        Task<ReviewsDTO> PushReview(ReviewsDTO review);

        Task<IEnumerable<ReviewsDTO>> GetReviews();
    }
}
