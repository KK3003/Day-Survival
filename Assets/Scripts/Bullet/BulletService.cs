using System;
using UnityEngine;

public class BulletService : MonoBehaviour
{
    public BulletView bulletView;
    public BulletScriptableObject[] bulletConfiguration;
    private static BulletService instance;
    public static BulletService Instance { get { return instance; } }
    public Action<int> bulletFiredbyPlayer;
   
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

    public BulletController CreateNewBullet(Transform spawnpos)
    {
        BulletScriptableObject bulletScriptableObject = bulletConfiguration[0];
        BulletModel model = new BulletModel(bulletScriptableObject);
        BulletController bullet = new BulletController(model, bulletView, spawnpos);
        return bullet;
    }
}
