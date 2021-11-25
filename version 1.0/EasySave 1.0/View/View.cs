using System;

namespace EasySave_1_0.View
{
    public class View
    {
        public string Input()
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(false); // true = hide input
            }
            return Console.ReadLine();
        }
        public void Output(string input)
        {
            Console.WriteLine(input);
        }

        public View()
        {
            Console.WriteLine("initialisation... \n");
        }
    }

}
