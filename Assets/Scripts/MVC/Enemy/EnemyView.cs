using UnityEngine;
using UnityEngine.AI;

public class EnemyView : MonoBehaviour
{
    public EnemyController enemyController;
    public EnemyType enemyType;
    public Transform[] ProjectileSpawnPoint;
    public NavMeshAgent navMeshAgent;
    public GameObject deathEffect;
    int damage = 10;
   

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();   
    }

    void Update()
    {
        if(enemyController.enemyModel.Health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void SetEnemyController(EnemyController _enemyController)
    {
        enemyController = _enemyController;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BulletView>())
        {
            enemyController.enemyModel.Health = enemyController.enemyModel.Health - damage;
        }
    }
}

