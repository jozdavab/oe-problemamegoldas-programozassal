namespace LAB08_20241031_Teachers
{
    public class Program
    {
        private static void Main(string[] args)
        {
            #region 1.feladat

            /*
             * Egy futsal csapatban egy kapus, és négy mezőnyjátékos (egy csatár, két szélső és egy védő) van. A feladatunk,
             * hogy egy olyan programot készítsünk, amely segítségével az elérhető játékosokból helyes felépítésű csapatot
             * állíthatunk elő. Minden játékosról ismert a neve és a pozíciója, amely a fent felsorolt értékek egyike lehet.
             * Egy csapatba pontosan 5 játékos kell, a fentebb definiált módon. A program indításkor generáljon játékosokat,
             * és a felhasználónak legyen lehetősége csapathoz rendelni őket. Készítsük el a játékosokat reprezetáló Player
             * osztályt az alábbi tagokkal.
             *      • string name: a játékos neve
             *      • Position pos: a játékos pozíciója (Goalkeeper, Forward, Winger, Defender)
             * Az adattagok beállítása a konstruktoron keresztül lehetséges. Definiáljuk felül az osztály ToString metódusát,
             * amely a játékos nevét és pozícióját tartalmazó karakterláncot adja vissza.
             * A csapatot a Team osztály reprezentálja. Valósítsuk meg az alábbi tagokat az osztályban.
             *      • Player[ ] players: a csapatban levő játékosok tömbje
             *      • int NumberOfPlayers: a csapatban levő játékosok száma
             *      • bool IsFull: a játékosok száma elérte az ötöt?
             *      • bool IsIncluded(Player): eldönti, hogy a parameter szerepel-e már a csapatban
             *      • bool IsAvailable(Player): eldönti, hogy a parameter pozíciója szabad-e
             *      • void Include(Player): játékos hozzáadása a csapathoz
             * A főprogramban készítsük el az alábbi statikus metódust.
             *      • Player[] RandomPlayers(int): adott mennyiségű játékos generálása
             * A Main-ben a véletlenszerűen generált játékosok közül választhat a felhasználó, és a csapatba rendelheti őket.
             */

            Console.Write("Add meg hány játékost akarsz generálni:\t");
            Player[] bench = RandomPlayers(int.Parse(Console.ReadLine()));

            Team team = new Team();
            do
            {
                Console.Clear();
                Console.WriteLine("Választható játékosok:");
                foreach (Player player in bench)
                {
                    if (player != null)
                    {
                        Console.Write(player + ",");
                    }
                }
                Console.Write("\nAdd meg a választott játékos nevét:");
                string choosenOne = Console.ReadLine();
                for (int i = 0; i < bench.Length; i++)
                {
                    if (bench[i] != null && bench[i].Name == choosenOne)
                    {
                        if (!team.IsIncluded(bench[i]))
                        {
                            if (team.IsAvailable(bench[i]))
                            {
                                team.Include(bench[i]);
                                bench[i] = null;
                                Console.WriteLine($"{choosenOne} játékos felvéve a csapatba!");
                            }
                            else
                            {
                                Console.WriteLine($"A {bench[i].Pos} szerepkör már betöltött a csapatban");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{choosenOne} már a csapat része!");
                        }

                        break;
                    }
                }
                Console.ReadKey();
            } while (!team.IsFull); // Megjegyzés: Figyelni kéne azt is, hogy playersben maradt-e elég megfelelő pozíciójú játékos a csapat feltöltésére.

            #endregion

            #region 2.feladat

            /* 
             * Készítsünk bölényvadász játékot. A bölénycsorda N bölényből áll, amelyek egy M × M -es játéktéren a bal
             * felső sarokból, a (0, 0) koordinátáról indulnak, és a játéktér jobb alsó sarkának irányába haladnak. Az N és M
             * értékeket a felhasználó adhatja meg a játék kezdetén. A játék körökre osztott. Minden körben minden bölény 
             * véletlenszerűen lép egyet jobbra (x + 1), lefelé (y + 1) vagy átlósan jobbra lefelé (x + 1, y + 1), de mindig a
             * pálya határain belül maradva. A felhasználó minden körben lövést ad le egy kiválasztott koordinátára, így 
             * eltalálva az ott lévő bölények mindegyikét. Ha eltalált egy bölényt, az kiesett a játékból. A bölények akkor 
             * győznek, ha bármelyik elér a célba, a felhasználó pedig akkor, ha sikerül minden bölényt kiiktatnia, mielőtt 
             * bármelyik a célba érne. 
             * A játékteret a Field osztály reprezentálja.
             *      • Tároljuk el a játéktér méretét (M ) egy mezőben.
             *      • A mező értékét a konstruktorban állítsuk be a paraméterként átadott értéknek megfelelően.
             *      • Készítsünk egy TargetX és egy TargetY tulajdonságot, amelyek lekérdezésekor a játéktér cél koordinátáit
             *        (a pálya jobb alsó sarkának koordinátáit) kapjuk vissza.
             *      • Definiáljunk egy AllowedPosition nevű metódust, amelynek két egész értéket fogad paraméterül, majd
             *        visszaadja, hogy az ezek által leírt koordinánta a játéktér része-e. (Vagyis ha ide lépne egy bölény, akkor
             *        még a játéktéren belül maradna-e.)
             *      • A Show() nevű metódus meghívásakor rajzoljuk ki a játéktér körvonalát a képernyőre (például | és -
             *        karakterek segítségével).
             * Készítsük el a Buffalo osztályt a bölények reprezentálására.
             *      • Tároljuk el a bölény aktuális pozícióját (x és y koordinátáit) egy-egy változóban. A bölény állapotát
             *        (aktív/nem aktív) egy logikai típusú mezőben tároljuk.
             *      • Készítsünk egy X és egy Y tulajdonságot, amelyek lekérdezésekor a bölény aktuális koordinátáit kapjuk
             *        vissza.
             *      • A Move metódus egyetlen paramétere egy Field típusú példány. A metódus meghívásakor valósítsuk meg
             *        a bölény egy lépését a fenti szabályok szerint, de csak olyan mezőre léphet, amelyre a paraméterként kapott
             *        példány AllowedPosition igaz értékkel tér vissza.
             *      • A Deactivate metódus meghívásakor a bölény állapota nem aktív (hamis) értéket vesz fel.
             *      • A Show metódus hívásakor a bölény korrdinátájának megfelelő helyre írjunk ki egy B karaktert zöld színnel,
             *        ha a bölény aktív, vagy piros színnel, ha nem aktív.
             * Készítsük el a Game osztályt az alábbi tagokkal.
             *      • Legyen egy Field típusú mezője, amely a játékteret leíró példányt tárolja. A bölényeket tároljuk egy
             *        tömbben vagy listában.
             *      • Az IsOver tulajdonság a játék aktuális állapotát adja meg: igaz értékkel tér vissza, ha a játék véget ért,
             *        és hamis értékkel, ha még folyamatban van (lásd a fenti szabályokat).
             *      • A konstruktor a játéktér méretét és a bölények számát várja paraméterül, majd ezeknek megfelelően létre-
             *        hozza a játékteret és a szükséges számú bölényt.
             *      • A privát VisualizeElements metódus törli a képernyőt, majd kirajzolja a játékteret és a bölényeket a
             *        képernyőre a Show metódusok meghívásával.
             *      • A privát Shoot metódus egy x és egy y koordinátát kér a felhasználótól, majd minden olyan bölényt
             *        deaktivál a megfelelő metódus meghívásával, amely a felhasználó által megadott pozícióban tartózkodik.
             *      • A Run metódus meghívásakor rajzoljuk ki a játék állapotát a VisualizeElements meghívásával, majd hívjuk
             *        meg a Shoot metódust. Ismételjük ezeket a lépéseket az IsOver aktuális értékétől függően.
             * A főprogramban készítsünk egy példányt a Game osztályból, majd a Run metódus hívásával indítsuk el a játékot.
             */

            int fieldSize = Math.Min(Console.WindowWidth, Console.WindowHeight) / 2;
            int buffCnt = Math.Max(fieldSize / 10, 3);
            Game game = new Game(fieldSize, 10);
            game.Run();

            #endregion
        }

        #region 1.feladat

        static Player[] RandomPlayers(int playerCount)
        {
            Random rnd = new Random();
            Player[] players = new Player[rnd.Next(playerCount)];
            for (int i = 0; i < players.Length; i++)
            {
                string name = $"player{i + 1}";         // Számozás egyszerű, de akár neveket is randomizálhatnánk...
                Position pos = (Position)(i % 4);       // Megjegyzés : Akár randomizálhatnánk is
                players[i] = new Player(name, pos);
            }
            return players;
        }

        #endregion
    }

    #region 1.feladat

    public enum Position
    {
        Goalkeeper, Forward, Winger, Defender
    }

    public class Player
    {
        public string Name { get; }
        public Position Pos { get; }

        public Player(string name, Position pos)
        {
            Name = name;
            Pos = pos;
        }

        public override string ToString()
        {
            return Name + " " + Pos;
        }
    }

    public class Team
    {
        private Player[] players;

        public int NumberOfPlayers
        {
            get
            {
                int counter = 0;
                foreach (Player player in players)
                {
                    if (player != null)
                    {
                        counter++;
                    }
                }
                return counter;
            }
        }

        public bool IsFull { get => NumberOfPlayers == 5; }

        public Team()
        {
            players = new Player[5];
        }

        public bool IsIncluded(Player targetPlayer)
        {
            foreach (Player player in players)
            {
                if (player == targetPlayer)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsAvailable(Player targetPlayer)
        {
            int availablePos;
            switch (targetPlayer.Pos)
            {
                case Position.Winger: availablePos = 2; break;
                case Position.Goalkeeper:                       // Nincs break, ezért switch falltrough!
                case Position.Forward:
                case Position.Defender:
                default: availablePos = 1; break;
            }
            foreach (Player player in players)
            {
                if (player != null && player.Pos == targetPlayer.Pos)
                {
                    if (--availablePos == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void Include(Player targetPlayer)
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i] == null)
                {
                    players[i] = targetPlayer;
                    return;
                }
            }
        }
    }

    #endregion

    #region 2.feladat

    public class Field
    {
        private int size;

        public int TargetX { get => size; }
        public int TargetY { get => size; }

        public Field(int size)
        {
            this.size = size;
        }

        public bool AllowedPosition(int x, int y)
        {
            return (x >= 0 && y >= 0 && x < TargetX && y < TargetY);
        }

        public void Show()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("");
            }
            Console.ResetColor();
        }
    }

    public class Buffallo
    {
        static Random rnd = new Random();
        private int x;
        private int y;
        private bool state;

        public int X { get => x; }
        public int Y { get => y; }
        public bool State { get => state; }

        public Buffallo()
        {
            x = y = 1;
            state = true;
        }

        public void Move(Field field)
        {
            if (State)
            {
                int nextX, nextY;
                do
                {
                    switch (rnd.Next(3))
                    {
                        case 0: nextX = X + 1; nextY = Y; break;
                        case 1: nextX = X; nextY = Y + 1; break;
                        default: nextX = X + 1; nextY = Y + 1; break;
                    }
                } while (!field.AllowedPosition(nextX, nextY));
                x = nextX; y = nextY;
            }
        }

        public void Deactivate()
        {
            state = false;
        }

        public void Show()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = State ? ConsoleColor.Black : ConsoleColor.Red; // Inline if. https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator
            Console.SetCursorPosition(X, Y);
            Console.Write("B");
            Console.ResetColor();
        }
    }

    public class Game
    {
        Field field;
        List<Buffallo> herd;

        public bool IsOver
        {
            get
            {
                bool buffsAlive = false;
                foreach (Buffallo buff in herd)
                {
                    if (buff.State)
                    {
                        if (buff.X == field.TargetX && buff.Y == field.TargetY)
                        {
                            return true;
                        }
                        buffsAlive = true;
                    }

                }
                return buffsAlive;
            }
        }

        public Game(int fieldSize, int buffCnt)
        {
            field = new Field(fieldSize);
            herd = new List<Buffallo>();
            for (int i = 0; i < buffCnt; i++)
            {
                herd.Add(new Buffallo());
            }
        }

        private void VisualiseElements()
        {
            Console.Clear();
            field.Show();
            foreach (Buffallo buff in herd)
            {
                buff.Show();
            }
        }

        private void Shoot()
        {
            Console.Write("X koordináta lövéshez:\t");
            int targetX = int.Parse(Console.ReadLine());
            Console.Write("Y koordináta lövéshez:\t");
            int targetY = int.Parse(Console.ReadLine());

            foreach (Buffallo buff in herd)
            {
                if (buff.X == targetX && buff.Y == targetY)
                {
                    buff.Deactivate();
                }
            }
        }

        public void Run()
        {
            do
            {
                foreach (Buffallo buff in herd)
                {
                    buff.Move(field);
                }
                VisualiseElements();
                Console.SetCursorPosition(0, field.TargetY + 3);
                Shoot();
            } while (IsOver);
        }
    }

    #endregion
}