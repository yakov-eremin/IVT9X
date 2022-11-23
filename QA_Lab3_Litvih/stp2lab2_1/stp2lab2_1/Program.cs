using System;

namespace stp2lab2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            RoomFabric roomFabric = new RoomFabric();
            Room room = roomFabric.CreateRoom(100.5, 5);
            double res1;
            room.Display();
            res1 = room.ForOne();
            Console.WriteLine("Площадь на одного человека: " + res1);

            HouseFabric houseFabric = new HouseFabric();
            House house = houseFabric.CreateHouse(100.5, 5, 200.4, 6, 110.7, 4, 50);
            double res2;
            house.Display();
            res2 = house.Lowest();
            Console.WriteLine("Минимальная площадь на 1 человека: " + res2);
        }
    }
}
