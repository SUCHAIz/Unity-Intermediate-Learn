using UnityEngine;
using UnityEngine.AI;

public class Attack : State
{
    private float attackCooldown = 1.5f; // เวลาระหว่างการโจมตี
    private float lastAttackTime;
    private float attackRange = 2f; // ระยะโจมตี

    public Attack(Enemy character, NavMeshAgent agent) : base(character, agent)
    {
        Name = STATE.ATTACK;
    }

    public override void Enter()
    {
        base.Enter();
        lastAttackTime = Time.time - attackCooldown; // ให้สามารถโจมตีได้ทันที
    }

    [System.Obsolete]
    public override void Update()
    {
        base.Update();

        // ตรวจสอบระยะห่างจาก Player
        float distanceToPlayer = Vector3.Distance(Me.transform.position, PlayerController.Instance.transform.position);

        if (!Me._isPlayerInView || distanceToPlayer > 10f)
        {
            NextState = new Patrol(Me, Agent);
            Stage = EVENT.EXIT;
            return;
        }

        // หากอยู่นอกระยะโจมตี ให้เดินเข้าไปหา
        if (distanceToPlayer > attackRange)
        {
            Agent.SetDestination(PlayerController.Instance.transform.position);
        }
        else
        {
            Agent.ResetPath();

            // ถ้าคูลดาวน์หมดแล้ว ให้โจมตี
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                Me.AttackPlayer();
                lastAttackTime = Time.time;
                Debug.Log("In attack range, will try to shoot");

            }
        }
    }

    public override void Exit()
    {
        Agent.ResetPath();
        base.Exit();
    }
}
