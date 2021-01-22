﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    public TextMeshPro DamageText => GetComponent<TextMeshPro>();

    public float FadeTime;

    public Rigidbody2D rb2d => GetComponent<Rigidbody2D>();

    public void Setup(float amount)
    {
        float RandomSize = Random.Range(0.5f, 1);

        DamageText.text = "" + amount;
        this.transform.localScale = new Vector3(RandomSize, RandomSize);
        StartCoroutine(Fade());
    }

    public IEnumerator Fade()
    {
        yield return new WaitForSeconds(FadeTime);
        Destroy(this.gameObject);
    }
}
