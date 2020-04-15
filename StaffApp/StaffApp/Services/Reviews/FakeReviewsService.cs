using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace StaffApp.Web.Services.Reviews
{
    public class FakeReviewsService : IReviewsService
    {
        private readonly ReviewsDTO[] _reviews =
        {
            new ReviewsDTO{ Id = 51, Description = "dsvfdgarwe", Hidden = false, Rating = 2, ProductId = 5, UserAccountId = 1},
            new ReviewsDTO{ Id = 52, Description = "dsvfdgarwe", Hidden = false, Rating = 2, ProductId = 6, UserAccountId = 2},
            new ReviewsDTO{ Id = 53, Description = "dsvfdgarwe", Hidden = false, Rating = 2, ProductId = 7, UserAccountId = 3}
        };

        public Task<IEnumerable<ReviewsDTO>> GetReviews()
        {
            var reviews = _reviews.AsEnumerable();
            return Task.FromResult(reviews);
        }

        public Task<HttpResponseMessage> PushReview(ReviewsDTO review)
        {
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
        }
    }
}
