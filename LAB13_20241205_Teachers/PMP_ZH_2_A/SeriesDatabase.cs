using System.Globalization;

namespace PMP_II_Starter
{
    public class SeriesDatabase
    {
        private Episode[] episodes;

        /*
         * Készítsen egy olyan publikus double AverageRating tulajdonságot, amely csak olvasható és
         * megadja az összes rész átlagos értékelését két tizedesjegy pontosan!
         */
        public double AverageRating
        {
            get
            {
                double sum = 0;
                foreach (Episode episode in episodes)
                {
                    sum += episode.Rating;
                }
                return Math.Round(sum / episodes.Length, 2);
            }
        }

        /*
         * A gravity.csv fájl egyes sorai (az elsőt kivéve, amely a fejléc) az epizódok jellemzőit tartalmazzák ; -el
         * elválasztva. A SeriesDatabase osztály konstruktorában látja meghívva az alábbi két metódust:
         *      • ReadFile(path): Ennek a törzsében töltse fel a fájl sorai alapján az Episode tömböt.
         *      • DummyData: Amennyiben nem tudja feltölteni, akkor ezt a metódust is használhatja.
         * Csak az egyiket hívja meg a konstruktorból! Értelemszerűen a DummyData használata 0 pontot ér, de
         * legalább tovább tud haladni!
         */
        public SeriesDatabase(string path)
        {
            ReadFile(path);
            Initialize();
        }

        private void DummyData()
        {
            episodes = ExamHelper.GenerateData(); // Segéd, hogyha nem megy
        }

        private void ReadFile(string path)
        {
            string[] lines = File.ReadAllLines(path);
            episodes = new Episode[lines.Length - 1];
            for (int i = 1; i < lines.Length; i++)
            {
                string[] splitted = lines[i].Split(";");
                episodes[i - 1] = new Episode()
                {
                    Ordinal = int.Parse(splitted[0]),
                    Season = int.Parse(splitted[1]),
                    EpisodeNumber = int.Parse(splitted[2]),
                    Title = splitted[3],
                    Rating = double.Parse(splitted[4], CultureInfo.InvariantCulture),
                    Premier = DateTime.Parse(splitted[5]),
                    Director = splitted[6]
                };
            }
        }

        /*
         * Készítsen az osztályban egy visszatérési érték nélküli privát Initialize metódust. A metódusban
         * járja be a belső tömböt és minden epizódnak állítsa be az előbb elkészített EpisodeType
         * tulajdonságát a megfelelő értékre. Ezt a metódust hívja meg az osztály konstruktorának végén!
         */
        private void Initialize()
        {
            for (int i = 0; i < episodes.Length - 1; i++)
            {
                if (episodes[i].EpisodeNumber == 1)
                {
                    episodes[i].EpisodeType = EpisodeType.SeasonOpening;
                }
                else if (episodes[i].Season != episodes[i + 1].Season)
                {
                    episodes[i].EpisodeType = EpisodeType.SeasonFinale;
                }
                else
                {
                    episodes[i].EpisodeType = EpisodeType.Normal;
                }
            }
            episodes[episodes.Length - 1].EpisodeType = EpisodeType.SeasonFinale;
        }

        /*
         * Készítsen egy publikus WorstEpisode metódust, amely visszaadja a legrosszabb értékelésű epizódot!
         */
        public Episode WorstEpisode()
        {
            Episode worst = episodes[0];
            for (int i = 1; i < episodes.Length; i++)
            {
                if (episodes[i].Rating < worst.Rating)
                {
                    worst = episodes[i];
                }
            }
            return worst;
        }

        /*
         * Készítsen egy publikus SeasonData metódust, amely visszaadja tömbként az évad legfontosabb
         * információit az alábbi formátumban:
         */
        public string[] SeasonData()
        {
            string[] data = new string[episodes[episodes.Length - 1].Season];
            int counter = 0;
            for (int i = 0; i < episodes.Length; i++)
            {
                counter++;
                if (episodes[i].EpisodeType == EpisodeType.SeasonFinale)
                {
                    DateTime first = episodes[i - counter + 1].Premier;
                    int airTime = (episodes[i].Premier - first).Days;
                    data[episodes[i].Season - 1] = $"{episodes[i].Season}. évad : {counter} rész. Vetítve: {airTime} napig.";
                    counter = 0;
                }
            }

            return data;
        }

        /*
         * Az előző metódus által visszaadott tömböt lehessen kiírni a megadott fájlba a publikus
         * Save(fileName, data) metódus segítségével! Amennyiben létezik már ilyen nevű fájl, ne történjen
         * meg a mentés, ezt pedig a visszatérési érték segítségével jelezzük!
         */
        public bool Save(string filename, string[] data)
        {
            if (!File.Exists(filename))
            {
                StreamWriter sw = new StreamWriter(filename);
                for (int i = 0; i < data.Length; i++)
                {
                    sw.WriteLine(data[i]);
                }
                sw.Close();
                return true;
            }
            return false;
        }

        /*
         * Készítsen egy publikus DirectorDetails metódust, amely visszatér a rendezők tömbjével. Egy
         * rendező csak egyszer szerepeljen a tömbben. A rendező által rendezett részek ismétlődés és null
         * elemektől mentesen szerepeljenek a Rendező belső gyűjteményében.
         */
        public Director[] DirectorDetails()
        {
            Director[] tmp = new Director[episodes.Length];
            int counter = 0;
            for (int i = 0; i < episodes.Length; i++)
            {
                string[] names = episodes[i].Director.Split(",");
                for (int j = 0; j < names.Length; j++)
                {
                    int idx = GetIdx(tmp, names[j]);
                    if (idx == -1)
                    {
                        tmp[counter++] = new Director(names[j], episodes[i]);
                    }
                    else
                    {
                        tmp[idx].AddEpisode(episodes[i]);
                    }
                }
            }
            Director[] directors = new Director[counter];
            for (int i = 0; i < counter; i++)
            {
                directors[i] = tmp[i];
            }

            return directors;
        }

        /*
         * Hozza létre a publikus GravityDays metódust, amely visszatér a legelső és legutolsó rész között
         * eltelt napok számával!
         */
        public int GravityDays()
        {
            return (int)(episodes[episodes.Length - 1].Premier - episodes[0].Premier).TotalDays;
        }

        private int GetIdx(Director[] directors, string name)
        {
            for (int i = 0; i < directors.Length; i++)
            {
                if (directors[i] != null && directors[i].Name == name)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}