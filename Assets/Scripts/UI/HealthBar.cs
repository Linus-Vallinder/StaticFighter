using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public TextMeshProUGUI HealthAmount;

    [Space]
    public Image Bar;

    public void UpdateHealthBar(float MaxHealth, float CurrentHealth)
    {
        float barFill = CurrentHealth / MaxHealth;

        HealthAmount.text = $"{CurrentHealth}";

        Bar.fillAmount = barFill;
    }
}
