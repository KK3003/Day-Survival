using UnityEngine;
using UnityEngine.AI;

public class EnemyController
{
    public EnemyModel enemyModel;
    private EnemyView enemyView;
    public EnemyType enemyType;
    int _currentWaypoint;
    protected EnemyState currentSate;
    public int destPoints = 0;

    public EnemyController(EnemyModel _enemyModel, EnemyView _enemyView, Transform _enemySpawnPos)
    {
        enemyModel = _enemyModel;
        enemyView = _enemyView;
        enemyView = GameObject.Instantiate<EnemyView>(_enemyView, _enemySpawnPos);
        enemyView.SetEnemyController(this);
        ChangeState(enemyView.GetComponent<EnemyChasingState>());
    }

    public EnemyModel GetEnemyModel()
    {
        return enemyModel;
    }

    public void Patrolling()
    {
        if (enemyView.navMeshAgent.remainingDistance < 1f)
        {
            if (destPoints >= enemyModel.Waypoints.Length - 1)
            {
                destPoints = 0;
            }
            else
            {
                destPoints++;
            }
            enemyView.navMeshAgent.SetDestination(enemyModel.Waypoints[destPoints].transform.position);
        }
    }

    public bool IsPatrolling()
    {
        Transform wp = enemyModel.Waypoints[_currentWaypoint];
        return Vector3.Distance(enemyView.transform.position, wp.position) < 0.01f;
    }

    public void ChasingPlayer()
    {
        enemyView.transform.LookAt(PlayerController.instance.PlayerPosition().position);
        enemyView.navMeshAgent.SetDestination(PlayerController.instance.PlayerPosition().position);
    }

    public bool IsInChaseRange()
    {
        return DistanceBetTanks() <= enemyModel.ChaseRange;
    }

    public void Shooting()
    {
        if (enemyModel.CountDownBetweenFire <= 0)
        {
            foreach (Transform spawnPoints in enemyView.ProjectileSpawnPoint)
            {
                BulletService.Instance.CreateNewBullet(spawnPoints);

            }
            enemyModel.CountDownBetweenFire = 1f / enemyModel.FireRate;
        }
        enemyModel.CountDownBetweenFire -= Time.deltaTime;
    }

    public bool IsInShootingRange()
    {
        return DistanceBetTanks() <= enemyModel.ShootRange; // chnage naming
    }

    public void ChangeState(EnemyState newState)
    {
        if (currentSate != null)
        {
            currentSate.OnExitState();
        }
        currentSate = newState;
        currentSate.OnEnterState();
    }

    public NavMeshAgent EnemyNavMeshAgent()
    {
        return enemyView.navMeshAgent;
    }

    private float DistanceBetTanks()
    {
        if (enemyView == null)
        {
            return Mathf.Infinity;
        }
        return Vector3.Distance(PlayerController.instance.PlayerPosition().position, enemyView.transform.position);
    }
}
