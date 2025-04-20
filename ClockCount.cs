namespace Cuckoo_Clock;

public class ClockCount
{
    public static string ChimesCount(string initialTime, int targetChimes)
    {
        string[] parts = initialTime.Split(':');
        int hour = int.Parse(parts[0]);   
        int minute = int.Parse(parts[1]); 

        int count = 0; 
        
        // Проверяем, не бьёт ли кукушка в эту минуту
        int chimesNow = GetChimesCount(hour, minute);
        if (chimesNow > 0)
        {
            for (int i = 1; i <= chimesNow; i++)
            {
                count++;
                if(count == targetChimes)
                {
                    return FormatTime(hour, minute);
                }
            }
        }

        // Двигаемся поминутно вперёд
        while (count < targetChimes)
        {
            // Прибавляем минуту
            minute++;
            if (minute == 60) //прибавление минут от изначального значения
            {
                minute = 0;
                hour++;
                if(hour == 13)
                {hour = 1; }
            }
            
            int chimes = GetChimesCount(hour, minute); //тут можно переменную chimesNow или мы перезапишем код?
            if (chimes > 0)
            {
                for (int i = 1; i <= chimes; i++)
                {
                    count++;
                    if(count == targetChimes)
                    {
                        return FormatTime(hour, minute);
                    }
                }
            }
        }
        
        return FormatTime(hour, minute);
    }

    private static int GetChimesCount(int hour, int minute)
    {
        if (minute == 0)
        {
            return hour; // при hour=12 => 12 ударов
        }
        // На 15, 30, 45 минуте — 1 удар
        else if (minute == 15 || minute == 30 || minute == 45)
        {
            return 1;
        }
        
        // В остальные минуты — 0 ударов
        return 0;
    }

    private static string FormatTime(int hour, int minute)
    {
        // hour уже гарантированно 1..12, minute 0..59
        return $"{hour:00}:{minute:00}";
    }
}