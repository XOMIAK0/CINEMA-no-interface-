using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace cinema_5D_Best_Films
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isOpen = true; 
            Console.CursorVisible = true;

            Cinema[] seats = { new Cinema(1, 41), new Cinema(2, 500), new Cinema(3, 30) }; //создали 3 зала

            

            while (isOpen)
            {
                Console.WriteLine("ООП Кинотеатр.\n");

                for (int i = 0; i < seats.Length; i++)
                {
                    seats[i].ShowInfo();
                }
                

                Console.WriteLine("\nКакой зал желаете: ");
                int wishSeats = Convert.ToInt32(Console.ReadLine()) - 1; //выбираем ЗАЛ в котором будем сидеть
                Console.WriteLine("Введите количество мест для брони: ");
                int desiredPlaces = Convert.ToInt32(Console.ReadLine());

                bool isReservationCompleted = seats[wishSeats].Reserve(desiredPlaces); //desired - желаемых

                if (isReservationCompleted)
                {
                    Console.WriteLine("Бронь прошла успешно, ждем вас!");
                }
                else
                {
                    Console.WriteLine("Недостаточно свободных мест");
                }
                
                Console.ReadKey();
                
                Console.Clear();
            }

            
        }


    }

    class Cinema
    {
        public int Number;
        public int MaxPlaces;
        public int FreePlaces;
        public int reservedSeats;

        public int height;
        public int width;

        public Cinema(int number, int maxPlaces)
        {
            Number = number;
            MaxPlaces = maxPlaces;
            FreePlaces = maxPlaces;
        }


        public void ShowInfo()
        {
            Console.WriteLine($"Зал: {Number}. Свободно мест: {FreePlaces} из {MaxPlaces}:");
        }

        public bool Reserve(int places) //сюда отправляем количество мест которые хотим забронировать
        {
            if (FreePlaces >= places)
            {
                FreePlaces -= places;
                return true;
            }
            else
            {
                return false;
            }
        }
        

        
    }
}
