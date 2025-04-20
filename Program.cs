using static Cuckoo_Clock.ClockCount;

namespace Cuckoo_Clock;

class Program
{
    static void Main(string[] args)
    {
        string initialTime = "08:17";
        int targetChimes = 47;
        string finalTime = ChimesCount(initialTime, targetChimes);
        Console.WriteLine(finalTime);
        
        string initialTime2 = "05:00";
        int targetChimes2 = 32;
        string finalTime2 = ChimesCount(initialTime2, targetChimes2);
        Console.WriteLine(finalTime2);
        Console.ReadKey();
    }
}