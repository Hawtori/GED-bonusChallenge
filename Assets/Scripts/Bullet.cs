using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool changeInput;
    public int changeScoreOnHit;
    public int changeScoreOnDodge;
    public float upForce;

    private void Awake()
    {
        Invoke("Die", 3f);
    }

    private void Update()
    {
        if (transform.position.x == GameObject.Find("Player").transform.position.x) ScoreManager._instance.UpdateScore(changeScoreOnDodge);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ScoreManager._instance.UpdateScore(changeScoreOnHit);
            collision.gameObject.GetComponent<HealthManager>().TakeDamage(-changeScoreOnHit);
            if (changeInput) ChangeInput(collision);
            Die();
        }
        Die();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ScoreManager._instance.UpdateScore(changeScoreOnDodge);
        }
    }

    private void ChangeInput(Collision2D col)
    {
        col.gameObject.GetComponent<PlayerMovement>().swapInput = !col.gameObject.GetComponent<PlayerMovement>().swapInput;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
