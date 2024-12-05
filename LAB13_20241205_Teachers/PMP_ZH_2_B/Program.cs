namespace PMP_ZH_2
{
    /*
     * Die Hard. John McClane hadnagy Los Angelesbe érkezik karácsonykor, hogy találkozzon feleségével
     * a Nakatomi Plaza irodaházban. Váratlanul a német Hans Gruber vezetésével egy terroristacsoport
     * szállja meg az épületet és túszul ejtik a vendégeket. A helyzet eszkalálódása miatt az FBI is
     * bekapcsolódik a túszdrámába. Az Ön feladata az FBI számára elkészíteni egy alkalmazást, amely a
     * McClane-től kapott szöveges fájlban lévő adatokat dolgozza fel.
     */
    public class Program
    {
        /*
         * Tesztelje a programot a Main-ben! Az alkalmazás olvassa be a diehard.txt ből a McClane által
         * küldött adatokat, majd azokat feldolgozva töltsön fel elemekkel egy terrorists gyűjteményt. Ezután
         * minden terrorista keveredjen harcba egyszer, végül jelenítse meg mindegyikük nevét, állapotát és
         * felszerelésük össztömegét a konzolon. 
         */
        private static void Main(string[] args)
        {
            List<Terrorist> badGuys = new List<Terrorist>();
            StreamReader sr = new StreamReader("../../../diehard.txt");
            while (!sr.EndOfStream)
            {
                badGuys.Add(new Terrorist(sr.ReadLine()));
            }
            sr.Close();

            foreach (Terrorist t in badGuys)
            {
                t.Fight();
                Console.WriteLine($"{t.Name} : {t.HitPoints}/100 HP, {t.Equipment.GetSumWeight()} g súly");
            }
        }
    }
}