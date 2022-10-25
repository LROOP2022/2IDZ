using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    class Programm
    {
        static void Main(string[] args)
        {

            DataBase.Initial();
            Console.WriteLine("База данный водителей готова к работе");
            Console.Write("Как к вам обращаться? ");
            string fio = Console.ReadLine();
            Console.Write(fio + ", Введите ID водителя ");
            string id = Console.ReadLine();
            Voditel client=new Voditel(fio, id);
            Console.WriteLine("Уважаемый " + client.fio + ", выберите действие\n" +
                "1-Вывод информации о нарушениях\n" +
                "2-Проверить штрафы\n" +
                "0-Выход");
            int doIt = int.MaxValue;
            while (doIt > 0)
            {
                Console.Write("Ваш выбор: ");
                doIt = int.Parse(Console.ReadLine());
                switch (doIt)
                {
                    case 1:
                        DataBase.ListShtraf();
                        break;
                    case 2:
                        DataBase.Delete(client);
                        break;
                    case 0:
                        doIt = 0;
                        break;
                    default: break;

                }
            }
            Console.ReadLine();
        }
    }
}