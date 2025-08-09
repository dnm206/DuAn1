using UnityEngine;

public class Ranged : MobBase
{
    public override void Start()
    {
        base.Start();
        maxHP = 120;
        damage = 20;
        attackRange = 5f; // bắn xa
        moveSpeed = 2f;
    }
}
