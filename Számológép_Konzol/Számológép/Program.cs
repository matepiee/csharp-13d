namespace Számológép
{
    internal class Program
    {
        #region Összeadás
        static int Addition(int num1, int num2)
        {
            int intResult = num1 + num2;
            return intResult;
        }
        #endregion

        static void Main(string[] args)
        {
            #region Adatbekérés
            Console.WriteLine("Üdvözöllek a számológépben!\n");
            string asd = "12345+1245";
            asd.Trim();
            Console.WriteLine();
            #endregion

            Console.ReadKey();
        }
    }
}
