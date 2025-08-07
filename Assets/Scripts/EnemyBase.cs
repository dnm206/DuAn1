using UnityEngine;
using System.Collections;

public class EnemyBaseController : BaseController
{
    // Kế thừa toàn bộ logic từ BaseController

    protected override void Start()
    {
        base.Start();
        gameObject.tag = "EnemyBase"; // Dùng để phân biệt trong MobBase/Arrow
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        Debug.Log($"Enemy base took {damage} damage.");
    }

    protected override void Die()
    {
        Debug.Log("Enemy base destroyed!");
        // Có thể thêm hiệu ứng nổ, kết thúc màn chơi,...
        Destroy(gameObject);
    }
}
