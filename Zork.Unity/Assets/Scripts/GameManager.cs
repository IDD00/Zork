using UnityEngine;
using Zork;
using TMPro;

public class GameManager : MonoBehaviour
{
    void Awake()
    {
        TextAsset gameJsonAsset = Resources.Load<TextAsset>(ZorkGameFileAssetName);

        Game.Start(gameJsonAsset.text, InputService, OutputService);
        OutputService.WriteLine(string.IsNullOrWhiteSpace(Game.Instance.WelcomeMessage) ? "Welcome to Zork!" : Game.Instance.WelcomeMessage);
        OutputService.WriteLine($"{Game.Instance.Player.Location.Name}\n{Game.Instance.Player.Location.Description}\n");
        LocationText.text = Game.Instance.Player.Location.Name;

        Game.Instance.Player.LocationChanged += Player_LocationChanged;
        Game.Instance.Player.ScoreChanged += Player_ScoreChanged;
        Game.Instance.Player.MovesChanged += Player_MovesChanged;
    }

    private void Player_LocationChanged(object sender, Room e)
    {
        if (LocationText != null)
        {
            LocationText.text = Game.Instance.Player.Location.Name;
        }
    }

    private void Player_ScoreChanged(object sender, int e)
    {
        if (ScoreText != null)
        {
            ScoreText.text = $"Score: {Game.Instance.Player.Score}";
        }
    }

    private void Player_MovesChanged(object sender, int e)
    {
        if (MovesText != null)
        {
            MovesText.text = $"Moves: {Game.Instance.Player.Moves}";
        }
    }

    void Update()
    {
        if (Game.Instance.IsRunning == false)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }

    [SerializeField]
    private string ZorkGameFileAssetName = "Zork";

    [SerializeField]
    private UnityInputService InputService;

    [SerializeField]
    private UnityOutputService OutputService;

    [SerializeField]
    private TextMeshProUGUI LocationText;

    [SerializeField]
    private TextMeshProUGUI ScoreText;

    [SerializeField]
    private TextMeshProUGUI MovesText;

}
