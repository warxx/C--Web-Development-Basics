namespace SimpleMVC.App.Data
{
    public class Data
    {
        private static DbContext context;

        public static DbContext Context => context ?? (context = new DbContext());
    }
}
