



namespace Pilotak
{
    public partial class Form1 : Form
    {
        static List<Driver> drivers = new List<Driver>();
        public Form1()
        {
            InitializeComponent();
            StreamReader sr = null;
            try
            {
                sr = new StreamReader("pilotak.csv");
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string[] sor = sr.ReadLine().Split(';');
                    Driver driver = new Driver(sor);
                    drivers.Add(driver);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        class Driver
        {
            private string name;
            private DateTime birth;
            private string origin;
            private int? number;

            public string Name { get { return name; } set { name = value; } }
            public DateTime Birth { get => birth; set { birth = value; } }
            public string Origin { get => origin; set { origin = value; } }
            public int? Number { get => number; set { number = value; } }

            public Driver(string[] data)
            {
                this.Name = data[0];
                this.Birth = DateTime.Parse(data[1]);
                this.Origin = data[2];
                if (data[3] != "")
                {
                    this.Number = int.Parse(data[3]);
                }
                else this.Number = null;
            }
        }

        private void BtnF3_Click(object sender, EventArgs e)
        {
            int count1 = 0;
            foreach (var i in drivers)
            {
                count1++;
            }
            AnswTextBox.Text += $"3. feladat: {count1}\n";
        }

        private void BtnF4_Click(object sender, EventArgs e)
        {
            Driver last = drivers[drivers.Count - 1];
            AnswTextBox.Text += $"4. feladat: {last.Name}\n";
        }

        private void BtnF5_Click(object sender, EventArgs e)
        {
            AnswTextBox.Text += "5. feladat:\n";
            foreach (var i in drivers)
            {
                if (i.Birth < DateTime.Parse("1901-01-01"))
                {
                    AnswTextBox.Text += $"\t {i.Name} ({i.Birth.ToShortDateString()})\n";
                }
            }
        }

        private void BtnF6_Click(object sender, EventArgs e)
        {
            Driver minDriver = drivers[0];
            foreach (var i in drivers)
            {
                if (i.Number < minDriver.Number && i.Number != null)
                {
                    minDriver = i;
                }
            }
            AnswTextBox.Text += $"6. feladat: {minDriver.Origin}\n";
        }

        private void BtnF7_Click(object sender, EventArgs e)
        {
            AnswTextBox.Text += "7. feladat: ";
            Dictionary<int, int> numbers = new Dictionary<int, int>();
            foreach (var i in drivers)
            {
                if (i.Number != null)
                {
                    if (numbers.ContainsKey(i.Number.Value))
                    {
                        numbers[i.Number.Value]++;
                    } else
                    {
                        numbers.Add(i.Number.Value, 1);
                    }
                }
            }
            foreach (var i in numbers)
            {
                if (i.Value > 1)
                {
                    AnswTextBox.Text += $"{i.Key}, ";
                }
            }
            AnswTextBox.Text = AnswTextBox.Text.Remove(AnswTextBox.Text.Length -2, 2);
        }
    }
}
