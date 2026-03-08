using System;

class clockType
{
    public int hours, minutes, seconds;

    // Default Constructor
    public clockType() { hours = 0; minutes = 0; seconds = 0; }

    // Parameterized Constructors (1, 2, or 3 params)
    public clockType(int h) { hours = h; minutes = 0; seconds = 0; }
    public clockType(int h, int m) { hours = h; minutes = m; seconds = 0; }
    public clockType(int h, int m, int s) { hours = h; minutes = m; seconds = s; }

    // Increment methods
    public void incrementSecond() { seconds++; }
    public void incrementminutes() { minutes++; }
    public void incrementhours() { hours++; }

    // Print raw numbers
    public void printTime()
    {
        Console.WriteLine(hours + " " + minutes + " " + seconds);
    }

    // Challenge 1d — formatted as hh:mm:ss
    public void printFormatted()
    {
        Console.WriteLine(
            hours.ToString().PadLeft(2, '0') + ":" +
            minutes.ToString().PadLeft(2, '0') + ":" +
            seconds.ToString().PadLeft(2, '0'));
    }

    // isEqual with manual values
    public bool isEqual(int h, int m, int s)
    {
        return (hours == h && minutes == m && seconds == s);
    }

    // isEqual with another object
    public bool isEqual(clockType temp)
    {
        return (hours == temp.hours && minutes == temp.minutes && seconds == temp.seconds);
    }

    // Challenge 1a — elapsed seconds since midnight
    public int elapsedSeconds()
    {
        return (hours * 3600) + (minutes * 60) + seconds;
    }

    // Challenge 1b — remaining seconds until midnight
    public int remainingSeconds()
    {
        return (24 * 3600) - elapsedSeconds();
    }

    // Challenge 1c — how far apart two clocks are (in seconds)
    public int timeDifference(clockType other)
    {
        int diff = elapsedSeconds() - other.elapsedSeconds();
        return (diff < 0) ? -diff : diff; // absolute value
    }
}

class challenge1
{
    static void Main(string[] args)
    {
        // Default and parameterized constructors
        clockType empty_time = new clockType();
        clockType hour_time = new clockType(8);
        clockType minute_time = new clockType(8, 10);
        clockType full_time = new clockType(8, 10, 10);

        Console.Write("Empty time:  "); empty_time.printTime();
        Console.Write("Hour time:   "); hour_time.printTime();
        Console.Write("Minute time: "); minute_time.printTime();
        Console.Write("Full time:   "); full_time.printTime();

        // Increment methods
        full_time.incrementSecond();
        Console.Write("After +1 second:  "); full_time.printTime();

        full_time.incrementhours();
        Console.Write("After +1 hour:    "); full_time.printTime();

        full_time.incrementminutes();
        Console.Write("After +1 minute:  "); full_time.printTime();

        // isEqual checks
        Console.WriteLine("Equal to 9,11,11? " + full_time.isEqual(9, 11, 11));
        clockType cmp = new clockType(10, 12, 1);
        Console.WriteLine("Equal to cmp obj? " + full_time.isEqual(cmp));

        // Challenge 1 — elapsed, remaining, difference, formatted
        Console.WriteLine("\n=== Challenge 1 ===");
        clockType c1 = new clockType(10, 30, 0);
        clockType c2 = new clockType(12, 45, 0);

        Console.Write("c1 formatted: "); c1.printFormatted();
        Console.Write("c2 formatted: "); c2.printFormatted();
        Console.WriteLine("c1 elapsed seconds:    " + c1.elapsedSeconds());
        Console.WriteLine("c1 remaining seconds:  " + c1.remainingSeconds());
        Console.WriteLine("Difference (c1 & c2):  " + c1.timeDifference(c2) + " seconds");

        Console.ReadKey();
    }
}