using UnityEngine;
using TMPro;

public class UpgradeWindow : MonoBehaviour
{
    [Header("Upgrade Panels")]
    public UpgradePanel AgilityPanel;
    public UpgradePanel StrengthPanel;
    public UpgradePanel ConstitutionPanel;

    private PlayerController player;

    [Header("Panel Components")]
    public TextMeshProUGUI SkillPoints;

    private void Start()
    {
        player = GameManager.Instance.playerController;

        SetupSkillPanels();
    }

    private void Update()
    {
        UpdateSkillPoints();
    }

    private void UpdateSkillPoints()
    {
        AgilityPanel.AbilityAmount.text = "" + player.Agility;
        StrengthPanel.AbilityAmount.text = "" + player.Strength;
        ConstitutionPanel.AbilityAmount.text = "" + player.Constitution;

        SkillPoints.text = "Skill Points: " + player.SkillPoints;
    }

    private void SetupSkillPanels()
    {
        AgilityPanel.UpgradeButton.onClick.AddListener(() => UpgradeSkill(1));
        StrengthPanel.UpgradeButton.onClick.AddListener(() => UpgradeSkill(2));
        ConstitutionPanel.UpgradeButton.onClick.AddListener(() => UpgradeSkill(3));
    }

    private void UpgradeSkill(int skill)
    {
        if (player.SkillPoints >= 1)
        {
            switch (skill)
            {
                case 1:
                    player.Agility++;
                    break;
                case 2:
                    player.Strength++;
                    break;
                case 3:
                    player.Constitution++;
                    break;
            }

            player.SkillPoints--;
        }
        else
        {
            Debug.Log("You do not have enough skill points!");
        }
    }
}
