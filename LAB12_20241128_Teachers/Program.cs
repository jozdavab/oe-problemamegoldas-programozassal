namespace LAB12_20241128_Teachers
{
    public class Program
    {
        /*
         * Készítsen egy egyszerű menürendszerrel működő felhasználói felületet az alábbiak szerint. Az
         * egyes funkciók eléréséhez a felhasználónak a megfelelő sorszámot kell megadnia.
         *      1. Load data file
         *      2. Get average monthly revenue
         *      3. List non-paying users
         *      4. Show distribution of devices
         *      5. Exit
         * 
         *      Your choice: _
         *      
         *      • Az első menüpont választásakor a felhasználónak meg kell adni a bemeneti fájl nevét, amely
         * alapján a program létrehoz egy Dataset példányt, és betölti a megfelelő adatokat.
         *      • A második menüpont választásakor a felhasználónak meg kell adni egy előfizetés típust, a
         * program pedig kiírja az ilyen típusú előfizetések átlagos előfizetési díját.
         *      • A harmadik menüpont választásakor a felhasználónak meg kell adni egy egész értéket, a program
         * pedig listázza a nem fizető felhasználók adatait (használja a DataAsText metódust).
         *      • A negyedik menüpont választásakor a felhasználónak meg kell adni egy eszköztípust, a program
         * pedig az eszköz országok közötti megoszlását írja ki.
         *      • Az ötödik menüpont választásakor a program véget ér.
         *      
         * Nem létező menüpont választásakor jelezze a hibát a felhasználónak. A választott lekérdezés végén
         * várjon billentyűleütésre, majd törölje a képernyőt, és mutassa újra a menüt.
         */
        private static void Main(string[] args)
        {
            Dataset dataset = null;

            bool shouldContinue;
            do
            {
                ShowMenu();
                shouldContinue = ProcessInput(Console.ReadKey().KeyChar, ref dataset);
                Console.ReadKey();
            } while (shouldContinue);
        }

        private static void ShowMenu()
        {
            Console.Clear();
            Console.Write(
                "1. Load data file\n" +
                "2. Get average monthly revenue\n" +
                "3. List non-paying users\n" +
                "4. Show distribution of devices\n" +
                "5. Exit\n\n" +
                "Your choice: ");
        }

        private static bool ProcessInput(char input, ref Dataset dataset)
        {
            switch (input)
            {
                case '1': dataset = Option1(); break;
                case '2': Option2(dataset); break;
                case '3': Option3(dataset); break;
                case '4': Option4(dataset); break;
                case '5': return false;
                default: Console.WriteLine("\nNincs ilyen menüpont"); break;
            }

            return true;
        }

        private static Dataset Option1()
        {
            Console.Write("\nAdja meg a bemeneti fájl nevét: ");
            return new Dataset("..\\..\\..\\" + Console.ReadLine());
        }

        private static void Option2(Dataset dataset)
        {
            if (dataset != null)
            {
                Console.Write("\nAdja meg az előfizetés típusát (Basic, Premium, Standard): ");
                SubscriptionType sub = Enum.Parse<SubscriptionType>(Console.ReadLine());
                Console.WriteLine($"\nEzen típusú előfizetések átlagos díja: {dataset.AverageMonthlyRevenue(sub)}");
            }
        }

        private static void Option3(Dataset dataset)
        {
            if (dataset != null)
            {
                Console.Write("\nAdjon meg egy egész értéket: ");
                int days = int.Parse(Console.ReadLine());
                Console.WriteLine("\nNem fizető felhasználók adatai:");
                User[] debtors = dataset.CollectNonPayers(days);
                foreach (User debtor in debtors)
                {
                    Console.WriteLine(debtor.DataAsText());
                }
            }
        }

        private static void Option4(Dataset dataset)
        {
            if (dataset != null)
            {
                Console.Write("\nAdja meg az eszköztípust (Laptop, SmartTV, Smartphone, Tablet): ");
                DeviceType device = Enum.Parse<DeviceType>(Console.ReadLine());
                Console.WriteLine($"\n{dataset.DistributionOfDeviceType(device)}");
            }
        }
    }

    /*
     * Hozza létre az alábbi felsorolt típusokat (enumokat).
     */
    public enum CountryName { Australia = 1, Brazil, Canada, France, Germany, Italy, Mexico, Spain, UnitedKingdom, UnitedStates }
    public enum SubscriptionType { Basic, Premium, Standard }
    public enum DeviceType { Laptop, SmartTV, Smartphone, Tablet }
}