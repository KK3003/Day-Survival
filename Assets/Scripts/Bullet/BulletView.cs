using UnityEngine;

public class BulletView : MonoBehaviour
{
    public BulletType bulletType;
    public BulletController bulletController;
   
    public int GetDamage()
    {
        return bulletController.BulletDamage();
    }
    public void SetBulletController(BulletController _bulletController)
    {
        bulletController = _bulletController;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerManager.instance.currentHealth = PlayerManager.instance.currentHealth - 10;
            PlayerManager.instance.playerHealth.text = $"HP:{PlayerManager.instance.currentHealth}";
        }
    }
}
