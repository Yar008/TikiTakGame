using System;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
class Game
{
    public string[,] arr;
    public int height;
    public int width;
    public string? symb1;
    public string? symb2;
    public int win_amo;
    public bool win = false;
    public void set_symb(string symbP, string symbP2)
    {
        this.symb1 = symbP;
        this.symb2 = symbP2;
    }
    public void print_field()
    {
        for (int i = 0; i < this.height; i++)
        {
            for (int j = 0; j < this.width; j++)
            {
                Console.Write(this.arr[i, j]);
                Console.Write("\t");
            }
            Console.WriteLine("\n");
        }
    }
    public void create_field()
    {
        string[,] array = new string[this.height, this.width];
        this.arr = array;
        for (int i = 0; i < this.height; i++)
        {
            for (int j = 0; j < this.width; j++)
            {
                this.arr[i, j] = "*";
            }
        }
    }
    public void set_point(int y, int x, string ch)
    {
        this.arr[y, x] = ch;
    }
    public void check_horizontal(string show_win, string show_win2)
    {
        int count_1 = 0;
        int count_2 = 0;

        for (int i = 0; i < this.height; i++)
        {
            for (int j = 0; j < this.width; j++)
            {
                if (arr[i, j] == this.symb1)
                {
                    count_1++;
                }
                else if (arr[i, j] == this.symb2)
                {
                    count_2++;
                };
            }
            if (count_1 == this.win_amo)
            {
                Console.WriteLine(show_win);
                this.win = true;
                break;

            }
            else if (count_2 == this.win_amo)
            {
                Console.WriteLine(show_win2);
                this.win = true;
                break;

            }
            else
            {
                count_1 = 0;
                count_2 = 0;

            }
        }
    }
    public void check_vertical(string show_win, string show_win2)
    {
        int count_1 = 0;
        int count_2 = 0;
        int counter = 0;
        while (counter <= 2)
        {
            for (int i = 0; i < this.height; i++)
            {
                if (arr[i, counter] == this.symb1)
                {
                    count_1++;
                }
                else if (arr[i, counter] == this.symb2)
                {
                    count_2++;
                };
            }
            if (count_1 == this.win_amo)
            {
                Console.WriteLine(show_win);
                this.win = true;
                break;

            }
            else if (count_2 == this.win_amo)
            {
                Console.WriteLine(show_win2);
                this.win = true;
                break;

            }
            else
            {
                count_1 = 0;
                count_2 = 0;


            }
            counter++;
        };
    }
    public void check_diagonal(string show_win, string show_win2)
    {
        int x = 0;
        int y = 0;
        int count_1 = 0, count_2 = 0;
        while (x <= 2 && y <= 2)
        {
            if (arr[x, y] == this.symb1)
            {
                count_1++;
            }
            else if (arr[x, y] == this.symb2)
            {
                count_2++;
            };
            x++;
            y++;
        }
        if (count_1 == this.win_amo)
        {
            Console.WriteLine(show_win);
            this.win = true;

        }
        else if (count_2 == this.win_amo)
        {
            Console.WriteLine(show_win2);
            this.win = true;
        }
    }
    public void _check_diagonal(string show_win, string show_win2)
    {
        // проверка диагонали 2
        int x = this.width - 1;
        int y = 0;
        int count_1 = 0;
        int count_2 = 0;
        while (y < this.height)
        {
            if (arr[x, y] == this.symb1)
            {
                count_1++;
            }
            else if (arr[x, y] == this.symb2)
            {
                count_2++;
            };
            x--;
            y++;
        };
        if (count_1 == this.win_amo)
        {
            Console.WriteLine(show_win);
            this.win = true;
        }
        else if (count_2 == this.win_amo)
        {
            Console.WriteLine(show_win2);
            this.win = true;
        }
    }
    public void check(int amm)
    {
        if (amm == 1)
        {
            check_horizontal("Вы выиграли!", "Вы проиграли!");
            check_vertical("Вы выиграли!", "Вы проиграли!");
            check_diagonal("Вы выиграли!", "Вы проиграли!");
            _check_diagonal("Вы выиграли!", "Вы проиграли!");
        }
        else if (amm == 2)
        {
            check_horizontal("Игрок 1 победил!", "Игрок 2 победил!");
            check_vertical("Игрок 1 победил!", "Игрок 2 победил!");
            check_diagonal("Игрок 1 победил!", "Игрок 2 победил!");
            _check_diagonal("Игрок 1 победил!", "Игрок 2 победил!");
        };

    }

};

