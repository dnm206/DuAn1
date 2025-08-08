using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 20f; // Sát thương gây ra
    private Vector2 direction;

    void Start()
    {
        // Tự hủy sau 3 giây nếu không trúng gì
        Destroy(gameObject, 3f);
    }

    public void SetTarget(Vector2 targetPosition)
    {
        direction = (targetPosition - (Vector2)transform.position).normalized;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Va chạm với: " + collision.name);

        if (collision.CompareTag("Enemy"))
        {
            EnemyHealth enemy = collision.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage); // Gọi hàm trừ máu
            }
            Destroy(gameObject); // Xóa mũi tên sau khi trúng
        }
    }
}
