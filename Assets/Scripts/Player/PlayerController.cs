using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Stats")]
    public float MaxHealth;

    [Space]
    public float CurrentHealth;

    [Space]
    public int SkillPoints = 0;

    [Space]
    public float Strength = 5f;
    public float Agility = 5f;
    public float Constitution = 5f;

    [Header("Player UI")]
    public HealthBar HealthBar;

    [Header("Enemy")]
    public EnemyController Enemy;

    private void Awake()
    {
        SetUp();
    }

    private void Start()
    {
        new KillAchievement(GameManager.Instance.stageManager, 10);
        new KillAchievement(GameManager.Instance.stageManager, 25);
        new KillAchievement(GameManager.Instance.stageManager, 50);
        new KillAchievement(GameManager.Instance.stageManager, 75);
        new KillAchievement(GameManager.Instance.stageManager, 100);
        new KillAchievement(GameManager.Instance.stageManager, 150);
        new KillAchievement(GameManager.Instance.stageManager, 250);
        new KillAchievement(GameManager.Instance.stageManager, 500);
        new KillAchievement(GameManager.Instance.stageManager, 1000);
    }

    private void Update()
    {
        if (GameManager.Instance.CurrentGameState != GameState.PLAYING)
        {
            return;
        }

        HealthBar.UpdateHealthBar(MaxHealth, CurrentHealth);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    private void SetUp()
    {
        CurrentHealth = MaxHealth;
    }

    public void Attack()
    {
        if (GameManager.Instance.CurrentGameState != GameState.PLAYING)
        {
            return;
        }

        DealDamage(AttackDamage());
    }

    private float AttackDamage()
    {
        float damage = Mathf.RoundToInt(BaseAttack() + Random.Range(1, BaseAttack() * Agility) / 2);
        return damage;
    }

    private float BaseAttack()
    {
        return 5f * Strength;
    }

    private void TakeDamage(float Damage)
    {
        CurrentHealth -= Damage;
    }

    private void DealDamage(float Damage)
    {

        int RandomNumber = Random.Range(1, 8);

        if (RandomNumber + Agility > Enemy.Agility)
        {
            EventManager.Instance.OnDamage(true, Damage);
            Enemy.CurrentHealth -= Damage;
            Enemy.hitEffect.Play();
        }
        else
        {
            EventManager.Instance.OnDamage(false, 0);
        }
    }
}

public class KillAchievement
{
    readonly StageManager stageManager;

    public int KillsToUnlock;

    private void KillsUpdated()
    {
        if (stageManager.KillAmount + stageManager.StageKillCount >= KillsToUnlock)
        {
            AchievementGained();
        }
    }

    public KillAchievement(StageManager stageManager, int killsToUnlock)
    {
        this.stageManager = stageManager;
        KillsToUnlock = killsToUnlock;

        EventManager.Instance.EnemyDeath += KillsUpdated;
    }

    private void AchievementGained()
    {
        Debug.Log($"You have gain the achievement for klling {KillsToUnlock} enemies!");
        EventManager.Instance.EnemyDeath -= KillsUpdated;
    }
}
