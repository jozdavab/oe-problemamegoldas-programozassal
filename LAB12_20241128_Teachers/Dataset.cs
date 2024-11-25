using System.Text;

namespace LAB12_20241128_Teachers
{
    /*
     * Dataset osztály: a felhasználói adatok tárolását és lekérdezések futtatását végző osztály.
     */
    public class Dataset
    {
        /*
         * Tárolja a felhasználókat egy tömb vagy lista típusú privát mezőben. 
         */
        List<User> users;

        /*
         * Az osztály konstruktora egy fájl nevét várja paraméterként. A fájl egyes sorai (az elsőt kivéve,
         * amely a fejléc) az előző részfeladatban megadott formátumú sorokat tartalmaznak, mindegyik
         * sor egy-egy felhasználó adatait. Töltse be és dolgozza fel a fájlt, a benne lévő adatok alapján
         * készítse el a felhasználókat reprezentáló példányokat, amelyeket helyezzen el az előbbi tömbben
         * vagy listában
         */
        public Dataset(string path)
        {
            users = new List<User>();
            using (StreamReader sr = new StreamReader(path))
            {
                sr.ReadLine(); // Fejléc mellőzése
                while (!sr.EndOfStream)
                {
                    users.Add(new User(sr.ReadLine()));
                }
            }
        }

        /*
         * Készítsen egy csak lekérdezhető publikus tulajdonságot, amely visszaadja az adathalmazban
         * lévő felhasználók darabszámát. 
         */
        public int UserCount
        {
            get
            {
                return users.Count;
            }
        }

        /*
         * Készítsen egy AverageMonthlyRevenue nevű metódust, amely paraméterként egy előfizetési
         * típust vár, majd visszaadja az ilyen típusú előfizetések átlagos előfizetési díját.
         */
        public double AverageMonthlyRevenue(SubscriptionType sub)
        {
            int sum = 0, counter = 0;
            foreach (User user in users)
            {
                if (user.Subscription == sub)
                {
                    sum += user.Fee;
                    counter++;
                }
            }
            return counter > 0 ? sum / counter : 0;
        }

        /*
         * Készítsen egy CollectNonPayers nevű metódust, amely paraméterként egy egész számot vár,
         * majd egy tömbbe gyűjti azokat a felhasználó példányokat, akiknek legalább a megadott számú
         * nap telt el az utolsó díjfizetése óta. A visszaadott tömb pontosan olyan méretű legyen, amennyi
         * a benne szereplő felhasználók száma (vagyis ne tartalmazzon üres elemeket). 
         */
        public User[] CollectNonPayers(int days)
        {
            int counter = 0;
            foreach (User user in users)
            {
                if (user.DaysSinceLastPayment() >= days)
                {
                    counter++;
                }
            }
            User[] debtors = new User[counter];
            foreach (User user in users)
            {
                debtors[--counter] = user;
            }
            return debtors;
        }

        /*
         * Készítsen egy MaximalAgeData nevű metódust, amely a legidősebb felhasználó adataival
         * (karakterlánc) tér vissza. Ha több maximális életkorú felhasználó van az adathalmazban,
         * válassza a legelső ilyet. 
         */
        public string MaximalAgeData()
        {
            int maxi = 0;
            for (int i = 1; i < users.Count; i++)
            {
                if (users[i].Age > users[maxi].Age)
                {
                    maxi = i;
                }
            }
            return users[maxi] != null ? users[maxi].DataAsText() : "";
        }

        /*
         * Készítsen egy DistributionOfDeviceType nevű metódust, amely meghatározza a paraméterként
         * átadott eszköztípussal rendelkező előfizetők országok szerinti részarányát (megoszlását). A
         * visszatérési érték egyetlen, az alábbival egyező formátumú karakterlánc legyen. 
         *      -- Distribution of Smartphone --
         *      Australia: 8.86%
         *      Brazil: 8.86%
         *      Canada: 12.88%
         *      ...
         *      UnitedStates: 15.94%
         */
        public string DistributionOfDeviceType(DeviceType device)
        {
            int[] counts = new int[Enum.GetNames<CountryName>().Length];
            foreach (User user in users)
            {
                if (user.Device == device)
                {
                    counts[(int)user.Country - 1]++;
                }
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"-- Distribution of {device} --");
            for (int i = 0; i < counts.Length; i++)
            {
                double perc = Math.Round(100d * counts[i] / users.Count, 2);
                sb.AppendLine($"{(CountryName)i + 1}:{perc}%");
            }

            return sb.ToString();
        }
    }
}