using UnityEngine;

[CreateAssetMenu(fileName = "BulletScriptableObject", menuName = "BulletScriptableObject/Bullet")]
public class BulletScriptableObject : ScriptableObject
{
    public BulletType bulletType;
    public string bulletName;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public int bulletDamage;

}

