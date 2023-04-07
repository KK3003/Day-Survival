using UnityEngine;

public class BulletModel
{
    public BulletModel(BulletScriptableObject bulletScriptableObject)
    {
        BulletType = bulletScriptableObject.bulletType;
        BulletPrefab = bulletScriptableObject.bulletPrefab;
        BulletSpeed = bulletScriptableObject.bulletSpeed;
        BulletDamage = bulletScriptableObject.bulletDamage;
    }

    public BulletType BulletType { get; }

    public Transform BulletSpawnPosition { get; }
    public GameObject BulletPrefab { get; }
    public float BulletSpeed { get; }
    public int BulletDamage { get; }
}
