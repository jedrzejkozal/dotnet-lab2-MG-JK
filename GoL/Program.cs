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
            Board board = new Board(5);
            board.initialize_test();
            //board.print_Table();
            
            while(true)
            {
                board.print_Table();
                board.next_generation();
                System.Console.Read();
                System.Console.Clear();
            }
            
        }
    }
}
