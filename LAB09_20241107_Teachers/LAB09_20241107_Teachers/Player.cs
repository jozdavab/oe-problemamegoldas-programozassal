namespace LAB09_20241107_Teachers
{
    public class Player
    {
        public Position Position { get; set; }
        public ConsoleSprite Sprite { get; private set; }
        public double FillingRatio { get; private set; }

        public Player(int x, int y)
        {
            Position = new Position(x, y);
            Sprite = new ConsoleSprite(ConsoleColor.Black, ConsoleColor.Green, 'O');
            FillingRatio = 0.5;
        }
    }
}