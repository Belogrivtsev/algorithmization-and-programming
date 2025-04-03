using System;
using System.Threading;
class Race
{
    public delegate void RaceFinishedHandler(Racer winner);
    public event RaceFinishedHandler RaceFinished;

    public Racer[] racers;
    public int finishDistance;
    public int checkInterval;
    public bool raceActive;
    public Race(Racer[] racers, int finishDistance, int checkInterval)
    {
        this.racers = racers;
        this.finishDistance = finishDistance;
        this.checkInterval = checkInterval;
    }
    public void Start()
    {
        raceActive = true;
        Console.WriteLine("Гонка началась!\n");
        while (raceActive)
        {
            foreach (var racer in racers)
            {
                racer.Move();
                Console.WriteLine($"{racer.Name} прошел {racer.Distance} метров (текущая скорость: {racer.Speed} м/с)");
                if (racer.Distance >= finishDistance)
                {
                    raceActive = false;
                    OnRaceFinished(racer);
                    break;
                }
            }
            Console.WriteLine();
            Thread.Sleep(checkInterval);    
        }
    }
    public virtual void OnRaceFinished(Racer winner)
    {
        RaceFinished?.Invoke(winner);
    }
}
class Racer
{
    public static Random random = new Random();
    public string Name { get; }
    public int Speed { get; set; }
    public int Distance { get; set; }
    public Racer(string name)
    {
        Name = name;
        Speed = random.Next(30, 61); // начальная скорость 30-60
        Distance = 0;
    }
    public void Move()
    {
        Distance += Speed;
        Speed = random.Next(30, 151);
    }
}
class App
{
    static void Main()
    {
        Racer[] racers = new Racer[]
        {
            new Racer("Mitsubishi Galant 8"),
            new Racer("Ford Scorpio"),
            new Racer("Nissan Cefiro A31")
        };
        Race race = new Race(racers, 1000, 1000);
        race.RaceFinished += winner => Console.WriteLine($"\nГонка окончена: Победил {winner.Name}!");
        race.Start();
    }
}