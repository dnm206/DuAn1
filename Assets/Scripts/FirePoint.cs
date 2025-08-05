using UnityEngine;

public class FirePoint : MonoBehaviour
{
    public GameObject arrowPrefab;     // Gán prefab mũi tên trong Inspector
    public Transform firePoint;        // Gán empty object tại vị trí bắn trong Inspector

    void Start()
    {
        //GameObject arrow = Instantiate(arrowPrefab, firePoint.position, Quaternion.identity);
    }
}
