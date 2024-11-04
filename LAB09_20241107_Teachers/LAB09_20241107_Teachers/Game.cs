namespace LAB09_20241107_Teachers
{
    public class Game
    {
        private readonly Player player;
        public bool Exited { get; set; }

        public List<GameItem> Items { get; }

        public Game()
        {
            player = new Player(0, 0);
            Items = new List<GameItem>();
        }

        private void RenderSingleSprite(Position position, ConsoleSprite sprite)
        {
            int x = position.X;
            int y = position.Y;
            if (0 <= x && x < Console.WindowWidth && 0 <= y && y < Console.WindowHeight)
            {
                Console.SetCursorPosition(x, y);
                Console.BackgroundColor = sprite.Background;
                Console.ForegroundColor = sprite.Foreground;
                Console.Write(sprite.Glyph);
            }
        }

        private void RenderGame()
        {
            Console.CursorVisible = false;
            Console.ResetColor();
            Console.Clear();

            foreach (GameItem item in Items)
            {
                RenderSingleSprite(item.Position, item.Sprite);
            }

            RenderSingleSprite(player.Position, player.Sprite);
        }

        private List<GameItem> GetGameItemsWithinDistance(Position position, double distance)
        {
            List<GameItem> items = new List<GameItem>();
            foreach (GameItem item in this.Items)
            {
                if (Position.Distance(position, item.Position) <= distance)
                {
                    items.Add(item);
                }
            }
            return items;
        }

        private double GetTotalFillingRatio(Position position)
        {
            List<GameItem> items = GetGameItemsWithinDistance(position, 0);
            double sumFillingRatio = 0;
            foreach (GameItem item in items)
            {
                sumFillingRatio = sumFillingRatio + item.FillingRatio;
            }
            return sumFillingRatio;
        }

        private void Move(Player player, Position targetPosition)
        {
            double targetFillingRatio = GetTotalFillingRatio(targetPosition) + player.FillingRatio;
            if (targetFillingRatio <= 1)
            {
                player.Position = targetPosition;
            }
        }

        private void UserAction()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressed = Console.ReadKey(true);
                switch (pressed.Key)
                {
                    case ConsoleKey.Escape:
                        Exited = true;
                        break;
                    case ConsoleKey.RightArrow:
                        Move(player, Position.Add(player.Position, new Position(1, 0)));
                        break;
                    case ConsoleKey.LeftArrow:
                        Move(player, Position.Add(player.Position, new Position(-1, 0)));
                        break;
                    case ConsoleKey.UpArrow:
                        Move(player, Position.Add(player.Position, new Position(0, -1)));
                        break;
                    case ConsoleKey.DownArrow:
                        Move(player, Position.Add(player.Position, new Position(0, 1)));
                        break;
                    case ConsoleKey.D:
                        foreach (GameItem item in Items)
                        {
                            item.Interact();
                        }
                        break;
                    default:
                        break;
                }

            }
        }

        private void CleanUpGameItems()
        {
            List<GameItem> itemsToRemove = new List<GameItem>();
            foreach (GameItem item in Items)
            {
                if (!item.Available)
                {
                    itemsToRemove.Add(item);
                }
            }
            foreach (GameItem item in itemsToRemove)
            {
                Items.Remove(item);
            }
        }

        public void Run()
        {
            while (!Exited)
            {
                RenderGame();
                UserAction();
                CleanUpGameItems();
                Thread.Sleep(25);
            }
        }
    }
}