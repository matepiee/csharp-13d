namespace Helsinki
{
    public partial class Form1 : Form
    {
        private static List<Versenyzo> Versenyzok = new List<Versenyzo>();
        private static List<Versenyzo> Dontosok = new List<Versenyzo>();
        private static bool isFileRead = false;
        public Form1()
        {
            InitializeComponent();
            richTextBox1.Text = "A file / fileok nincsenek beolvasva";
            checkFiles();
        }
        #region 4. feladat metódusa
        private static double Task4(string nev)
        {
            double pontszam = 0d;
            foreach (var i in Versenyzok)
            {
                if (i.Nev.ToLower() == nev.ToLower())
                {
                    pontszam += i.Komponens;
                    pontszam += i.Technikai;
                    pontszam -= i.Levonas;
                }
            }
            foreach (var i in Dontosok)
            {
                if (i.Nev.ToLower() == nev.ToLower())
                {
                    pontszam += i.Komponens;
                    pontszam += i.Technikai;
                    pontszam -= i.Levonas;
                }
            }
            return pontszam;
        }
        #endregion

        private void checkFiles()
        {
            #region File állapotának ellenõrzése
            if (isFileRead)
            {
                richTextBox1.Text = "A file / fileok beolvasva.\n";
                buttonBeolvas.Enabled = false;
                Task2Btn.Enabled = true;
                Task3Btn.Enabled = true;
                Task5Btn.Enabled = true;
                Task7Btn.Enabled = true;
                Task8Btn.Enabled = true;
                Task5TextBox.Enabled = true;
                Task5Label.Enabled = true;
            }
            else
            {
                Task2Btn.Enabled = false;
                Task3Btn.Enabled = false;
                Task5Btn.Enabled = false;
                Task7Btn.Enabled = false;
                Task8Btn.Enabled = false;
                Task5TextBox.Enabled = false;
            }
            #endregion
        }
        private void buttonBeolvas_Click(object sender, EventArgs e)
        {
            #region Beolvasás
            StreamReader sr = null;
            string filePath = "rovidprogram.csv";
            try
            {
                sr = new StreamReader(filePath);
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    try
                    {
                        Versenyzok.Add(new Versenyzo(sr.ReadLine().Split(';')));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Hiba a versenyzõ hozzáadása során.");
                    }
                }
                MessageBox.Show($"Sikeres olvasás: {filePath}");
                isFileRead = true;
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show($"Nincs ilyen file: {filePath}");
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (sr != null) sr.Close();
            }
            filePath = "donto.csv";
            try
            {
                sr = new StreamReader(filePath);
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    try
                    {
                        Dontosok.Add(new Versenyzo(sr.ReadLine().Split(';')));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Hiba a versenyzõ hozzáadása során.");
                    }
                }
                MessageBox.Show($"Sikeres olvasás: {filePath}");
                isFileRead = true;
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show($"Nincs ilyen file: {filePath}");
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (sr != null) sr.Close();
                checkFiles();
            }
            #endregion
        }

        class Versenyzo
        {
            #region Mezõk
            private string nev;
            private string orszag;
            private double technikai;
            private double komponens;
            private int levonas;
            #endregion
            #region Property-k
            public string Nev { get { return nev; } set { nev = value; } } //Hagyományos
            public string Orszag { get => orszag; set => orszag = value; } //LAMBDA kifejezéssel
            public double Technikai { get => technikai; set => technikai = value; }
            public double Komponens { get => komponens; set => komponens = value; }
            public int Levonas { get => levonas; set => levonas = value; }
            #endregion
            #region Konstruktor
            public Versenyzo(string[] adatok)
            {
                Nev = adatok[0];
                Orszag = adatok[1];
                Technikai = double.Parse(adatok[2].Replace('.', ','));
                Komponens = double.Parse(adatok[3].Replace('.', ','));
                Levonas = int.Parse(adatok[4]);
            }
            #endregion
        }

        private void Task2Btn_Click(object sender, EventArgs e)
        {
            #region 2. feladat
            richTextBox1.Text += $"2. feladat\n\tA rövidprogramban {Versenyzok.Count()} induló volt.\n";
            Task2Btn.Enabled = false;
            #endregion
        }

        private void Task3Btn_Click(object sender, EventArgs e)
        {
            #region 3. feladat
            bool magyarBejutott = false;
            foreach (var i in Versenyzok)
            {
                if (i.Orszag == "HUN")
                {
                    magyarBejutott = true;
                    break;
                }
            }
            if (magyarBejutott)
            {
                richTextBox1.Text += $"3. feladat\n\tA magyar versenyzõ bejutott a kûrbe.\n";
            }
            else
            {
                richTextBox1.Text += $"3. feladat\n\tA magyar versenyzõ nem jutott be a kûrbe.\n";
            }
            Task3Btn.Enabled = false;
            #endregion
        }

        private void Task5Btn_Click(object sender, EventArgs e)
        {
            #region 5. feladat
            Versenyzo keresett = null;
            foreach (var i in Versenyzok)
            {
                if (i.Nev.ToLower() == Task5TextBox.Text.ToLower())
                {
                    keresett = i;
                }
            }
            if (keresett != null)
            {
                richTextBox1.Text += $"5. feladat\n\t";
                richTextBox1.Text += $"Kérem a versenyzõ nevét: {Task5TextBox.Text}\n";
                richTextBox1.Text += $"6. feladat\n\t";
                richTextBox1.Text += $"A versenyzõ összpontszáma: {Task4(keresett.Nev)}\n";
            }
            else
            {
                richTextBox1.Text += $"5. feladat\n\tIlyen nevû induló nem volt.\n";
            }
            #endregion
        }

        private void Task7Btn_Click(object sender, EventArgs e)
        {
            #region 7. feladat
            Dictionary<string, int> orszagok = new Dictionary<string, int>();
            foreach (var i in Dontosok)
            {
                if (orszagok.ContainsKey(i.Orszag))
                {
                    orszagok[i.Orszag] += 1;
                }
                else
                {
                    orszagok.Add(i.Orszag, 1);
                }
            }
            richTextBox1.Text += $"7. feladat\n\t";
            foreach (var i in orszagok)
            {
                if (i.Value > 1)
                {
                    richTextBox1.Text += $"{i.Key}: {i.Value} versenyzõ\n\t";
                }
            }
            Task7Btn.Enabled = false;
            #endregion
        }

        private void Task8Btn_Click(object sender, EventArgs e)
        {
            #region 8. feladat
            Dictionary<string, double> rendezetlenVegeredmeny = new Dictionary<string, double>();
            foreach (var i in Versenyzok)
            {
                rendezetlenVegeredmeny.Add($"{i.Nev};{i.Orszag}", Task4(i.Nev));
            }
            Dictionary<string, double> rendezettVegeredmeny = rendezetlenVegeredmeny.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            StreamWriter sw = new StreamWriter("vegeredmeny.csv");
            int sorszam = 1;
            foreach (var i in rendezettVegeredmeny)
            {
                sw.WriteLine($"{sorszam};{i.Key};{i.Value}");
                sorszam++;
            }
            sw.Close();
            Task8Btn.Enabled = false;
            #endregion
        }
    }
}
