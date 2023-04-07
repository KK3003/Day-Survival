using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public bool canShoot = false;
    public GameObject gun;
    public int maxHealth= 100;
    public int currentHealth;
    public int p_EXP;
    public Text playerHealth;
    public Text playerEXP;

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

        currentHealth = maxHealth;
    }

    public void IncreasePlayerHealth(int value)
    {
        currentHealth += value;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        playerHealth.text = $"HP:{currentHealth}";
        
    }

    public void IncreasePlayerEXP(int value)
    {
        p_EXP += value;
        playerEXP.text = $"EXP:{p_EXP}";
    }

    public void UseGun()
    {
        gun.SetActive(true);
    }
}
