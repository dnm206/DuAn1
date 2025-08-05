using UnityEngine;

public enum Team { Ally, Enemy }
public enum MobState { Idle, Walk, Attack, Die }

public class MobBase : MonoBehaviour
{
    public string mobName;
    public Team team;
    public float maxHP = 100;
    public float currentHP;
    public float damage = 10;
    public float attackRange = 1.5f;
    public float attackCooldown = 1.5f;
    public float moveSpeed = 2f;
    public int goldReward = 10;

    public MobState state = MobState.Idle;

    protected Animator anim;
    protected Transform target;
    protected float nextAttackTime = 0f;

    public bool isDead => currentHP <= 0;

    public virtual void Start()
    {
        currentHP = maxHP;
        anim = GetComponent<Animator>();
        ChangeState(MobState.Walk);
    }

    public virtual void Update()
    {
        if (isDead) return;

        if (state == MobState.Walk)
        {
            MoveForward();
        }
        else if (state == MobState.Attack && target != null)
        {
            if (Time.time >= nextAttackTime)
            {
                Attack();
                nextAttackTime = Time.time + attackCooldown;
            }
        }
    }

    protected void MoveForward()
    {
        float dir = (team == Team.Ally) ? 1f : -1f;
        transform.Translate(Vector3.right * dir * moveSpeed * Time.deltaTime);
    }

    public void TakeDamage(float dmg)
    {
        currentHP -= dmg;
        if (currentHP <= 0)
        {
            Die();
        }
    }

    protected virtual void Attack()
    {
        anim.SetTrigger("Attack");
        if (target != null)
        {
            MobBase mob = target.GetComponent<MobBase>();
            if (mob != null && !mob.isDead)
            {
                mob.TakeDamage(damage);
            }
        }
    }

    protected virtual void Die()
    {
        ChangeState(MobState.Die);
        anim.SetTrigger("Die");
        if (team == Team.Enemy)
        {
            GoldManager.Instance.AddGold(goldReward);
        }
        Destroy(gameObject, 2f);
    }


    public void ChangeState(MobState newState)
    {
        state = newState;
        anim.SetBool("Walk", state == MobState.Walk);
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        ChangeState(MobState.Attack);
    }
}
