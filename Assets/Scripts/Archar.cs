using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject arrowPrefab;      // Prefab mũi tên
    public Transform firePoint;         // Vị trí sinh ra mũi tên
    public float attackRange = 5f;      // Phạm vi phát hiện kẻ địch
    public float attackRate = 1f;       // Tốc độ bắn (mũi tên mỗi giây)

    private float nextAttackTime = 0f;
    private GameObject currentTarget;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        FindClosestEnemy();

        if (currentTarget != null)
        {
            if (Time.time >= nextAttackTime)
            {
                animator.SetBool("IsAttacking", true); // Bật animation bắn
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        else
        {
            animator.SetBool("IsAttacking", false); // Tắt animation bắn khi không có địch
        }
    }

    void FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = Mathf.Infinity;
        currentTarget = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < attackRange && distance < closestDistance)
            {
                closestDistance = distance;
                currentTarget = enemy;
            }
        }
    }

    void Attack()
    {
        Invoke("ShootArrow", 0.2f); // Delay để khớp với animation
    }

    void ShootArrow()
    {
        if (currentTarget == null) return;

        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, Quaternion.identity);
        arrow.GetComponent<Arrow>().SetTarget(currentTarget.transform.position);
    }

    // Optional: Vẽ vùng attack trong Scene View
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
