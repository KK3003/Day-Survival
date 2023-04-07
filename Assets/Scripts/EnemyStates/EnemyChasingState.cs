public class EnemyChasingState : EnemyState
{
    public override void OnEnterState()
    {
        base.OnEnterState();
        agent.isStopped = false;
    }

    private void Update()
    {
        if(enemyView.enemyController.IsInShootingRange())
        {
            enemyView.enemyController.ChangeState(GetComponent<EnemyShootingState>());
            return;
        }
        if(!enemyView.enemyController.IsInChaseRange())
        {
            enemyView.enemyController.ChangeState(GetComponent<EnemyPatrollingState>());
            return;
        }
        enemyView.enemyController.ChasingPlayer();
    }
}
