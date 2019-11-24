namespace Template
{
    using Template.Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Sourdough sourDough = new Sourdough();
            sourDough.Make();

            WholeWheat wholeWheat = new WholeWheat();
            wholeWheat.Make();

            TwelveGrain twelveGrain = new TwelveGrain();
            twelveGrain.Make();
        }
    }
}
