using HotelProject.WebUI.Dtos.FollowersDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardSubscribeCountPartial:ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ResultInstagramFollowersDto resultInstagramFollowersDto = new ResultInstagramFollowersDto();    
             var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofileinfo/murattycedag"),
                Headers =
    {
        { "x-rapidapi-key", "6b99735555msh46fe40a0ee44ff2p1db52bjsnc05306989038" },
        { "x-rapidapi-host", "instagram-profile1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                resultInstagramFollowersDto = JsonConvert.DeserializeObject<ResultInstagramFollowersDto>(body);
                ViewBag.instagramFollowers = resultInstagramFollowersDto.followers;
                ViewBag.instagramFollowing = resultInstagramFollowersDto.following;


              
            }

            ResultTwitterFollowersDto resultTwitterFollowersDto = new ResultTwitterFollowersDto();
            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://twitter-api45.p.rapidapi.com/screenname.php?screenname=JeffBezos"),
                Headers =
    {
        { "x-rapidapi-key", "6b99735555msh46fe40a0ee44ff2p1db52bjsnc05306989038" },
        { "x-rapidapi-host", "twitter-api45.p.rapidapi.com" },
    },
            };
            using (var response2 = await client.SendAsync(request2))
            {
                response2.EnsureSuccessStatusCode();
                var body2 = await response2.Content.ReadAsStringAsync();
                resultTwitterFollowersDto= JsonConvert.DeserializeObject<ResultTwitterFollowersDto>(body2);
                ViewBag.twitterFollowers = resultTwitterFollowersDto.sub_count;
                ViewBag.twitterFollowing = resultTwitterFollowersDto.friends;


            }

            return View();
        }

    }
}
