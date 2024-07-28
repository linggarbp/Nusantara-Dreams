using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    Idle,
    Walk,
    Attack,
    Stagger
}

public class Enemy : MonoBehaviour
{
    public EnemyState currentState;
    public PlayerHit maxHealth;
    public float health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed = 2f;
    //public int killPoint = 0;
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    AudioSource sfxHit;
    [SerializeField]
    List<GameObject> unlockSkill;
    [SerializeField]
    List<GameObject> enemyKillable;
    public List<GameObject> prefabsToSpawn; // Prefab GameObject yang akan di-spawn
    public GameObject targetObject; // GameObject target yang akan dijadikan tempat spawn

    private void Awake()
    {
        health = maxHealth.initialValue;
    }

    public void TakeDamage(float damage)
    {
        sfxHit.Play();
        if (enemyKillable[0].activeSelf && enemyKillable[1].activeSelf && (enemyKillable[2].activeSelf || enemyKillable[3].activeSelf || enemyKillable[4].activeSelf || enemyKillable[5].activeSelf))
        {
            health -= damage;
        }
        if (health <= 0)
        {
            //gameObject.SetActive(false);
            //killPoint = killPoint + 100;
            Destroy(gameObject);
            unlockSkill[0].SetActive(false);
            unlockSkill[1].SetActive(true);
            //gameManager.score = killPoint;
            int randomIndex = Random.Range(0, prefabsToSpawn.Count);
            Instantiate(prefabsToSpawn[randomIndex], targetObject.transform.position, Quaternion.identity);
        }
    }

    public void Knock(Rigidbody2D rb, float knockTime, float damage)
    {
        StartCoroutine(KnockCo(rb, knockTime));
        TakeDamage(damage);
    }

    private IEnumerator KnockCo(Rigidbody2D rb, float knockTime)
    {
        if (rb != null)
        {
            yield return new WaitForSeconds(knockTime);
            rb.velocity = Vector2.zero;
            currentState = EnemyState.Idle;
            rb.velocity = Vector2.zero;
        }
    }
}
