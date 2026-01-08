namespace Schumacher
{
    #region Class
    class Race
    {
        //Fields
        private DateTime date;
        private string name;
        private int position;
        private int laps;
        private int points;
        private string team;
        private string status;

        //Properties
        public DateTime Date { get => date; set => date = value; }
        public string Name { get => name; set => name = value; }
        public int Position { get => position; set => position = value; }
        public int Laps { get => laps; set => laps = value; }
        public int Points { get  => points; set { if (value < 0) { throw new Exception("Nem lehet 0-nál kisebb."); } points = value; } }
        public string Team { get  => team; set => team = value; }
        public string Status { get  => status; set => status = value; }

        //Constructor
        public Race(string[] data)
        {
            Date = DateTime.Parse(data[0]);
            Name = data[1];
            Position = int.Parse(data[2]);
            Laps = int.Parse(data[3]);
            Points = int.Parse(data[4]);
            Team = data[5];
            Status = data[6];

        }

        //Override String
        public override string ToString()
        {
            return $"{Date}, {Name}, {Position}. ({Laps} kör, {Points} pont, csapat: {Team}, status: {Status})";
        }
    }
    #endregion
    internal class Program
    {

        static void Main(string[] args)
        {
            #region File Read
            StreamReader sr = null;
            List<Race> races = new List<Race>();
            try
            {
                sr = new StreamReader("schumacher.csv");
                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    try
                    {
                        string[] line = sr.ReadLine().Split(';');
                        Race race = new Race(line);
                        races.Add(race);
                    } catch (Exception)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Hibás adat(ok) a sorban.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            } catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nincs ilyen file.");
                Console.ForegroundColor = ConsoleColor.White;
            } finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }
            #endregion

            Console.ForegroundColor = ConsoleColor.Yellow;

            #region 3. feladat
            Console.WriteLine($"3. Feladat: {races.Count()}");
            #endregion

            #region 4. feladat
            Console.WriteLine($"4. Feladat: Magyar Nagydíj helyezései");
            foreach(Race race in races)
            {
                if (race.Name == "Hungarian Grand Prix" && race.Position != 0)
                {
                    Console.WriteLine($"{race.Date.ToShortDateString()}: {race.Position}. hely");
                }
            }
            #endregion

            #region 5. feladat
            Console.WriteLine("5. Feladat: Hibastatisztika");
            Dictionary<string, int> issues = new Dictionary<string, int>();
            foreach(Race race in races)
            {
                if (race.Status != "Finished" || race.Status.StartsWith('+'))
                {
                    if (issues.ContainsKey(race.Status))
                    {
                        issues[race.Status]++;
                    } else
                    {
                        issues.Add(race.Status, 1);
                    }
                }
            }
            foreach (var i in issues)
            {
                if (i.Value > 2)
                {
                    Console.WriteLine($"{i.Key}: {i.Value}");
                }
            }
            #endregion
            Console.ReadKey();
        }
    }
}
