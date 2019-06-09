using NConsoleGraphics;

namespace ArkanoidGame
{
    public interface IGameObject
    {
        void Render(ConsoleGraphics graphics);

        void Update(GameEngine engine);
    }
}
