using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoL
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Board size");
            Boolean result_of_parse;
            int size;
            do
            {
                string input = Console.ReadLine();
                result_of_parse = Int32.TryParse(input, out size);
                if (!result_of_parse)
                {
                    System.Console.WriteLine("Invalid value of size!");
                }
            } while (!result_of_parse);

            Board board = new Board(size);
            board.initialize_rand();
            
            while(true)
            {
                board.print_Table();
                board.next_generation();
                System.Console.Clear();
                System.Console.Read();
            }
            
        }
    }
}
