namespace PMP_ZH_2
{
    public class Terrorist
    {
        private static readonly Random RND = new Random();
        /*
         * Tárolja privát mezőkben a terrorista nevét (string), állapotát (int - a személy élete százalékban
         * megadva), emeletét (int - a terrorista jelenlegi pozíciója), és felszerelését (Equipment).
         */
        private string name;
        private int hitPoints;
        private int floor;
        private Equipment equipment;

        /*
         * A név és felszerelés mezőkhöz hozzon létre csak olvasható tulajdonságokat, az emelet és
         * állapot mezőkhöz pedig olvasható és írható tulajdonságokat. Az emelet csak [0,35]
         * intervallumon kaphat értékeket, az állapot értéke pedig csak akkor módosulhat, ha a személy
         * az addigihoz képest rosszabb állapotba kerül (sérül), de nulla alá ekkor sem csökkenhet (ebben
         * az esetben a 0 értéket veszi fel)
         */
        public string Name
        {
            get => name;
            private set
            {
                name = value;
            }
        }
        public Equipment Equipment
        {
            get => equipment;
            private set
            {
                equipment = value;
            }
        }

        public int Floor
        {
            get => floor;
            set
            {
                if (value > -1 && value < 36)
                {
                    floor = value;
                }
            }
        }

        public int HitPoints
        {
            get => hitPoints;
            set
            {
                if (value < hitPoints)
                {
                    hitPoints = value > -1 ? value : 0;
                }
            }
        }

        /*
         * Az osztálynak legyen egyparaméteres, szöveget váró konstruktora amely képes feldolgozni az alábbi fájl formátumú sorokat
         * A sor a terrorista nevét, egészségi állapotát, azt az emeletet, ahol épp tartózkodik, a nála lévő n 
         * darab fegyver típusát, majd ezek után rendre n darab lőszermennyiséget tartalmazza.
         */
        public Terrorist(string line)
        {
            string[] parts = line.Split(';');
            Name = parts[0];
            string[] subPart = parts[1].Split('@');
            hitPoints = int.Parse(subPart[0]);
            Floor = int.Parse(subPart[1]);
            equipment = new Equipment();
            equipment.ProcessData(parts[2].Split(','), parts[3].Split(','));
        }

        /*
         * A privát Flee() metódus által az adott személy a jelenlegi emeletéről véletlenszerűen elmenekül fel
         * vagy lefelé legfeljebb X emeletet, ahol X = 10 mínusz a felhasználó felszerelésének kg ban mért
         * súlya, de legalább egy. Egy terrorista csak akkor menekül, ha még életben van. 
         */
        private void Flee()
        {
            if (HitPoints > 0)
            {
                int range = 10 - (int)(equipment.GetSumWeight() / 1000);
                if (range < 1) range = 1;

                Floor = RND.Next(-range, range + 1);
            }
        }

        /*
         * A Fight() metódus által, ha a személy még él, akkor egy véletlenszerűen választott nem üres
         * fegyverrel lő, ezután az élete véletlen [0-100] százalékos értékkel csökken, majd 50% os esélyel
         * menekül a Flee() metódus segítségével.
         */
        public void Fight()
        {
            Weapon[] weapons = Equipment.NonEmptyWeapons();
            if (weapons.Length > 0)
            {
                Weapon selectedWeapon = weapons[RND.Next(weapons.Length)];
                selectedWeapon.Shoot();
                HitPoints -= RND.Next(101);
                if (RND.Next(0, 2) == 0)
                {
                    this.Flee();
                }
            }
        }
    }
}