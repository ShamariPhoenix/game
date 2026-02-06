using System;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Video;

public class Player : MonoBehaviour
{
    public float Xp { get; private set;}

    public float XpPerLevel = 10f;
    public float XpPerLevelFactor = 1.1f;
    public float MaxSpeed;
    public float Acceleration;
    public LevelUpPanel levelUpPanel;

    private float XpToNextLevel;
    private Vector3 velocity = Vector3.zero;


    private void Awake()
    {
        XpToNextLevel = XpPerLevel;
    }

    public void Update()
    {
        var cursorPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        var deltaX = cursorPosition.x - transform.position.x;
        velocity.x = deltaX * Acceleration;
        if(Mathf.Abs(velocity.x) > MaxSpeed)
        {
            velocity.x = MaxSpeed * Math.Sign(velocity.x);
        }
        transform.position += velocity * Time.deltaTime;
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
