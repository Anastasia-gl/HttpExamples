using HttpExamples.Service;
namespace HttpExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var h = new HttpService();
            //Task.WaitAll(h.Get(), h.GetNotFoundUser(), h.Post(), h.Put(), h.Delete(), h.Post1());
            Task.WaitAll(h.Get(), h.GetNotFoundUser(), h.Post(), h.Put(), h.Delete(), h.Post1(), h.Post2(), h.Post3());

        }
    }
}