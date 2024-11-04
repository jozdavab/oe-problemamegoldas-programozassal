namespace LAB09_20241107_Teachers
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Game game = new Game();
            game.Items.Add(new GameItem(3, 3, GameItem.ItemType.Door));
            game.Items.Add(new GameItem(1, 3, GameItem.ItemType.Medikit));
            game.Items.Add(new GameItem(5, 3, GameItem.ItemType.ToxicWaste));
            game.Items.Add(new GameItem(3, 2, GameItem.ItemType.Wall));
            game.Items.Add(new GameItem(3, 4, GameItem.ItemType.Wall));
            game.Run();
        }
    }
}