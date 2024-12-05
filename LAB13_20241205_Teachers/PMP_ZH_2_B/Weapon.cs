namespace PMP_ZH_2
{
    public class Weapon
    {
        private static readonly Random RND = new Random();
        /*
         * Tárolja privát mezőkben a fegyver típusát (WeaponType) és a lőszer mennyiségét (int).
         */
        private WeaponType weaponType;
        private int ammo;

        /*
         * Az osztály rendelkezzen egy kívülről csak olvasható tulajdonsággal a fegyvertípushoz, illetve
         * egy olvasható és írható tulajdonsággal a lőszer mennyiséghez: Ez utóbbi csak pozitív értéket
         * vehessen fel.
         */
        public WeaponType WeaponType
        {
            get => weaponType;
            private set
            {
                weaponType = value;
            }
        }

        public int Ammo
        {
            get => ammo;
            set
            {
                if (value > -1)
                {
                    ammo = value;
                }
            }
        }

        /*
         * A konstruktor kapja paraméterül be a fegyver típusát és a hozzá tartozó lőszermennyiséget,
         * majd állítsa be a mezőket. Mivel az éles helyzetekben McClane nem mindig tudja megállapítani
         * a fegyver adatait, ezért hozzon létre egy paramétermentes konstruktort is, amely fegyver típusát
         * véletlenszerűen állítja be az enum lehetséges értékei alapján, valamint a lőszer mennyiséget is
         * randomizálja a [0,200] intervallumon.
         */
        public Weapon(WeaponType weaponType, int ammo)
        {
            WeaponType = weaponType;
            Ammo = ammo;
        }

        public Weapon()
        {
            WeaponType[] enums = Enum.GetValues<WeaponType>();
            WeaponType = enums[RND.Next(enums.Length)];
            Ammo = RND.Next(0, 201);
        }

        /*
         * A publikus Shoot() metódus a csökkenti a lőszer mennyiségét véletlenszerű [1, X]
         * intervallumon lévő összeggel, ahol X Pistol esetében legfeljebb 10, Rifle esetében legfeljebb 3,
         * MG esetében legfeljebb 50, RPG esetében pontosan 1. (Ha még rendelkezésre áll elég lőszer)
         */
        public void Shoot()
        {
            if (Ammo != 0)
            {
                int max = 0;
                switch (WeaponType)
                {
                    case WeaponType.Pistol: max = 10; break;
                    case WeaponType.Rifle: max = 3; break;
                    case WeaponType.MG: max = 50; break;
                    case WeaponType.RPG: max = 1; break;
                }
                Ammo -= RND.Next(1, Math.Min(max, Ammo) + 1);
            }
        }
    }
}