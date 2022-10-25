using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    internal class DataBase
    {
        public static Dictionary<Voditel,Narushenie> VN = new Dictionary<Voditel,Narushenie>();
        public static List<Narushenie> listNarushenie = new List<Narushenie>();
        public static List<Voditel> listVoditel = new List<Voditel>();

        public static void Initial()
        {
            var narushenie=new Narushenie();
            narushenie.money = 1500;
            narushenie.info = "Превышение скорости";
            narushenie.description = "Превышение скорости в пределах города.";
            listNarushenie.Add(narushenie);
            narushenie = new Narushenie();
            narushenie.money = 2500;
            narushenie.info = "Пересечение сплошной";
            narushenie.description = "Пересечение двойной сплошной линии.";
            listNarushenie.Add(narushenie);

            Voditel voditel = new Voditel("Николаев Сергей Иванович", "1");
            Voditel voditel2 = new Voditel("Сергунов Артем Дмитриевич", "2");
            Voditel voditel3 = new Voditel("Попышкин Евгений Алексеевич", "3");
            listVoditel.Add(voditel);
            listVoditel.Add(voditel2);
            listVoditel.Add(voditel3);
            VN.Add(listVoditel[0], listNarushenie[0]);
            VN.Add(listVoditel[1], listNarushenie[1]);
        }

        public static void Delete(Voditel v)
        {
            foreach (Voditel voditel in listVoditel)
            {
                if (v.id == voditel.id)
                {
                    foreach (var voditel1 in VN.Keys)
                    {
                        if (v.id == voditel1.id)
                        {
                            int shtraf = VN[voditel1].money;
                            Console.WriteLine("Штрафы водителя: " + shtraf + "\n" +
                                "Удалить штраф из базы данных?\n" +
                                "1- Да\n" +
                                "2- Нет");
                            int doIt = int.Parse(Console.ReadLine());
                            switch (doIt)
                            {
                                case 1:
                                    VN.Remove(voditel1);
                                    Console.WriteLine("Список штрафов очищен, штрафов нет.");
                                    break;
                                case 2:
                                    break;
                                default: break;
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Штрафы не найдены.");
                            break;
                        }
                    }
                    break;

                }
                else
                {
                    Console.WriteLine("Водитель не найден.");
                    break;
                }
            }
        }

        public static void ListShtraf()
        {
            if (listNarushenie.Count != 0)
            {
                foreach (Narushenie tariff in listNarushenie)
                {
                    Console.WriteLine(tariff.info + "\n" + tariff.description + "\n" + tariff.money);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Список штрафов пуст.");
            }
        }
    }
}
