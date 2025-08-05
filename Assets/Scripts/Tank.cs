using UnityEngine;

public class Tank : MobBase
{
    public override void Start()
    {
        base.Start();
        maxHP = 300;
        damage = 30;
        attackRange = 1.5f;
        moveSpeed = 1.5f;
    }
}
