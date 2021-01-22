using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("PlayerStats")]
    public float MaxHealth;

    [Space]
    public float CurrentHealth;

    [Space]
    public float Strength = 5f;
    public float Intelligence = 5f;
    public float Agility = 5f;

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
        DealDamage(AttackDamage());
    }

    private float AttackDamage()
    {
        float damage = Strength * Agility;
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
        }
        else
        {
            EventManager.Instance.OnDamage(false, 0);
        }

    }
}