class HelloWorld
{
    static void Main()
    {
        Game game = new Game();
        Console.WriteLine("Вас приветсвует игра крестики-нолики. Выберите количество игроков:");
        int gamer = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Хотите ли вы изменить набор символов для игры: 1- да, 0 - нет");
        int symb = Int32.Parse(Console.ReadLine());
        if (symb == 1)
        {
            Console.WriteLine("Игрок 1, введите свой символ:");
            game.symb1 = Console.ReadLine();
            Console.WriteLine("Игрок 2, введите свой символ:");
            game.symb2 = Console.ReadLine();
        }
        else if (symb == 0)
        {
            game.symb1 = "x";
            game.symb2 = "o";
        }
        Console.WriteLine("Введите высоту поля:");
        game.height = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Введите ширину поля:");
        game.width = Int32.Parse(Console.ReadLine());
        if (game.height != game.width)
        {
            while (game.width != game.height)
            {
                Console.WriteLine("Игровое поле получается непропорциональным!");
                Console.WriteLine("Введите высоту поля:");
                game.height = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Введите ширину поля:");
                game.width = Int32.Parse(Console.ReadLine());
            }
        }
        game.win_amo = game.height;
        game.create_field();
        Console.WriteLine("Начать игру - 1, закрыть игру - 2");
        int start = Int32.Parse(Console.ReadLine());
        while (start != 2)
        {
            if (gamer == 2)
            {

                Console.WriteLine("Игрок 1, введите координаты точки, куда хотите поставить символ:");
                int tempx = Int32.Parse(Console.ReadLine());
                int tempy = Int32.Parse(Console.ReadLine());
                if (game.arr[tempx, tempy] == "*")
                {
                    game.set_point(tempx, tempy, game.symb1);
                    game.check(2);
                    if (game.win == true)
                    {
                        game.print_field();
                        Console.WriteLine("");
                        break;
                    }
                }
                else if (game.arr[tempx, tempy] != "*")
                {
                    while (game.arr[tempx, tempy] != "*")
                    {
                        Console.WriteLine("Это поле уже занято!");
                        Console.WriteLine("Игрок 1, введите новые координаты, куда хотите поставить символ:");
                        tempx = Int32.Parse(Console.ReadLine());
                        tempy = Int32.Parse(Console.ReadLine());
                    };
                    game.set_point(tempx, tempy, game.symb1);
                    game.check(2);
                    if (game.win == true)
                    {
                        game.print_field();
                        Console.WriteLine("");
                        break;
                    };
                };
                Console.WriteLine("Игрок 2, введите координаты точки, куда хотите поставить символ:");
                int tempx2 = Int32.Parse(Console.ReadLine());
                int tempy2 = Int32.Parse(Console.ReadLine());
                if (game.arr[tempx2, tempy2] == "*")
                {
                    game.set_point(tempx2, tempy2, game.symb2);
                    game.check(2);
                    if (game.win == true)
                    {
                        game.print_field();
                        Console.WriteLine("");
                        break;
                    }
                }
                else if (game.arr[tempx, tempy] != "*")
                {
                    while (game.arr[tempx, tempy] != "*")
                    {
                        Console.WriteLine("Это поле уже занято!");
                        Console.WriteLine("Игрок 2, введите новые координаты, куда хотите поставить символ:");
                        tempx = Int32.Parse(Console.ReadLine());
                        tempy = Int32.Parse(Console.ReadLine());
                    };
                    game.set_point(tempx, tempy, game.symb2);
                    game.check(2);
                    if (game.win == true)
                    {
                        game.print_field();
                        Console.WriteLine("");
                        break;
                    };
                };
                Console.WriteLine("Текущее состояние поля:\n");
                game.print_field();
                Console.WriteLine("");
            }
            else if (gamer == 1)
            {
                Console.WriteLine("Игрок 1, введите координаты точки, куда хотите поставить символ:");
                int tempx = Int32.Parse(Console.ReadLine());
                int tempy = Int32.Parse(Console.ReadLine());
                if (game.arr[tempx, tempy] == "*")
                {
                    game.set_point(tempx, tempy, game.symb1);
                    game.check(1);
                    if (game.win == true)
                    {
                        game.print_field();
                        Console.WriteLine("");
                        break;
                    }
                }
                else if (game.arr[tempx, tempy] != "*")
                {
                    while (game.arr[tempx, tempy] != "*")
                    {
                        Console.WriteLine("Это поле уже занято!");
                        Console.WriteLine("Игрок 1, введите новые координаты, куда хотите поставить символ:");
                        tempx = Int32.Parse(Console.ReadLine());
                        tempy = Int32.Parse(Console.ReadLine());
                    };
                    game.set_point(tempx, tempy, game.symb1);
                    game.check(1);
                    if (game.win == true)
                    {
                        game.print_field();
                        Console.WriteLine("");
                        break;
                    };
                };
                Random rnd = new Random();
                int x = rnd.Next(game.width);
                int y = rnd.Next(game.height);
                if (game.arr[x, y] == "*")
                {
                    game.set_point(x, y, game.symb2);
                    game.check(1);
                    if (game.win == true)
                    {
                        game.print_field();
                        Console.WriteLine("");
                        break;
                    }

                }
                else if (game.arr[x, y] != "*")
                {
                    x = rnd.Next(game.width);
                    y = rnd.Next(game.height);
                    while (game.arr[x, y] != "*")
                    {
                        x = rnd.Next(game.width);
                        y = rnd.Next(game.height);
                    };
                    game.set_point(x, y, game.symb2);
                    game.check(1);
                    if (game.win == true)
                    {
                        game.print_field();
                        Console.WriteLine("");
                        break;
                    }
                }
                Console.WriteLine("Текущее состояние поля:\n");
                game.print_field();
                Console.WriteLine("");
            }
        }
        game.create_field();
    }
}