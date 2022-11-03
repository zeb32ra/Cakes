using PodPunkt;
using Punkt;


namespace Main
{
    internal class Cake
    {

        List<PodPunkts> zatichka = new List<PodPunkts>();
        int all_cost = 0;
        string new_line = "";
        bool we_are_in_main = true;

        public void programm()
        {
            PodPunkts podpunkt1 = new PodPunkts("Круг", 100, 3);
            PodPunkts podpunkt2 = new PodPunkts("Квадрат", 80, 4);
            PodPunkts podpunkt3 = new PodPunkts("Звезда", 500, 5);
            PodPunkts podpunkt4 = new PodPunkts("Овал", 250, 6);

            PodPunkts podpunkt5 = new PodPunkts("Большой (Диаметр - 30см)", 400, 3);
            PodPunkts podpunkt6 = new PodPunkts("Средний (Диаметр - 20см)", 250, 4);
            PodPunkts podpunkt7 = new PodPunkts("Маленький (Диаметр - 15см)", 100, 5);

            PodPunkts podpunkt8 = new PodPunkts("Клубничный", 150, 3);
            PodPunkts podpunkt9 = new PodPunkts("Шоколадный", 180, 4);
            PodPunkts podpunkt10 = new PodPunkts("Фисташковый", 300, 5);
            PodPunkts podpunkt11 = new PodPunkts("Кокосовый", 200, 6);

            PodPunkts podpunkt12 = new PodPunkts("Один корж", 100, 3);
            PodPunkts podpunkt13 = new PodPunkts("Два коржа", 200, 4);
            PodPunkts podpunkt14 = new PodPunkts("Три коржа", 300, 5);
            PodPunkts podpunkt15 = new PodPunkts("Четыре коржа", 400, 6);

            PodPunkts podpunkt16 = new PodPunkts("Карамельная", 100, 3);
            PodPunkts podpunkt17 = new PodPunkts("Ванильная", 200, 4);
            PodPunkts podpunkt18 = new PodPunkts("Ореховая", 300, 5);

            PodPunkts podpunkt19 = new PodPunkts("Шоколадные шарики", 160, 3);
            PodPunkts podpunkt20 = new PodPunkts("Мастика", 200, 4);
            PodPunkts podpunkt21 = new PodPunkts("Съедобное конфетти", 150, 5);

            List<PodPunkts> forms = new List<PodPunkts>() { podpunkt1, podpunkt2, podpunkt3, podpunkt4 };
            List<PodPunkts> greatnesses = new List<PodPunkts>() { podpunkt5, podpunkt6, podpunkt7 };
            List<PodPunkts> flavours = new List<PodPunkts>() { podpunkt8, podpunkt9, podpunkt10, podpunkt11 };
            List<PodPunkts> amounts = new List<PodPunkts>() { podpunkt12, podpunkt13, podpunkt14, podpunkt15 };
            List<PodPunkts> glazes = new List<PodPunkts>() { podpunkt16, podpunkt17, podpunkt18 };
            List<PodPunkts> decors = new List<PodPunkts>() { podpunkt19, podpunkt20, podpunkt21 };
            Punkts form = new Punkts(forms, "Форма торта", 3);
            Punkts greatness = new Punkts(greatnesses, "Размер торта", 4);
            Punkts flavour = new Punkts(flavours, "Вкус коржей", 5);
            Punkts amount = new Punkts(amounts, "Количество коржей", 6);
            Punkts glaze = new Punkts(glazes, "Глазурь", 7);
            Punkts decor = new Punkts(decors, "Декор", 8);
            Punkts end = new Punkts(zatichka, "Конец заказа", 9);
            List<Punkts> punkti = new List<Punkts>() { form, greatness, flavour, amount, glaze, decor, end };
            int position = 3;
            int blocked_position = 3;
            List<PodPunkts> current_podpunkts = new List<PodPunkts>();
            

            menu(punkti, blocked_position);
            while (true)
            {
                
                int max_pos = 0;
                if (we_are_in_main)
                {
                    foreach (Punkts punkt in punkti)
                    {
                        max_pos += 1;
                    }
                    max_pos += 2;
                }
                else
                {
                    foreach (Punkts punkt in punkti)
                    {
                        if (blocked_position == punkt.position)
                        {
                            current_podpunkts = punkt.podPunkts;
                            foreach (PodPunkts podpunkt in punkt.podPunkts)
                            {
                                max_pos += 1;
                            }
                            max_pos += 2;
                        }
                    }
                }
                
                ConsoleKeyInfo key = Console.ReadKey();
                
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (position - 1 == 2 || position > max_pos)
                    {
                        position = 3;
                    }
                    else
                    {
                        position--;

                    }

                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    if (position + 1 > max_pos)
                    {
                        position = 3;


                    }
                    else
                    {
                        position++;

                    }
                }
                
                Console.Clear();
                menu(punkti, blocked_position);
                Console.SetCursorPosition(0, position);
                Console.WriteLine("->");
                Console.SetCursorPosition(0, position);

                if (key.Key == ConsoleKey.Enter)
                {
                    if (we_are_in_main)
                    { 
                        if (position != max_pos)
                        {
                            we_are_in_main = false;
                            Console.Clear();
                            blocked_position = position;
                            menu(punkti, blocked_position);
                        } 
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Спасибо за заказ! Если хотите сделать еще один, нажмите на клавишу Escape");
                            we_are_in_main = false;
                            string date_of_zakaz = DateTime.Now.ToString();
                            string text = date_of_zakaz + "\n" + "Состав заказа: " + new_line + "\n" + "Цена: " + all_cost + "\n";
                            save_to_file(text);
                            all_cost = 0;
                            new_line = "";
                        }
                        
                    }
                    else
                    {
                        foreach (PodPunkts podpunkt in current_podpunkts)
                        {
                            if (podpunkt.position == position)
                            {
                                new_line += podpunkt.name + " - " + podpunkt.cost + "; ";
                                all_cost += podpunkt.cost;
                            }
                        }
                        
                    }
                    
                }
                if (key.Key == ConsoleKey.Escape)
                {
                    if (we_are_in_main)
                    {
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        we_are_in_main = true;
                        Console.Clear();
                        menu(punkti, blocked_position);
                    }
                }

            }
        }
        private void menu(List<Punkts> punkti, int position)
        {
            if (we_are_in_main)
            {
                Console.WriteLine("Заказ тортов у Настасьи, торты на ваш выбор!\n" +
                "Выберите параметр торта\n" +
            "-----------------------");

                foreach (Punkts punkt in punkti)
                {
                    Console.WriteLine("  " + punkt.name_of_punkt);
                }
                Console.WriteLine();
                Console.WriteLine("Цена:" + all_cost);
                Console.WriteLine("Ваш торт:" + new_line);
            }
            else
            {
                Console.WriteLine("Для выхода нажмите Escape\n" +
                    "Выберите пункт из меню:\n" +
                    "-----------------------");

                foreach (Punkts punkt in punkti)
                {
                    if (position == punkt.position)
                    {
                        foreach (PodPunkts podpunkt in punkt.podPunkts)
                        {
                            Console.WriteLine("  " + podpunkt.name + " - " + podpunkt.cost);
                        }
                    }
                }
            }
        }
        private void save_to_file(string text)
        {
            string path = "C:\\Users\\Настя\\Desktop\\Cakes.txt";
            if (File.Exists(path))
            {
                File.AppendAllText(path, text);
            }
            else
            {
                File.Create(path);
                File.AppendAllText(path, text);
            }
        }

    }
        
}
