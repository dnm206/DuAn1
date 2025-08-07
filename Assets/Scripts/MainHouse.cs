using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    public int maxHealth = 1000;
    private int currentHealth;

    public GameObject[] unitPrefabs;
    public Transform spawnPoint;
    public float spawnInterval = 5f;

    public int thoiDai = 0;
    public GameObject[] turrets;
    private GameObject currentTurret;

    void Start()
    {
        currentHealth = maxHealth;
        StartCoroutine(AutoSpawnUnits());
        DeployTurret(thoiDai);
    }

    IEnumerator AutoSpawnUnits()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnUnit();
        }
    }

    void SpawnUnit()
    {
        if (unitPrefabs.Length > thoiDai)
        {
            Instantiate(unitPrefabs[thoiDai], spawnPoint.position, Quaternion.identity);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= Mathf.RoundToInt(damage);
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Base destroyed!");

    }

    public void LenDoi()
    {
        if (thoiDai < unitPrefabs.Length - 1)
        {
            thoiDai++;
            Debug.Log("len thoi: " + thoiDai);
            DeployTurret(thoiDai);
        }
    }

    void DeployTurret(int era)
    {
        if (currentTurret != null)
        {
            Destroy(currentTurret);
        }

        if (turrets.Length > era && turrets[era] != null)
        {
            currentTurret = Instantiate(turrets[era], transform.position, Quaternion.identity, transform);
        }
    }

    public int GetHealth() => currentHealth;
}
