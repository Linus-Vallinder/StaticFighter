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

    [Header("Attack Stats")]
    public float BaseAttack;

    [Header("Player UI")]
    public HealthBar HealthBar;

    [Header("Enemy")]
    public EnemyController Enemy;

    private void Awake()
    {
        SetUp();
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
        float damage = Mathf.RoundToInt(BaseAttack + Random.Range(1, Strength * Agility));
        return damage;
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
