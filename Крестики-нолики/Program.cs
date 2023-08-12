using System;

namespace Крестики_нолики
{
    class Program
    {
        static void DrawCross(int x, int y)          // Метод рисующий крестик
        {
            int Cx = x;
            int Cy = y;
            for (int i = 0; i < 5; i++, Cx += 2, Cy += 1)
            {
                Console.SetCursorPosition(Cx, Cy);
                Console.Write("█");
                Console.SetCursorPosition(Cx + 1, Cy);
                Console.Write("█");
            }

            Cx = x;
            Cy = y + 4;

            for (int i = 0; i < 5; i++, Cx += 2, Cy -= 1)
            {
                Console.SetCursorPosition(Cx, Cy);
                Console.Write("█");
                Console.SetCursorPosition(Cx + 1, Cy);
                Console.Write("█");
            }

        }

        static void DrawRectangle(int x, int y)         // Метод рисующий нолик
        {
            for (int xR = x; xR <= x + 8; xR++)
            {
                for (int yR = y; yR <= y + 4; yR++)
                {
                    if (xR == x || xR == x + 6)
                    {
                        Console.SetCursorPosition(xR + 2, yR);
                        Console.Write("█");
                        Console.SetCursorPosition(xR + 3, yR);
                        Console.Write("█");
                    }
                    if ((yR == y || yR == y + 4) && xR != x && xR != x + 1)
                    {
                        Console.SetCursorPosition(xR, yR);
                        Console.Write("█");
                    }
                }
            }
        }

        static void DrawField()                  // Метод рисующий поле
        {
            for (int x = 0; x <= 49; x++)              // по-горизонтали
            {
                for (int y = 0; y <= 24; y += 8)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write("█");
                }
            }

            for (int y = 0; y <= 24; y++)               // по-вертикали
            {
                for (int x = 0; x <= 49; x += 16)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write("█");
                }
            }

            for (int y = 0; y <= 24; y++)               // по-вертикали 2
            {
                for (int x = 1; x <= 49; x += 16)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write("█");
                }
            }
            int xNumber = 8;
            int yNumber = 1;
            for (int number = 1; number <= 9; number++)     // нумерация клеток
            {
                Console.SetCursorPosition(xNumber, yNumber);
                Console.Write(number);
                xNumber += 16;
                if (number % 3 == 0)
                {
                    xNumber = 8;
                    yNumber += 8;
                }
            }
        }

        static void Main(string[] args)
        {
            // Базовые настройки и отрисовка поля
            Console.SetWindowSize(90, 26);
            Console.SetBufferSize(90, 26);
            DrawField();
            int input;
            int c1 = -1, c2 = -2, c3 = -3, c4 = -4, c5 = -5, c6 = -6, c7 = -7, c8 = -8, c9 = -9;
            int win = -1;

            // Главный цикл игры
            for (int i = 0; i < 9; i++)
            {
                // Пользовательский ввод
                Console.SetCursorPosition(51, 1);
                Console.Write("                                       ");
                Console.SetCursorPosition(51, 1);
                Console.Write("Введите номер клетки: ");
                bool errorInput = !int.TryParse(Console.ReadLine(), out input);
                Console.SetCursorPosition(51, 3);
                Console.Write("                                       ");

                // Проверка корректности ввода
                if (input == 1 && c1 >= 0) errorInput = true;
                if (input == 2 && c2 >= 0) errorInput = true;
                if (input == 3 && c3 >= 0) errorInput = true;
                if (input == 4 && c4 >= 0) errorInput = true;
                if (input == 5 && c5 >= 0) errorInput = true;
                if (input == 6 && c6 >= 0) errorInput = true;
                if (input == 7 && c7 >= 0) errorInput = true;
                if (input == 8 && c8 >= 0) errorInput = true;
                if (input == 9 && c9 >= 0) errorInput = true;
                if (input > 9 || input < 1) errorInput = true;

                if (errorInput == true)
                {
                    Console.SetCursorPosition(51, 3);
                    Console.Write("Некорректный ввод!");
                    i--;
                    continue;
                }

                if (input == 1) c1 = i % 2;
                if (input == 2) c2 = i % 2;
                if (input == 3) c3 = i % 2;
                if (input == 4) c4 = i % 2;
                if (input == 5) c5 = i % 2;
                if (input == 6) c6 = i % 2;
                if (input == 7) c7 = i % 2;
                if (input == 8) c8 = i % 2;
                if (input == 9) c9 = i % 2;

                // Определение, куда поставить фигуру
                int x = ((input - 1) % 3) * 16 + 3;
                int y = ((input - 1) / 3) * 8 + 2;

                // Определение, какую фигуру рисовать и отрисовка
                if (i % 2 == 0) DrawCross(x + 1, y);
                else DrawRectangle(x, y);

                // История ходов
                Console.SetCursorPosition(51, 16 + i);
                if (i % 2 == 0) Console.WriteLine($"Крестик в ячейку № {input}!");
                else Console.WriteLine($"Нолик в ячейку № {input}!");

                // Определение кто победил
                if (c1 == c2 && c2 == c3) win = c1;
                if (c4 == c5 && c5 == c6) win = c4;
                if (c7 == c8 && c8 == c9) win = c7;
                if (c1 == c4 && c4 == c7) win = c1;
                if (c3 == c6 && c6 == c9) win = c3;
                if (c2 == c5 && c5 == c8) win = c2;
                if (c1 == c5 && c5 == c9) win = c1;
                if (c3 == c5 && c5 == c7) win = c3;

                if (win == 0)
                {
                    Console.SetCursorPosition(60, 8);
                    Console.Write("Победили крестики!");
                    break;
                }
                if (win == 1)
                {
                    Console.SetCursorPosition(60, 8);
                    Console.Write("Победили нолики!");
                    break;
                }
            }

            if (win == -1)
            {
                Console.SetCursorPosition(60, 8);
                Console.Write("Ничья!");
                Console.ReadLine();
            }

            Console.ReadLine();
        }
    }
}
