using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Монополия
{
    internal class Program
    {
        public static string[,] pole = new string[8, 8]
        {
            {"|Бесплатная парковка       |","|        Весенняя ул.      |","|           ШАНС           |","|       пл. Маленькая      |","|        ул. Пушкина       |","|      ул. Подольская      |","|     ул. Серпуховская     |","|                   в тюрьму|" },
            {"|ул. Чехова                |","|                          |","|                          |","|                          |","|                          |","|                          |","|                          |","|                  пр Мишина|" },
            {"|Казанская ул.             |","|                          |","|                          |","|                          |","|                          |","|                          |","|                          |","|           Подоходный налог|" },
            {"|ул. Черношевского         |","|                          |","|                          |","|                          |","|                          |","|                          |","|                          |","|                 ул Курская|" },
            {"|ЖД Вокзал Серпуховский    |","|                          |","|                          |","|                          |","|                          |","|                          |","|                          |","|         ЖД вокзал Протвино|" },
            {"|ул. Дружбы                |","|                          |","|                          |","|                          |","|                          |","|                          |","|                          |","|                 ул Патрики|" },
            {"|ул. Ленина                |","|                          |","|                          |","|                          |","|                          |","|                          |","|                          |","|                   ул Арбат|" },
            {"|Посетитель- в Тюрьма      |","|       ул Нагатинская     |","|         Ул Огаево        |","|           ШАНС           |","|         Водопровод       |","|     Варшавское шоссе     |","|       ул. Парковая       |","|                     Вперёд|" }
        };
        public static string[,] info = new string[28, 9]
        {
            //расставить цвета 1
            {"Бесплатная парковка","0","Пусто","","","","","","" },
            {"Весенняя ул.","220","Игрок Пусто","Красный", "рента без домов 100"/**2*/," цена за дом 130"/**2*/," цена с 1 домом 120"/*10+(колво домов * 40)*/,"0","залог 210"},
            {"ШАНС","0","Взять карту","","","","","",""},
            {"пл. Маленькая","220","Игрок Пусто","Красный", "рента без домов 100"/**2*/," цена за дом 130"/**2*/," цена с 1 домом 120"/*10+(колво домов * 40)*/,"0","залог 210"},
            {"ул. Пушкина","220","Игрок Пусто","Красный", "рента без домов 100"/**2*/," цена за дом 130"/**2*/," цена с 1 домом 120"/*10+(колво домов * 40)*/,"0","залог 210"},
            {"ул. Подольская","260","Игрок Пусто","Жёлтый", "рента без домов 130"/**2*/," цена за дом 160"/**2*/," цена с 1 домом 150"/*10+(колво домов * 40)*/,"0","залог 250"},
            {"ул. Серпуховская","260","Игрок Пусто","Жёлтый", "рента без домов 130"/**2*/," цена за дом 160"/**2*/," цена с 1 домом 150"/*10+(колво домов * 40)*/,"0","залог 250"},
            {"в тюрьму","0","Отправляйтесь в тюрьму","","","","","",""},
            //2
            {"ул. Чехова","180","Игрок Пусто","Оранжевый", "рента без домов 70"/**2*/," цена за дом 100"/**2*/," цена с 1 домом 90"/*10+(колво домов * 40)*/,"0","залог 170"},
            {"пр Мишина","260","Игрок Пусто","Жёлтый", "рента без домов 130"/**2*/," цена за дом 160"/**2*/," цена с 1 домом 150"/*10+(колво домов * 40)*/,"0","залог 250"},
            //3
            {"Казанская ул.","180","Игрок Пусто","Оранжевый", "рента без домов 70"/**2*/," цена за дом 100"/**2*/," цена с 1 домом 90"/*10+(колво домов * 40)*/,"0","залог 170"},
            {"Подоходный налог","100","Заплатите 100","","","","","",""},
            //4
            {"ул. Черношевского","180","Игрок Пусто","Оранжевый", "рента без домов 70"/**2*/," цена за дом 100"/**2*/," цена с 1 домом 90"/*10+(колво домов * 40)*/,"0","залог 170"},
            {"ул Курская","300","Игрок Пусто","Зелёная", "рента без домов 130"/**2*/," цена за дом 50"/**2*/," цена с 1 домом 40"/*10+(колво домов * 40)*/,"0","залог 290"},
            //5
            {"ЖД Вокзал Серпуховский","200","Игрок Пусто","ЖД","20","","","","Залог 100"},
            {"ЖД вокзал Протвино","200","Игрок Пусто","ЖД","20","","","","Залог 100"},
            //6
            {"ул. Дружбы.","140","Игрок Пусто","Розовый", "рента без домов 40"/**2*/," цена за дом 70"/**2*/," цена с 1 домом 60"/*10+(колво домов * 40)*/,"0","залог 130"},
            {"ул Патрики","300","Игрок Пусто","Зелёная", "рента без домов 130"/**2*/," цена за дом 50"/**2*/," цена с 1 домом 40"/*10+(колво домов * 40)*/,"0","залог 290"},
            //7
            {"ул. Ленина","140","Игрок Пусто","Розовый", "рента без домов 40"/**2*/," цена за дом 70"/**2*/," цена с 1 домом 60"/*10+(колво домов * 40)*/,"0","залог 130"},
            {"ул Арбат","300","Игрок Пусто","Зелёная", "рента без домов 130"/**2*/," цена за дом 50"/**2*/," цена с 1 домом 40"/*10+(колво домов * 40)*/,"0","залог 290"},
            //8
            {"Посетитель- в Тюрьма","0","Пусто","В Тюрьме","Игрок","","","",""},
            {"ул Нагатинская","140","Игрок Пусто","Розовый", "рента без домов 40"/**2*/," цена за дом 70"/**2*/," цена с 1 домом 60"/*10+(колво домов * 40)*/,"0","залог 130"},
            {"Ул Огаево","100","Игрок Пусто","Голубой", "рента без домов 10"/**2*/," цена за дом 40"/**2*/," цена с 1 домом 30"/*10+(колво домов * 40)*/,"0","залог 90"},
            {"ШАНС","0","Взять карту","","","","","",""},
            {"Водопровод","150","Игрок Пусто","",/*х**/"10","","","","Залог 75"},
            {"Варшавское шоссе","100","Игрок Пусто","Голубой", "рента без домов 10"/**2*/," цена за дом 40"/**2*/," цена с 1 домом 30"/*10+(колво домов * 40)*/,"0","залог 90"},
            {"ул. Парковая","100","Игрок Пусто","Голубой", "рента без домов 10"/**2*/," цена за дом 40"/**2*/," цена с 1 домом 30"/*10+(колво домов * 40)*/,"0","залог 90"},
            {"Вперёд","0","получите 200","","","","","",""}


        };
        public static string[,] chance = new string[20, 3]
        {
            {"Штраф",/*:*/ "Вы заключили сделку в ретроградный меркурий",/*Заплатите:*/"100"},
            {"Штраф", "Вы не погладили котика","50"},
            {"Штраф", "На ваший улицах ремонт","200"},
            {"Штраф", "Вы попали к дагестанским учёным","350"},
            {"Штраф", "Вы попали в больницу","150"},
            {"Штраф", "Вас сбила машина","250"},
            {"Штраф", "Ремонт сожённой кухни","300"},
            //
            {"Приз", "Вы выиграли в лотерею","200"},
            {"Приз", "Вы нашли в кармане затерянную купюру","100"},
            {"Приз", "Вы увидели купюру на дороге","50"},
            {"Приз", "Вас нашла милфа на один вечер","300"},
            {"Приз", "Вы заключили сделку по картам таро","150"},
            {"Приз", "Подарок от бабушки","350"},
            {"Приз", "Вы продали картину","250"},
            //
            {"Событие", "Пройдите на поле \"Вперёд\"","-1"},
            {"Событие", "Вы можете выйти из тюрьмы","-2"},
            {"Событие", "Вы отправляетесь в тюрьму","-3"},
            {"Событие", "Пройдите на поле \"ЖД Вокзал Серпуховский\"","-4"},
            {"Событие", "У вас День рождения. Пусть все заплатят","100"},
            {"Событие", "Вас пронесло","-6"},
        };
        public static List<Players> players = new List<Players>();

        public class Players
        {
            public string Name { get; set; }
            public string Status { get; set; }
            public int NegativeMoney { get; set; }
            public double Money { get; set; }

            public int PositionX { get; set; }
            public int PositionY { get; set; }
            public List<string> Inventary { get; set; }
        }
        public static string CheckName()
        {
            Console.WriteLine("Введите имя");
            var name = Console.ReadLine();
            var isNameExist = players.Where(x => x.Name == name).ToList();
            if (isNameExist.Count >= 1)
            {
                Console.WriteLine("Введите другок имя(Такое уже есть)");
                CheckName();
            }
            return name;
        }
        public static void StartGame()
        {
            players.Clear();
            Console.WriteLine("Введите колво игроков");
            int count = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                players.Add(new Players { Name = CheckName(), Status = "true", Money = 1300, PositionX = 7, PositionY = 7, NegativeMoney = 0, Inventary = new List<string>() });
            }
            Console.Clear();
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Игрок {players[i].Name} - в игре? {(players[i].Status == "true")} - Начальный капитал {players[i].Money}");
            }
        }

        public static int DropCube()
        {
            Random randon = new Random();
            int second = randon.Next(1, 7);
            int first = randon.Next(1, 7);

            int val = second + first;
            Console.WriteLine("---------   ---------");
            Console.WriteLine("|       |   |       |");
            Console.WriteLine($"|   {first}   |   |   {second}   |");
            Console.WriteLine("|       |   |       |");
            Console.WriteLine("---------   ---------");
            Thread.Sleep(500);
            return val;
        }

        static async void Main2()
        {
            StartGame();
            Console.WriteLine("Все игроки добавлены. Нажмите любую клавишу для продолжения");
            Console.ReadKey();

            int Max = 0;
            int cur = 0;
            int lastI = 0;
            Players firstplayer = new Players();
            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine($"Игрок {players[i].Name} бросил кубики");
                Console.WriteLine($"Со значением {await Task.Run(() => cur = DropCube())}");
                if (cur > Max)
                {
                    Max = cur;
                    firstplayer = players[i];
                    lastI = i;
                }
            }
            players[lastI] = players[0];
            players[0] = firstplayer;

            Console.Write("Загрузка игры...");
            string h = "[_";
            for (int i = 0; i < 15; i++)
            {
                Console.Write(h);
                h = "_";
                if (i == 14)
                {
                    h = "]";
                    Console.WriteLine(h);
                }
                Thread.Sleep(100);
            }
            Console.WriteLine("Загрузка завершена");
            Thread.Sleep(300);
            Console.Clear();
            

            while (true)
            {
                PrintPole();
                var isActiveGame = players.Where(x => x.Status == "true").ToList();
                if (isActiveGame.Count < 2)
                {
                    break;
                }
                var curentPlayer = GetPlayers();

                Console.WriteLine("Ходит игрок" + curentPlayer.Name);

                if (curentPlayer.Status == "Jail")
                {
                    foreach (var obj in curentPlayer.Inventary)
                    {
                        if (obj == "Вы можете выйти из тюрьмы")
                        {
                            break;
                        }
                        curentPlayer.Money -= 50;
                    }
                }
                int cubeScore = DropCube();
                curentPlayer = MakeStep(curentPlayer, cubeScore);
                curentPlayer = GeneratePole(curentPlayer);

                //Запись результатов

                //Выбор возможности покупки дома

                for (int i = 0; i < players.Count; i++)
                {
                    if (players[i].Name == curentPlayer.Name)
                    {
                        players[i] = curentPlayer;
                    }
                }




                Console.WriteLine("Игрок завершил ход");
                if (curentPlayer.Money < 0)
                {
                    curentPlayer.NegativeMoney += 1;
                    if (curentPlayer.NegativeMoney == 3)
                    {
                        curentPlayer.Status = "false";
                        curentPlayer = ReturnPole(curentPlayer);
                    }
                }
                else
                {
                    curentPlayer.NegativeMoney = 0;
                }





                Console.WriteLine("Нажмите пробел,если хотеите сделать что-то ещё\nНажмите любую клавишу, чтоб продолжить");
                ConsoleKeyInfo a;
                try
                {
                   a = Console.ReadKey();
                }
                catch(Exception)
                {

                    throw;
                }
                var a = Console.ReadKey();
                if (a.Key == ConsoleKey.Spacebar)
                {
                    Console.WriteLine("Вы хотите купить дом? Выберите участок");
                    for (int i = 0; i < curentPlayer.Inventary.Count; i++)
                    {
                        if ("Вы можете выйти из тюрьмы" != curentPlayer.Inventary[i])
                        {
                            Console.WriteLine($"{i} - {curentPlayer.Inventary[i]}");
                        }
                    }
                    Console.WriteLine("Введите номер улицы на которую хотите поставить дом");
                    int y = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите кол-во домов");
                    int z = Convert.ToInt32(Console.ReadLine());
                    string[] mass = new string[5];
                    for (int i = 0; i < 28; i++)
                    {
                        if (curentPlayer.Inventary[y] == info[i, 5])
                        {
                            mass = info[i, 5].Split(' ');
                        }
                    }
                    if (Convert.ToDouble(mass[mass.Length - 1]) * z > curentPlayer.Money)
                    {
                        Console.WriteLine("Денег недостаточно");
                    }
                    else
                    {
                        curentPlayer.Money -= Convert.ToDouble(mass[mass.Length - 1]) * z;
                        info[y, 7] += z;
                    }



                }
                else if (a.Key == ConsoleKey.Enter)
                {

                }
                Console.Clear();
            }
            Console.ReadLine();
        }

        public static Players ReturnPole(Players player)
        {
            player.Inventary = null;
            for (int i = 0; i < 28; i++)
            {
                if (info[i, 2] == player.Name)
                {
                    info[i, 2] = "Игрок Пусто";
                }
            }
            return player;
        }
        public static Players GeneratePole(Players player)
        {
            string poleStep = pole[player.PositionX, player.PositionY];
            for (int i = 0; i < 2; i++)
            {
                int palka = poleStep.IndexOf("|");
                if (palka != -1)
                {
                    poleStep = poleStep.Remove(palka, 1);
                }
            }

            string[] mass = poleStep.Split(' ');
            string poleName = "";
            for (int i = 0; i < mass.Length; i++)
            {
                if (mass[i] != "")
                {
                    poleName += mass[i] + " ";
                }
            }
            int curInfoValue = -1;
            poleName = poleName.Remove(poleName.Length - 1, 1);
            for (int i = 0; i < 28; i++)
            {

                if (poleName.ToLower() == info[i, 0].ToLower())
                {
                    curInfoValue = i;
                }
            }
            player = PoleChec(player, curInfoValue);
            //TODo Неверно возвращ при поиске стр в массиве
            //TODo был реализован поиск элементов в массиве Info

            return player;
        }
        public static Players ToJail(Players player)
        {
            player.Status = "Jail";
            player.PositionX = 0;
            player.PositionY = 7;

            return player;
        }

        public static Players PoleChec(Players player, int id)
        {
            if (info[id, 1] == "0")
            {
                if (info[id, 0] == "в тюрьму")
                {
                    Console.WriteLine("Вы отправляетесь в тюрьму");
                    player = ToJail(player);//
                }
                else if (info[id, 0] == "ШАНС")
                {

                    player = Chance(player);//
                }
            }
            else
            {
                if (info[id, 2] == "Игрок Пусто")
                {
                    player = Buy(player, id);
                }
                else if (info[id, 7].Contains("залог "))
                {
                    Renta(player, id);
                }
            }
            return player;
        }

        public static Players Chance(Players player)
        {
            Random rand = new Random();
            int randChance = rand.Next(0, chance.Length);
            Console.WriteLine($"Карта {chance[randChance, 0]}.{chance[randChance, 1]}. {chance[randChance, 2]} Крылышек.");
            if (chance[randChance, 0] == "Событие")
            {
                if (chance[randChance, 2] == "-1")
                {
                    player = GoToPole(player, "7,7");

                    return player = GeneratePole(player);
                }
                if (chance[randChance, 2] == "-2")
                {
                    //
                    player.Inventary.Add("Вы можете выйти из тюрьмы");
                    return player;
                }
                if (chance[randChance, 2] == "-3")
                {
                    player = GoToPole(player, "7,0");
                    player.Status = "Jail";
                    player = GeneratePole(player);
                    return player;
                }
                if (chance[randChance, 2] == "-4")
                {
                    player = GoToPole(player, "0,4");
                    return player = GeneratePole(player);
                }
                if (chance[randChance, 2] == "100")
                {
                    double moneyForMe = 0;
                    for (int i = 0; i < players.Count; i++)
                    {
                        players[i].Money -= 100;
                        moneyForMe += 100;
                    }
                    player.Money += moneyForMe;
                    return player;
                }
            }
            else if (chance[randChance, 0] == "Приз")
            {
                player.Money += Convert.ToDouble(chance[randChance, 2]);
            }
            else
            {
                player.Money -= Convert.ToDouble(chance[randChance, 2]);
            }
            return player;
        }
        public static Players Buy(Players player, int id)
        {
            if (player.Money < Convert.ToDouble(info[id, 1]))
            {
                Console.WriteLine("Денег на покупку не достаточно");
                return player;
            }
            Console.WriteLine($"Хотите ли вы купить улицу {info[id, 0]}\nПо цене {info[id, 1]} \nВаш баланс:{player.Money}");
            string h = Console.ReadLine();

            if (h.ToLower() == "да" ? true : false)
            {
                player.Money -= Convert.ToDouble(info[id, 1]);
                info[id, 2] = player.Name;
                player.Inventary.Add(info[id, 0]);
                Console.WriteLine($"Вы купили улицу {info[id, 0]}\nПо цене {info[id, 1]} \nВаш баланс:{player.Money}");
                return player;
            }

            return player;
        }
        public static Players Renta(Players player, int id)
        {

            int playersId = -1;
            for (int i = 0; i < players.Count; i++)
            {
                if (info[id, 2] == players[i].Name)
                {
                    playersId = i;
                }
            }
            string[] poles = new string[3];
            int y = 0;
            for (int i = 0; i < poles.Length; i++)
            {
                if (info[id, 3] == info[i, 3])
                {
                    poles[y] = info[i, 2];
                    y++;
                }
            }
            y = 0;
            int rentSum;
            for (int i = 0; i < 3; i++)
            {
                if (info[id, 2] == poles[i])
                {
                    y++;
                }
            }

            if (y == 3)
            {
                string[] rent = info[id, 4].Split(' ');
                if (info[id, 7] == "0")
                {

                    rentSum = Convert.ToInt32(rent[rent.Length - 1]) * 2;
                }
                else
                {
                    int houses = Convert.ToInt32(pole[id, 7]);
                    rentSum = ((Convert.ToInt32(rent[rent.Length - 1]) * 2) * (houses * Convert.ToInt32(rent[rent.Length - 1])) * 2);
                }
            }
            else
            {
                string[] rent = pole[id, 4].Split(' ');
                rentSum = Convert.ToInt32(rent[rent.Length - 1]);
            }

            Console.WriteLine($"Вы заплатиле ренту игроку - {rentSum}");

            players[playersId].Money += rentSum;
            player.Money -= rentSum;

            return player;
        }
        public static Players GetMoney(Players player, int money)
        {
            player.Money += money;

            return player;
        }

        public static string GetNextPole(int x, int y, int score, Players player)
        {
            int thisX = 0;
            int thisY = 0;
            for (int i = 0; i < score; i++)
            {
                if (x == 0)
                {
                    thisX = 0;
                    thisY = -1;
                    if (y == 0)
                    {
                        thisX = 1;
                        thisY = 0;
                    }

                }
                else if (x == 7)
                {
                    thisX = 0;
                    thisY = 1;
                    if (y == 7)
                    {
                        thisX = -1;
                        thisY = 0;
                    }
                }
                else if (y == 0)
                {
                    thisX = 1;
                    thisY = 0;
                    if (x == 7)
                    {
                        thisX = 0;
                        thisY = 1;
                    }
                }
                else if (y == 7)
                {
                    thisX = -1;
                    thisY = 0;
                    if (x == 0)
                    {
                        thisX = 0;
                        thisY = -1;
                    }
                }
                if (x == 7 && y == 7)
                {
                    GetMoney(player, 200);
                }
                x += thisX;
                y += thisY;
            }

            return $"{x},{y}";
        }

        public static Players GoToPole(Players player, string pos)
        {
            string[] mass = pos.Split(',');

            player.PositionX = Convert.ToInt32(mass[0]);
            player.PositionY = Convert.ToInt32(mass[1]);
            return player;
        }
        public static Players MakeStep(Players player, int score)
        {
            string nextPole = GetNextPole(player.PositionX, player.PositionY, score, player);
            player = GoToPole(player, nextPole);

            return player;
        } //
        public static Players GetPlayers()
        {
            curPlayers++;
            if (curPlayers == players.Count)
            {
                curPlayers = 0;
            }
            if (players[curPlayers].Status == "false")
            {
                GetPlayers();
            }
            return players[curPlayers];
        }
        public static void PrintPole()
        {
            for (int j = 0; j < 8 * 28; j++)
            {
                Console.Write("_");
            }
            Console.WriteLine();
            for (int i = 0; i < 8; i++)
            {

                for (int j = 0; j < 8; j++)
                {
                    Console.Write(pole[i, j]);
                }
                if (i != 7)
                {

                    Console.WriteLine("|                          ");
                    Console.WriteLine("|                          ");
                    Console.WriteLine("|                          ");
                    Console.WriteLine("|                          ");
                }
            }
            Console.WriteLine();
            for (int j = 0; j < 8 * 28; j++)
            {
                Console.Write("_");
            }

        }
        static void Main(string[] args)
        {
            Main2();
            while (true)
            {
                Console.ReadKey();
                Console.ReadKey();
                Console.ReadKey();
                Console.ReadKey();
            }
          
        }
        public static int curPlayers = -1;
        
    }
}
