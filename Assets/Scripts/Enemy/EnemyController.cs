﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
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

    [Space]
    public GameObject Popup;

    private void Awake()
    {
        SetUp();
    }

    private void Start()
    {
        EventManager.Instance.EnemyDeath += ResetEnemy;
        EventManager.Instance.Damage += SpawnPopup;
    }

    private void Update()
    {
        HealthBar.UpdateHealthBar(MaxHealth, CurrentHealth);

        if (CurrentHealth <= 0)
        {
            EventManager.Instance.OnEnemyDeath();
        }
    }

    private void SetUp()
    {
        CurrentHealth = MaxHealth;
    }

    private void SpawnPopup(bool hit, float damage)
    {
        float RandomNumberOne = Random.Range(-5, 5);
        float RandomNumberTwo = Random.Range(-5, 5);

        var clone = Instantiate(Popup, this.transform);
        clone.GetComponent<DamagePopup>().Setup(damage);
        clone.GetComponent<DamagePopup>().rb2d.AddForce((Vector2.up * 5) + new Vector2(RandomNumberOne, RandomNumberTwo), ForceMode2D.Impulse);
    }

    private void ResetEnemy()
    {
        CurrentHealth = MaxHealth;
        Debug.Log("Enemy is Dead!");
    }
}