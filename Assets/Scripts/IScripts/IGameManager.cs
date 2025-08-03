public interface IGameManager
{
    void GameOver();
    void WinGame(int score);
    bool IsGameOver { get; }
}
