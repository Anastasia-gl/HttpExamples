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
                    Console.WriteLine(request.StatusCode);
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

        public async Task Post1()
        {
            using (var post1 = new HttpClient())
            {
                post1.BaseAddress = new Uri("https://reqres.in/");

                var postUser1 = new PostUser1
                {
                    Email = "eve.holt@reqres.in",
                    Password = "pistol"
                };

                string serialize = JsonConvert.SerializeObject(postUser1);

                StringContent stringContent = new StringContent(serialize, Encoding.Unicode, "application/json");
                HttpResponseMessage responseMessage = await post1.PostAsync("api/register", stringContent);

                if (responseMessage.StatusCode == HttpStatusCode.OK)
                {
                    Console.WriteLine(responseMessage.Content.ReadAsStringAsync().Result);
                }
            };
        }

        public async Task Post2()
        {
            using (var post1 = new HttpClient())
            {
                post1.BaseAddress = new Uri("https://reqres.in/");

                var postUser1 = new PostUser1 { Email = "sydney@fife" };


                string serialize = JsonConvert.SerializeObject(postUser1);

                StringContent stringContent = new StringContent(serialize, Encoding.Unicode, "application/json");
                HttpResponseMessage responseMessage = await post1.PostAsync("api/register", stringContent);

                if (responseMessage.StatusCode == HttpStatusCode.BadRequest)
                {
                    Console.WriteLine(responseMessage.Content.ReadAsStringAsync().Result);
                }
            };
        }

        public async Task Post3()
        {
            using (var post1 = new HttpClient())
            {
                post1.BaseAddress = new Uri("https://reqres.in/");

                var postUser1 = new PostUser1 { Email = "eve.holt@reqres.in", Password = "cityslicka" };


                string serialize = JsonConvert.SerializeObject(postUser1);

                StringContent stringContent = new StringContent(serialize, Encoding.Unicode, "application/json");
                HttpResponseMessage responseMessage = await post1.PostAsync("api/login", stringContent);

                if (responseMessage.StatusCode == HttpStatusCode.OK)
                {
                    Console.WriteLine(responseMessage.Content.ReadAsStringAsync().Result);
                }
            };
        }

        public async Task Post4()
        {
            using (var post1 = new HttpClient())
            {
                post1.BaseAddress = new Uri("https://reqres.in/");

                var postUser1 = new PostUser1 { Email = "peter@klaven" };


                string serialize = JsonConvert.SerializeObject(postUser1);

                StringContent stringContent = new StringContent(serialize, Encoding.Unicode, "application/json");
                HttpResponseMessage responseMessage = await post1.PostAsync("api/login", stringContent);

                if (responseMessage.StatusCode == HttpStatusCode.BadRequest)
                {
                    Console.WriteLine(responseMessage.Content.ReadAsStringAsync().Result);
                }
            };
        }
    }
}