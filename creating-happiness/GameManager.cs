public class GameManager
{
    private static GameManager _instance;
    public static GameManager Instance => _instance ?? (_instance = new GameManager());

    private Character player;

    private GameManager()
    {
        player = Character.GetInstance();
    }

    public void StartGame()
    {
        // Initialize game setup
        Console.WriteLine("Game Started");
    }

    public void DisplayStatus()
    {
        player.DisplayStatus();
    }
}
