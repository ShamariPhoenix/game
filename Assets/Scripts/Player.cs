using UnityEngine;

public class Player : MonoBehaviour
{
    public float Xp { get; private set;}

    public float XpPerLevel = 10f;
    public float XpPerLevelFactor = 1.1f;

    private float XpToNextLevel;

    public LevelUpPanel levelUpPanel;

    private void Awake()
    {
        XpToNextLevel = XpPerLevel;
    }

    public void AddXP(float amount)
    {
        Xp += amount;
        if(Xp >= XpToNextLevel)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        Xp -= XpToNextLevel;
        XpToNextLevel *= XpPerLevelFactor;
        levelUpPanel.Show();
    }
}
