using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float shootTimer;

    public float shootTime;

    public GameObject[] bullet;
    public GameObject player;

    private void Start()
    {
        shootTimer = 0f;
    }

    private void Update()
    {
        if (shootTimer >= shootTime) Shoot();
        else shootTimer += Time.deltaTime;

    }

    private void Shoot()
    {
        //reset timer
        shootTimer = 0f;

        if (player == null)
        {
            GetComponent<Rigidbody2D>().AddForce(10 * Vector2.up, ForceMode2D.Impulse);
            return;
        }

        //instantiate bullet to player's location
        int b = Random.Range(0, 2);
        GameObject currBullet = Instantiate(bullet[b], transform.position, Quaternion.identity);

        Vector2 force = new Vector2((player.transform.position - transform.position).x, currBullet.GetComponent<Bullet>().upForce);
        
        currBullet.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
    }
}
