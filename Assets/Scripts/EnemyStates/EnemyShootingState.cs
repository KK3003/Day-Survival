using UnityEngine;

public class EnemyShootingState : EnemyState
{
    public override void OnEnterState()
    {
        base.OnEnterState();
        agent.isStopped = true;
    }

    private void Update()
    {
        
        Debug.Log("Is in Shooting State");
        if (!enemyView.enemyController.IsInShootingRange())
        {
            enemyView.enemyController.ChangeState(GetComponent<EnemyPatrollingState>());
            return;
        }
        enemyView.enemyController.Shooting();
    }
}
