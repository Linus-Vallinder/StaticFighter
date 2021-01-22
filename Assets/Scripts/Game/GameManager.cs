using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState CurrentGameState;

    [HideInInspector]
    public PlayerController playerController;
    [HideInInspector]
    public EnemyController enemyController;
    [HideInInspector]
    public StageManager stageManager;
    [HideInInspector]
    public UpgradeWindow upgradeWindow;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        enemyController = FindObjectOfType<EnemyController>();

        stageManager = FindObjectOfType<StageManager>();
        upgradeWindow = FindObjectOfType<UpgradeWindow>();

        Setup(GameState.PLAYING);
    }

    private void Update()
    {
        if (CurrentGameState == GameState.UPGRADING)
        {
            upgradeWindow.gameObject.SetActive(true);
        }
        else if (CurrentGameState != GameState.UPGRADING)
        {
            upgradeWindow.gameObject.SetActive(false);
        }
    }

    public void Setup(GameState state)
    {
        CurrentGameState = state;
    }
}

public enum GameState
{
    PAUSED,
    PLAYING,
    UPGRADING,
    LOST,
    WIN
}