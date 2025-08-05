using UnityEngine;

public class Normal : MobBase
{
    public override void Start()
    {
        base.Start();
        maxHP = 150;
        damage = 15;
        attackRange = 1.5f;
        moveSpeed = 2.5f;
    }
}
