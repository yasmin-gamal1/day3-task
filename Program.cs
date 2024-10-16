using System;

public class Duration
{
    private int hours;
    private int minutes;
    private int seconds;

    
    public int Hours
    {
        get => hours;
        set => hours = (value >= 0) ? value : 0;  
    }

    public int Minutes
    {
        get => minutes;
        set
        {
            if (value >= 0)
            {
                hours += value / 60;  
                minutes = value % 60; 
            }
            else
            {
                minutes = 0; 
            }
        }
    }

    
    public int Seconds
    {
        get => seconds;
        set
        {
            if (value >= 0)
            {
                Minutes += value / 60; 
                seconds = value % 60;  
            }
            else
            {
                seconds = 0; 
            }
        }
    }

    
    public Duration(int hours, int minutes, int seconds)
    {
        this.Hours = hours;
        this.Minutes = minutes;
        this.Seconds = seconds;
    }

   
    public Duration(int totalSeconds)
    {
        this.Hours = totalSeconds / 3600;
        totalSeconds %= 3600;
        this.Minutes = totalSeconds / 60;
        this.Seconds = totalSeconds % 60;
    }

  
    public override string ToString()
    {
        return $"{hours}H:{minutes}M:{seconds}S";
    }

  
    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is Duration))
            return false;

        Duration other = (Duration)obj;
        return this.hours == other.hours && this.minutes == other.minutes && this.seconds == other.seconds;
    }

    public override int GetHashCode()
    {
        return (hours, minutes, seconds).GetHashCode();
    }

    
    public static Duration operator +(Duration d1, Duration d2)
    {
        return new Duration(d1.ToTotalSeconds() + d2.ToTotalSeconds());
    }

   
    public static Duration operator +(int seconds, Duration d)
    {
        return new Duration(seconds + d.ToTotalSeconds());
    }

    
    public static Duration operator ++(Duration d)
    {
        d.Minutes += 1;
        return d;
    }

    
    public static Duration operator --(Duration d)
    {
        if (d.Minutes > 0 || d.Hours > 0)
        {
            d.Minutes -= 1;
        }
        return d;
    }

   
    public static bool operator <=(Duration d1, Duration d2)
    {
        return d1.ToTotalSeconds() <= d2.ToTotalSeconds();
    }

    
    public static bool operator >=(Duration d1, Duration d2)
    {
        return d1.ToTotalSeconds() >= d2.ToTotalSeconds();
    }

    
    public int ToTotalSeconds()
    {
        return (hours * 3600) + (minutes * 60) + seconds;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Duration D1 = new Duration(1, 59, 50);
        Duration D2 = new Duration(3600);  
        Duration D3 = new Duration(7800);  
        Duration D4 = new Duration(666);   

        
        Console.WriteLine(D1); 
        Console.WriteLine(D2); 
        Console.WriteLine(D3); 
        Console.WriteLine(D4); 

       
        D3 = D1 + D2;
        Console.WriteLine(D3); 
        D3 = 666 + D3;
        Console.WriteLine(D3);
        D1++;
        Console.WriteLine(D1); 

        D2--;
        Console.WriteLine(D2); 

        if (D1 <= D2)
        {
            Console.WriteLine("D1 is less than or equal to D2");
        }
        else
        {
            Console.WriteLine("D1 is greater than D2");
        }
    }
}
