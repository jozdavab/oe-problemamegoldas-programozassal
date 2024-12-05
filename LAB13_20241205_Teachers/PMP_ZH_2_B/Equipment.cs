namespace PMP_ZH_2
{
    public class Equipment
    {
        /*
         * Tárolja a felszereléseket egy belső privát Weapon tömbben, amelyhez egy csak olvasható
         * publikus tulajdonság is tartozik
         */
        Weapon[] weapons;

        public Weapon[] Weapons
        {
            get => weapons;
            private set
            {
                weapons = value;
            }
        }

        /*
         * A privát AddWeapon(Weapon) metódus a paraméterül kapott fegyvert elhelyezi a tömb első üres helyén.
         */
        int idx = 0;    // Ezt a mezőkhöz kéne alapesetben rakni.
        private void AddWeapon(Weapon weapon)
        {
            Weapons[idx++] = weapon;
        }

        /*
         * A publikus ProcessData(string[], string[]) metódus a paraméterben megadott két tömb
         * (fegyvertípusok, lőszermennyiségek) alapján hozza létre és töltse fel a belső Weapon tömbböt.
         */
        public void ProcessData(string[] types, string[] ammos)
        {
            Weapons = new Weapon[types.Length];
            for (int i = 0; i < Weapons.Length; i++)
            {
                WeaponType type = Enum.Parse<WeaponType>(types[i]);
                int ammo = int.Parse(ammos[i]);
                this.AddWeapon(new Weapon(type, ammo));
            }
        }

        /* 
         * A publikus NonEmptyWeapons() metódus visszaadja azon fegyverek tömbjét, amelyekben még
         * van lőszer. A tömb null elemektől mentes legyen. 
         */
        public Weapon[] NonEmptyWeapons()
        {
            int counter = 0;
            foreach (Weapon weapon in Weapons)
            {
                if (weapon != null && weapon.Ammo > 0)
                {
                    counter++;
                }
            }
            Weapon[] usableWeapons = new Weapon[counter];
            foreach (Weapon weapon in Weapons)
            {
                if (weapon != null && weapon.Ammo > 0)
                {
                    usableWeapons[--counter] = weapon;
                }
            }
            return usableWeapons;
        }

        /*
         * A publikus GetSumWeight() metódus adja vissza a felszerelés teljes tömegét grammban. A
         * fegyverek alapsúlya a típusuktól függ (enum értéke, kg-ban értelmezve), ezen felül minden
         * egyes bennük található lőszer tömege 10 gramm, kivéve RPG-nél, ahol a lőszerek tömege 500 gramm.        
         */
        public double GetSumWeight()
        {
            double sum = 0;
            foreach (Weapon weapon in Weapons)
            {
                if (weapon != null)
                {
                    sum += (int)weapon.WeaponType * 1000;
                    int ammoWeight = weapon.WeaponType == WeaponType.RPG ? 500 : 10;
                    sum += weapon.Ammo * ammoWeight;
                }
            }
            return sum;
        }
    }
}