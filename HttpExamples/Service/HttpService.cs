using System.Net;
using System.Text;
using Newtonsoft.Json;
using HttpExamples.Model;

namespace HttpExamples.Service
{
    public class HttpService
    {
        public async Task Get()
        {
            using (var get = new HttpClient())
            {
                get.BaseAddress = new Uri("https://reqres.in/");

                HttpResponseMessage request = await get.GetAsync("api/users?page=2");

                if (request.StatusCode == HttpStatusCode.OK)
                {
                    string content = await request.Content.ReadAsStringAsync();
                    Console.WriteLine(content);

                    ReqresPage page = JsonConvert.DeserializeObject<ReqresPage>(content);

                    if (page is not null)
                    {
                        Console.WriteLine(page.ToString());
                    }
                }
            };
        }

        public async Task GetNotFoundUser()
        {
            using (var notFound = new HttpClient())
            {
                notFound.BaseAddress = new Uri("https://reqres.in/");

                HttpResponseMessage request = await notFound.GetAsync("/api/users/23");

                if (request.StatusCode == HttpStatusCode.NotFound)
                {
                    Console.WriteLine(request.StatusCode.ToString());
                }
            };
        }

        public async Task Post()
        {
            using (var post = new HttpClient())
            {
                post.BaseAddress = new Uri("https://reqres.in/");

                var user = new CreateUserParameters
                {
                    Name = "Anastasia",
                    Job = "Software Engineer"
                };

                string serialize = JsonConvert.SerializeObject(user);

                StringContent stringContent = new StringContent(serialize, Encoding.Unicode, "application/json");

                HttpResponseMessage result = await post.PostAsync("api/users", stringContent);

                if (result.StatusCode == HttpStatusCode.Created)
                {
                    string content = await result.Content.ReadAsStringAsync();
                    Console.WriteLine(content);

                    CreateUser users = JsonConvert.DeserializeObject<CreateUser>(content);
                    Console.WriteLine(user!.Name);
                }
            };
        }

        public async Task Put()
        {
            using (var put = new HttpClient())
            {
                put.BaseAddress = new Uri("https://reqres.in/");


                var user = new CreateUserParameters
                {
                    Name = "Anastasia",
                    Job = "Software Engineer"
                };

                if (user is not null)
                {
                    user.Name = "morpheus";
                    user.Job = "zion resident";
                }

                string serialize = JsonConvert.SerializeObject(user);

                StringContent stringContent = new StringContent(serialize, Encoding.Unicode, "application/json");
                HttpResponseMessage result = await put.PutAsync("api/users/2", stringContent);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    string content = await result.Content.ReadAsStringAsync();
                    Console.WriteLine(content);
                }
            };
        }

        public async Task Delete()
        {
            using (var delete = new HttpClient())
            {
                delete.BaseAddress = new Uri("https://reqres.in/");          
            
                HttpResponseMessage result = await delete.DeleteAsync("api/users/2");

                if (result.StatusCode == HttpStatusCode.NoContent)
                {
                    Console.WriteLine(result.StatusCode);
                }
            };
        }
    }
}