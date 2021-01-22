﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillCount : MonoBehaviour
{
    public TextMeshProUGUI KillCountText;

    [Space]
    public int Count;

    private void Start()
    {
        EventManager.Instance.EnemyDeath += IncrementCount;
    }

    private void Update()
    {
        UpdateCount();
    }

    public void UpdateCount()
    {
        KillCountText.text = "" + Count;
    }

    public void IncrementCount()
    {
        Count++;
    }
}
