namespace PMP_II_Starter
{
    /*
     * Készítse el a Director osztályt a következő, kívülről csak olvasható jellemzőkkel:
     *      o Name (szöveg)
     *      o Episodes (Episode objektumokból álló gyűjtemény)
     * Az osztály szabadon bővíthető konstruktorral, metódusokkal, amennyiben szükséges!
     */
    public class Director
    {
        public string Name { get; }
        public Episode[] Episodes { get; private set; }

        public Director(string name, Episode episode)
        {
            Name = name;
            Episodes = new Episode[1];
            Episodes[0] = episode;
        }

        public void AddEpisode(Episode newEpisode)
        {
            Episode[] newEpisodes = new Episode[Episodes.Length + 1];
            for (int i = 0; i < Episodes.Length; i++)
            {
                newEpisodes[i] = Episodes[i];
            }
            newEpisodes[Episodes.Length] = newEpisode;

            Episodes = newEpisodes;
        }
    }
}