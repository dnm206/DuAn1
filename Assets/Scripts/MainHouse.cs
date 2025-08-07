using UnityEngine;
using System.Collections;

public class BaseController : MonoBehaviour
{
    public int maxHealth = 1000;
    protected int currentHealth;

    public GameObject[] unitPrefabs;
    public Transform spawnPoint;
    public float spawnInterval = 5f;

    public int thoiDai = 0;
    public GameObject[] turrets;
    protected GameObject currentTurret;

    protected virtual void Start()
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

    protected virtual void SpawnUnit()
    {
        if (unitPrefabs.Length > thoiDai)
        {
            Instantiate(unitPrefabs[thoiDai], spawnPoint.position, Quaternion.identity);
        }
    }

    public virtual void TakeDamage(float damage)
    {
        currentHealth -= Mathf.RoundToInt(damage);
        Debug.Log($"{gameObject.name} took {damage} damage. Current HP: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
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

    protected virtual void DeployTurret(int era)
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
