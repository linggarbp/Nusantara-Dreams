using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float thrust;
    public float knockTime = .3f;
    public float damage;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] InventoryItem[] items;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GameOver") &&
            items[0].numberHeld >= 9 &&
            items[1].numberHeld >= 7 &&
            items[2].numberHeld >= 1)
        {
            Debug.Log("Game Over");
            Time.timeScale = 0f;
            gameOverPanel.SetActive(true);
        }

        if (collision.gameObject.CompareTag("Breakable"))
        {
            collision.GetComponent<Pot>().Smash();
        }

        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D hit = collision.GetComponent<Rigidbody2D>();
            if (hit != null)
            {
                Vector2 difference = hit.transform.position - transform.position;
                difference = difference.normalized * thrust;
                hit.AddForce(difference, ForceMode2D.Impulse);
                if (collision.gameObject.CompareTag("Enemy") && collision.isTrigger)
                {
                    hit.GetComponent<Enemy>().currentState = EnemyState.Stagger;
                    collision.GetComponent<Enemy>().Knock(hit, knockTime, damage);
                }
                if (collision.gameObject.CompareTag("Player") && collision.isTrigger)
                {
                    if (collision.GetComponent<PlayerMovement>().currentState != PlayerState.Stagger)
                    {
                        hit.GetComponent<PlayerMovement>().currentState = PlayerState.Stagger;
                        collision.GetComponent<PlayerMovement>().Knock(knockTime);
                    }
                }
            }
        }

        //private void OnTriggerEnter2D(Collider2D collision)
        //{
        //    if (collision.gameObject.CompareTag("Enemy"))
        //    {
        //        Rigidbody2D enemy = collision.GetComponent<Rigidbody2D>();
        //        if (enemy != null)
        //        {
        //            enemy.GetComponent<Enemy>().currentState = EnemyState.Stagger;
        //            StartCoroutine(KnockCo(enemy));
        //        }
        //    }
        //}

        //private IEnumerator KnockCo(Rigidbody2D enemy)
        //{
        //    Vector2 forceDirection = enemy.transform.position - transform.position;
        //    Vector2 force = forceDirection.normalized * thrust;

        //    enemy.velocity = force;
        //    yield return new WaitForSeconds(.3f);
        //    enemy.velocity = Vector2.zero;
        //    enemy.GetComponent<Enemy>().currentState = EnemyState.Idle;

        //    enemy.velocity = new Vector2();
        //}
    }
}

