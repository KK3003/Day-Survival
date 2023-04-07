using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{ 
    public static UIManager instance;
    public Text bulletAchievemntText;
    public GameObject pausePanel;
    public GameObject instructionPanel;
    public GameObject tenBullets;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }  
}
