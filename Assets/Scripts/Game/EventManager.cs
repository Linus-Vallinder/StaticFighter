using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

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

    public delegate void DestroyTarget();

    public event DestroyTarget EnemyDeath;
    public void OnEnemyDeath()
    {
        if (EnemyDeath != null)
        {
            this.EnemyDeath.Invoke();
        }
    }

    public delegate void DamageTarget(bool hit, float damage);

    public event DamageTarget Damage;
    public void OnDamage(bool hit, float damage)
    {
        if (Damage != null)
        {
            this.Damage.Invoke(hit, damage);
        }
    }
}