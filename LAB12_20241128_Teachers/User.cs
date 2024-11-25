namespace LAB12_20241128_Teachers
{
    /*
     * User osztály: egy felhasználót reprezentál, és az alábbi tagokkal rendelkezik.
     */
    public class User
    {
        /*
         * Tárolja a felhasználó azonosítószámát (int), előfizetésének típusát (SubscriptionType),
         * előfizetési díját (int), a csatlakozás és a legutóbbi díjfizetés dátuma (egy-egy DateTime), a
         * felhasználó országát (CountryName), életkorát (int) és eszközének típusát (DeviceType)
         * egy-egy privát mezőben.
         */

        private int id;
        private SubscriptionType subscription;
        private int fee;
        private DateTime joined;
        private DateTime lastPayment;
        private CountryName country;
        private int age;
        private DeviceType device;

        /*
         * Minden mezőhöz készítsen egy-egy csak lekérdezhető tulajdonságot. 
         */

        public int Id { get => id; }
        public SubscriptionType Subscription { get => subscription; }
        public int Fee { get => fee; }
        public DateTime Joined { get => joined; }
        public DateTime LastPayment { get => lastPayment; }
        public CountryName Country { get => country; }
        public int Age { get => age; }
        public DeviceType Device { get => device; }

        /*
         * Az osztály rendelkezzen egy konstruktorral, amely egyetlen paraméterként az alábbival egyező
         * formátumú karakterláncot vár.
         * 1528,Standard,12,2022-09-10,2023-07-07,UnitedKingdom,45,SmartTV
         * A karakterlánc a felhasználó adatait tartalmazza vesszővel elválasztva abban a sorrendben,
         * ahogyan az előző részfeladatban szerepelt. A konstruktor dolgozza fel a karakterláncot, és
         * végezze el a mezők értékadását. 
         */

        public User(string line)
        {
            string[] splitted = line.Split(',');
            id = int.Parse(splitted[0]);
            subscription = Enum.Parse<SubscriptionType>(splitted[1]);
            fee = int.Parse(splitted[2]);
            joined = DateTime.Parse(splitted[3]);
            lastPayment = DateTime.Parse(splitted[4]);
            country = Enum.Parse<CountryName>(splitted[5]);
            age = int.Parse(splitted[6]);
            device = Enum.Parse<DeviceType>(splitted[7]);
        }

        /*
         * Rendelkezzen egy SubscriptionInDays nevű publikus metódussal, amely kiszámítja és visszaadja,
         * hogy a felhasználó előfizetése hány napja aktív (a mai nap és a csatlakozás dátumának különbsége).
         */

        public int SubscriptionInDays()
        {
            return DateTime.Now.Subtract(joined).Days;
        }

        /*
         * Rendelkezzen egy DaysSinceLastPayment nevű publikus metódussal, amely kiszámítja és
         * visszaadja, hogy a felhasználó hány napja rendezte utoljára az előfizetési díját. 
         */

        public int DaysSinceLastPayment()
        {
            return DateTime.Now.Subtract(lastPayment).Days;
        }

        /*
         * Rendelkezzen egy DataAsText nevű publikus metódussal, amely a felhasználó adatait adja vissza
         * az alábbi formátum szerint.
         * User ID: 1528 (UnitedKingdom, Standard, SmartTV). Subscription: 489 days, last payment: 189 days.
         * A szöveg a felhasználó azonosítóját, országát, előfizetési csomgaját, készülékét, illetve az
         * előfizetés kezdete és az utolsó díjfizetés óta eltelt napok számát tartalmazza.
         */

        public string DataAsText()
        {
            return $"User ID: {Id} ({Country}, {Subscription}, {Device}). Subscription: {SubscriptionInDays()} days, last payment: {DaysSinceLastPayment()} days.";
        }
    }
}