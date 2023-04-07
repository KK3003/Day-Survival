using UnityEngine;

public class BulletController
{
    private BulletModel bulletModel;
    private BulletView bulletView;
    public BulletType bulletType;
    private GameObject bullet;
    private Transform bulletspwanPos;

    public BulletController(BulletModel _bulletModel, BulletView _bulletView, Transform _bulletSpawnPosition)
    {
        bulletModel = _bulletModel;
        bulletspwanPos = _bulletSpawnPosition;
        bulletView = GameObject.Instantiate<BulletView>(_bulletView, bulletspwanPos.position, bulletspwanPos.rotation);
        bulletView.SetBulletController(this);
        ShootBullet();
    }

    public void ShootBullet()
    {
        bulletView.GetComponent<Rigidbody>().velocity = bulletspwanPos.forward * bulletModel.BulletSpeed;
    }

    public int BulletDamage()
    {
        return bulletModel.BulletDamage;
    }
}
