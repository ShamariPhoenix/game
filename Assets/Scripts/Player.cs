using System;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Video;
using TMPro;

public class Player : MonoBehaviour
{
    public float Xp { get; private set; }

    public float XpPerLevel = 10f;
    public float MaxSpeed;
    public float Acceleration;
    public LevelUpPanel levelUpPanel;

    private float XpToNextLevel;
    private Vector3 velocity = Vector3.zero;
    private float XpPerLevelIncrease;
    private TextMeshProUGUI XpText;


    private void Awake()
    {
        XpToNextLevel = XpPerLevel;
        XpPerLevelIncrease = XpPerLevel;
        XpText = GetComponentInChildren<TextMeshProUGUI>();
        UpdateText();
    }

    public void AddXP(float amount)
    {
        Xp += amount;
        if (Xp >= XpToNextLevel)
        {
            LevelUp();
        }
        UpdateText();
    }

    private void LevelUp()
    {
        Xp -= XpToNextLevel;
        XpToNextLevel += XpPerLevelIncrease;
        levelUpPanel.Show();
    }

    private void UpdateText()
    {
        XpText.text = $"XP: {Xp}/{XpToNextLevel}";
    }
}
