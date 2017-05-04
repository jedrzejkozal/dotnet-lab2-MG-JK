using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoL
{
    class Board
    {
        private int size;
        private bool[,] table;

        public Board(int _size)
        {
            size = _size;
            table = new bool[size,size];
        }
        public void initialize_rand()
        {
            Random rnd = new Random();
            object syncLock = new object();
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                        if (rnd.Next(0,2) == 0)
                            table[i, j] = false;
                        else
                            table[i, j] = true;
                }
        }

        public void initialize_test()
        {
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    table[i, j] = false;
            table[1, 1] = true;
            table[2, 1] = true;
            table[3, 1] = true;
        }

        public void print_Table()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    System.Console.Write(table[i, j] ? "*" : "_");
                System.Console.Write("\n");
            }
        }

        private int get_neighbours(int i, int j)
        {
            int[] direction_i, direction_j;
            if (i == 0)
                direction_i = new int[2] { 0, 1 };
            else if (i == size - 1)
                direction_i = new int[2] { -1, 0 };
            else
                direction_i = new int[3] { -1, 0, 1 };
            if (j == 0)
                direction_j = new int[2] { 0, 1 };
            else if (j == size - 1)
                direction_j = new int[2] { -1, 0 };
            else
                direction_j = new int[3] { -1, 0, 1 };
            int a_neighbours = 0;

            foreach(int value_i in direction_i)
                foreach(int value_j in direction_j)
                {
                    if (value_i == 0 && value_j == 0)
                        continue;
                    if(table[i+value_i,j+value_j] == true)
                        a_neighbours++;
                }
            return a_neighbours;
        }

        public void next_generation()
        {
            bool[,] table_next = new bool[size,size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    table_next[i, j] = table[i, j];
            int tmp;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    tmp = get_neighbours(i, j);
                    //1 - < 2 die out off loneliness
                    if (tmp < 2 && table[i,j] == true)
                        table_next[i, j] = false;
                    //2 - = 2,3 lives
                    else if ((tmp == 2 || tmp == 3) && table[i, j] == true)
                        table_next[i, j] = true;
                    //3 - > 3 dies
                    else if (tmp > 3 && table[i,j] == true)
                        table_next[i, j] = false;
                    //4 - == 3 - birth
                    else if (tmp == 3 && table[i, j] == false)
                        table_next[i, j] = true;
                }
            }
            table = table_next;
        }
    }
}
