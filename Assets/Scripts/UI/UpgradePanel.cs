using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanel : MonoBehaviour
{
    [Header("Panel Information")]
    public string PanelTitle;

    [Space]
    [TextArea]
    public string PanelDescription;

    [Header("Panel Components")]
    public Button UpgradeButton;

    [Space]
    public TextMeshProUGUI Title;

    public TextMeshProUGUI Description;

    [Space]
    public TextMeshProUGUI AbilityAmount;

    private void Update()
    {
        UpdatePanelInformation();
    }

    private void UpdatePanelInformation()
    {
        Title.text = PanelTitle;
        Description.text = PanelDescription;
    }
}