using UnityEngine;

public class EnemyPatrollingState : EnemyState
{
    int currentIndex;
    public override void OnEnterState()
    {
        base.OnEnterState();
        currentIndex = -1;    
    }

    private void Update()
    {
        enemyView.enemyController.Patrolling();
        if(enemyView.enemyController.IsInChaseRange())
        {
            enemyView.enemyController.ChangeState(GetComponent<EnemyChasingState>());
            return;
        }  
    }
}
    

