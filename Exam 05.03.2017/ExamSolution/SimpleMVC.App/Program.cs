namespace SimpleMVC.App
{
    class Program
    {
        static void Main()
        {
            HttpServer server = new HttpServer(8081, RouteTable.Routes);
            MvcEngine.Run(server, "SimpleMVC.App");
        }
    }
}
