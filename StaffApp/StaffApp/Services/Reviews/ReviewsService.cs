using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace StaffApp.Web.Services.Reviews
{
    public class ReviewsService : StaffAppServices, IReviewsService
    {
        public ReviewsService(IHttpClientFactory clientFactory) : base(clientFactory, "")
        {
        }

        public ReviewsService() : base()
        {
        }

        public async Task<IEnumerable<ReviewsDTO>> GetReviews()
        {
            var response = await GetClient().GetAsync("api/reviews/");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            IEnumerable<ReviewsDTO> reviews = await response.Content.ReadAsAsync<IEnumerable<ReviewsDTO>>();
            return reviews;
        }

        public async Task<HttpResponseMessage> PushReview(ReviewsDTO review)
        {
            return await GetClient().PostAsJsonAsync("api/review/", review);
        }

        public override async Task<HttpResponseMessage> Post<T>(T data)
        {
            var Reviews = new ReviewsDTO();
            if (!ReviewsDTO.ReferenceEquals(data.GetType(), Reviews))
            {
                return null;
            }
            Reviews = (ReviewsDTO)nameof(data).Clone();
            return await PushReview(Reviews);
        }
    }
}
