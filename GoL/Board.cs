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
        private string[,] table;

        public Board(int _size)
        {
            size = _size;
            table = new string[size,size];
        }
        public void initialize_rand()
        {
            Random rnd = new Random();
            object syncLock = new object();
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                        if (rnd.Next(0,2) == 0)
                            table[i, j] = "_";
                        else
                            table[i, j] = "*";
                }
        }

        public void initialize_zeros(ref string[,] table)
        {
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    table[i, j] = "_";
        }

        public void initialize_test()
        {
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    table[i, j] = "_";
            table[1, 1] = "*";
            table[2, 1] = "*";
            table[3, 1] = "*";
        }

        public void print_Table()
        {
            System.Console.Write(" 01234\n");
            for (int i = 0; i < size; i++)
            {
                System.Console.Write(i);
                for (int j = 0; j < size; j++)
                    System.Console.Write(table[i, j]);
                System.Console.Write("\n");
            }
        }

        private int get_neighbours(int i, int j)
        {
            int[] kierunki_i, kierunki_j;
            if (i == 0)
                kierunki_i = new int[2] { 0, 1 };
            else if (i == size - 1)
                kierunki_i = new int[2] { -1, 0 };
            else
                kierunki_i = new int[3] { -1, 0, 1 };
            if (j == 0)
                kierunki_j = new int[2] { 0, 1 };
            else if (j == size - 1)
                kierunki_j = new int[2] { -1, 0 };
            else
                kierunki_j = new int[3] { -1, 0, 1 };
            int ilosc_sasiadow = 0;
            
            //foreach(int value_i in kierunki_i)
            for(int ii = 0; ii < kierunki_i.Length; ii++)
                for(int jj = 0; jj < kierunki_j.Length; jj++)
                //foreach(int value_j in kierunki_j)
                {
                    //System.Console.WriteLine(i + " " + j + " " + kierunki_i[ii] + " " + kierunki_j[jj]);
                    //if (value_j == value_i && value_i == 0)
                    if (kierunki_j[jj] == 0 && kierunki_i[ii] == 0)
                        continue;
                    System.Console.WriteLine(i + " " + j + "\t" + kierunki_i[ii] + " " + kierunki_j[jj] + "\t" + (i+kierunki_i[ii]) + " " + (j+kierunki_j[jj]) + "\t" + table[i + kierunki_i[ii], j + kierunki_j[jj]]);
                    if (table[i + kierunki_i[ii], j + kierunki_j[jj]] == "*")
                    {
                        //System.Console.WriteLine(i + " " + j + " " + kierunki_i[ii] + " " + kierunki_j[jj]);
                        ilosc_sasiadow++;
                    }
                }
            return ilosc_sasiadow;
        }

        public void next_generation()
        {
            string[,] table_next = table;//new string[size,size];
            int tmp;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    tmp = get_neighbours(i, j);
                    //1 - < 2 umiera - pomijamy bo i tak jest zero w table_next
                    if (tmp < 2 && table[i,j] == "*")
                        table_next[i, j] = "_";
                    //2 - = 2,3 przeżywa
                    else if ((tmp == 2 || tmp == 3) && table[i, j] == "*")
                        table_next[i, j] = "*";
                    //3 - > 3 umiera
                    else if (tmp > 3 && table[i,j] == "*")
                        table_next[i, j] = "_";
                    //4 - == 3 - narodziny
                    else if (tmp == 3 && table[i, j] == "_")
                        table_next[i, j] = "*";
                }
            }
            table = table_next;
        }
    }
}
