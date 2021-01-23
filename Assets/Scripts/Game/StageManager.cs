using UnityEngine;

public class StageManager : MonoBehaviour
{
    public int CurrentStage;

    [Space]
    public Stage[] stages;

    [Space]
    private int StageKillCount = 0;
    private int KillAmount = 0;

    private void Start()
    {
        EventManager.Instance.EnemyDeath += KilledEnemy;
        EventManager.Instance.ClearStage += ClearStage;
    }

    private void Update()
    {
        if (StageKillCount == stages[CurrentStage].AmountOfEnemies && GameManager.Instance.CurrentGameState == GameState.PLAYING)
        {
            EventManager.Instance.OnClearStage();
        }
    }

    private void KilledEnemy()
    {
        StageKillCount++;
    }

    public void ClearStage()
    {
        GameManager.Instance.CurrentGameState = GameState.UPGRADING;
        GameManager.Instance.playerController.SkillPoints++;
    }

    public void NextStage()
    {
        Debug.Log("Go to next Stage!");

        if (CurrentStage >= stages.Length)
        {
            GameManager.Instance.CurrentGameState = GameState.WIN;
            Debug.Log("You Win!");
        }
        else
        {
            KillAmount += StageKillCount;
            StageKillCount = 0;
            CurrentStage++;
            GameManager.Instance.CurrentGameState = GameState.PLAYING;
        }
    }
}

[System.Serializable]
public class Stage
{
    public int AmountOfEnemies;
}
