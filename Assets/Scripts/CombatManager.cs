using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public static CombatManager Instance;

    public Queue<MobBase> allyQueue = new Queue<MobBase>();
    public Queue<MobBase> enemyQueue = new Queue<MobBase>();

    void Awake()
    {
        Instance = this;
    }

    public void RegisterMob(MobBase mob)
    {
        if (mob.team == Team.Ally)
            allyQueue.Enqueue(mob);
        else
            enemyQueue.Enqueue(mob);
    }

    void Update()
    {
        if (allyQueue.Count > 0 && enemyQueue.Count > 0)
        {
            MobBase ally = allyQueue.Peek();
            MobBase enemy = enemyQueue.Peek();

            if (!ally.isDead && !enemy.isDead)
            {
                float dist = Vector3.Distance(ally.transform.position, enemy.transform.position);
                if (dist <= ally.attackRange || dist <= enemy.attackRange)
                {
                    ally.SetTarget(enemy.transform);
                    enemy.SetTarget(ally.transform);
                }
            }
            else
            {
                if (ally.isDead) allyQueue.Dequeue();
                if (enemy.isDead) enemyQueue.Dequeue();
            }
        }
    }
}
