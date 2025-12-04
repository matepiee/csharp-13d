namespace Helsinki
{
    public partial class Form1 : Form
    {
        private static List<Versenyzo> Versenyzok = new List<Versenyzo>();
        private static List<Versenyzo> Dontosok = new List<Versenyzo>();
        public Form1()
        {
            InitializeComponent();
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
                    } catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Hiba a versenyzõ hozzáadása során.");
                    }
                }
                MessageBox.Show($"Sikeres olvasás: {filePath}");
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
    }
}
