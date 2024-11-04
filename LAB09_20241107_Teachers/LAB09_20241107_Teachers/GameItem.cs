namespace LAB09_20241107_Teachers
{
    public class GameItem
    {
        public enum ItemType { Ammo, BFGCell, Door, LevelExit, Medikit, ToxicWaste, Wall }
        public Position Position { get; private set; }
        public ConsoleSprite Sprite { get; private set; }
        public ItemType Type { get; private set; }
        public double FillingRatio { get; private set; }
        public bool Available { get; private set; }

        public GameItem(int x, int y, ItemType type)
        {
            Position = new Position(x, y);
            Type = type;
            Available = true;
            SetInitialProperties();
        }

        public void Interact()
        {
            switch (Type)
            {
                case ItemType.Door:
                    if (FillingRatio == 0)
                    {
                        FillingRatio = 1;
                        Sprite = new ConsoleSprite(ConsoleColor.DarkGray, ConsoleColor.Yellow, '/');
                    }
                    else if (FillingRatio == 1)
                    {
                        FillingRatio = 0;
                        Sprite = new ConsoleSprite(ConsoleColor.DarkGray, ConsoleColor.DarkYellow, '/');
                    }
                    break;
                case ItemType.Ammo:
                case ItemType.BFGCell:
                case ItemType.Medikit:
                    Available = false;
                    break;
            }
        }

        private void SetInitialProperties()
        {
            switch (Type)
            {
                case ItemType.Ammo:
                    Sprite = new ConsoleSprite(ConsoleColor.DarkRed, ConsoleColor.DarkYellow, 'A');
                    FillingRatio = 0;
                    break;
                case ItemType.BFGCell:
                    Sprite = new ConsoleSprite(ConsoleColor.Green, ConsoleColor.White, 'B');
                    FillingRatio = 0;
                    break;
                case ItemType.ToxicWaste:
                    Sprite = new ConsoleSprite(ConsoleColor.DarkGreen, ConsoleColor.Green, ':');
                    FillingRatio = 0;
                    break;
                case ItemType.Door:
                    Sprite = new ConsoleSprite(ConsoleColor.DarkGray, ConsoleColor.Yellow, '/');
                    FillingRatio = 1;
                    break;
                case ItemType.Medikit:
                    Sprite = new ConsoleSprite(ConsoleColor.Gray, ConsoleColor.Red, '+');
                    FillingRatio = 0;
                    break;
                case ItemType.LevelExit:
                    Sprite = new ConsoleSprite(ConsoleColor.Green, ConsoleColor.Yellow, 'E');
                    FillingRatio = 1;
                    break;
                case ItemType.Wall:
                    Sprite = new ConsoleSprite(ConsoleColor.DarkGray, ConsoleColor.DarkGray, ' ');
                    FillingRatio = 1;
                    break;
                default:
                    Sprite = new ConsoleSprite(ConsoleColor.Black, ConsoleColor.Black, '\0');
                    FillingRatio = 0;
                    break;
            }
        }
    }
}