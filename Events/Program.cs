
namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            var er = new EventRaiser();

            er.DelegateTypeSelected += new System.EventHandler<DelegateTypeEventArgs>(Selected);

            er.SelectDelegate();
        }

        public static void Selected(object sender, DelegateTypeEventArgs args)
        {
            System.Console.WriteLine(args.Type);
        }
    }
}
