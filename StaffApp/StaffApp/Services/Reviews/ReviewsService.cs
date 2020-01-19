using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace StaffApp.Web.Services.Reviews
{
    public class ReviewsService : IReviewsService
    {
        private readonly HttpClient _client;

        public ReviewsService(HttpClient client)
        {
            client.BaseAddress = new Uri("");
            client.Timeout = TimeSpan.FromSeconds(5);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
        }

        public async Task<IEnumerable<ReviewsDTO>> GetReviews()
        {
            var response = await _client.GetAsync("api/reviews/");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            IEnumerable<ReviewsDTO> reviews = await response.Content.ReadAsAsync<IEnumerable<ReviewsDTO>>();
            return reviews;
        }

        public async Task<ReviewsDTO> PushReview(ReviewsDTO review)
        {
            var response = await _client.PostAsJsonAsync(
                "api/review/", review);
            response.EnsureSuccessStatusCode();

            return review;
        }
    }
}
