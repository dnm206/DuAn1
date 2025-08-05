using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 10f;
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
            Debug.Log("Trúng enemy → Xóa cả 2");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }


}
