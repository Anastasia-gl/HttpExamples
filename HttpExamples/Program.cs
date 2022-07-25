using HttpExamples.Service;
namespace HttpExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var h = new HttpService();
            Task.WaitAll(h.Get(), h.GetNotFoundUser(), h.Post(), h.Put(), h.Delete());
        }
    }
}