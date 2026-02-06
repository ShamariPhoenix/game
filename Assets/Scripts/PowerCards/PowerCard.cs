using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

abstract public class PowerCard : MonoBehaviour
{
    public String Name;
    public String Description;

    public TextMeshProUGUI NameTextField;
    public TextMeshProUGUI DescriptionTextField;

    protected Player player;
    private Button button;
    private LevelUpPanel levelUpPanel;

    protected virtual void Start()
    {
        player = FindFirstObjectByType<Player>();
        button = GetComponent<Button>();
        levelUpPanel = FindFirstObjectByType<LevelUpPanel>();
        
        button.onClick.AddListener(ApplyChoice);
        button.onClick.AddListener(() => 
        {
            levelUpPanel.NotifyChoiceMade();
        });
        NameTextField.text = Name;
        DescriptionTextField.text = Description;
    }

    abstract public void ApplyChoice();
}
