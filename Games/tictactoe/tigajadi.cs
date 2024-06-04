using System;

class TicTacToe
{
    const int ukuran = 3;
    static char[,] papan = new char[ukuran, ukuran];
    static char player = 'X';

    static void Isipapan()
    {
        for (int a = 0; a < ukuran; a++)
        {
            for (int b = 0; b < ukuran; b++)
            {
                papan[a, b] = ' ';
            }
        }
    }

    static void Buatpapan()
    {
        for (int x = 0; x <= ukuran * 4; x++)
        {
            if (x % 4 == 0)
            {
                Console.Write("+");
            }
            else
            {
                Console.Write("-");
            }
        }
        Console.WriteLine();
        for (int i = 0; i < ukuran; i++)
        {
            for (int j = 0; j < ukuran; j++)
            {
                Console.Write("|" + " " + papan[i, j] + " ");
            }

            Console.WriteLine("|");
            for (int y = 0; y <= ukuran * 4; y++)
            {
                if (y % 4 == 0)
                {
                    Console.Write("+");
                }
                else
                {
                    Console.Write("-");
                }
            }
            Console.WriteLine();
        }
    }

    static bool AfkhMenang()
    {
        for (int i = 0; i < ukuran; i++)
        {
            if (papan[i, 0] == player && papan[i, 1] == player && papan[i, 2] == player)
            {
                return true;
            }
            if (papan[0, i] == player && papan[1, i] == player && papan[2, i] == player)
            {
                return true;
            }
        }
        if (papan[0, 0] == player && papan[1, 1] == player && papan[2, 2] == player)
        {
            return true;
        }
        if (papan[0, 2] == player && papan[1, 1] == player && papan[2, 0] == player)
        {
            return true;
        }
        return false;
    }

    static bool AfkhPenuh()
    {
        for (int i = 0; i < ukuran; i++)
        {
            for (int j = 0; j < ukuran; j++)
            {
                if (papan[i, j] == ' ')
                {
                    return false;
                }
            }
        }
        return true;
    }

    static bool Isi(int baris, int kolom)
    {
        if (baris < ukuran && baris >= 0 && kolom < ukuran && kolom >= 0 && papan[baris, kolom] == ' ')
        {
            papan[baris, kolom] = player;
            return true;
        }
        else
        {
            return false;
        }
    }

    static void Main(string[] args)
    {
        int kolom, baris;
        Isipapan();
        bool bermain = true;

        while (bermain)
        {
            Console.Clear();
            Buatpapan();
            Console.Write("Masukin baris: ");
            baris = Convert.ToInt32(Console.ReadLine());
            Console.Write("\tKolom: ");
            kolom = Convert.ToInt32(Console.ReadLine());

            if (Isi(baris - 1, kolom - 1))
            {
                if (AfkhMenang())
                {
                    Console.Clear();
                    Buatpapan();
                    Console.WriteLine("\nAnjay menang gg icixiwir ah yameted");
                    bermain = false;
                }
                else if (AfkhPenuh())
                {
                    Console.Clear();
                    Buatpapan();
                    bermain = false;
                    Console.Write("\nPenuh tod :nosad:\nMau coba lagi? [y/n]: ");
                    char mainlagi = Console.ReadKey().KeyChar;
                    if (mainlagi == 'y' || mainlagi == 'Y')
                    {
                        Console.Clear();
                        Main(args); // Restart the game
                    }
                }
                else
                {
                    player = (player == 'X') ? 'O' : 'X';
                }
            }
        }
    }
}
