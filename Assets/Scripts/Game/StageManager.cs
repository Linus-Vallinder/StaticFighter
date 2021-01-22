using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public int CurrentStage;
    
    [Space]
    public Stage[] stages;

    [Space]
    public int StageKillCount = 0;
    public int KillAmount = 0;

    private void Start()
    {
        EventManager.Instance.EnemyDeath += KilledEnemy;
    }

    private void Update()
    {
        if (StageKillCount == stages[CurrentStage].AmountOfEnemies)
        {
            ClearStage();
        }
    }

    private void KilledEnemy()
    {
        StageKillCount++;
    }

    public void ClearStage()
    {
        GameManager.Instance.CurrentGameState = GameState.UPGRADING;
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
