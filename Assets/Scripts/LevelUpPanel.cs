using UnityEngine;

public class LevelUpPanel : MonoBehaviour
{
    public void Show() 
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void NotifyChoiceMade()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
