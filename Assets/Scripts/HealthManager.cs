using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{

    private int health = 100;

    private void Update()
    {
        if (health <= 0) Die();
    }


    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    private void Die()
    {
        Debug.Log("Died!!!");
        Destroy(gameObject);
    }

}
