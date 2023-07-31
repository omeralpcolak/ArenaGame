using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public float bulletDamage = 2;
    [SerializeField] GameObject damageEffect;

    void FixedUpdate()
    {
       
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(gameObject);
            Instantiate(damageEffect, transform.position, transform.rotation);
            other.GetComponent<EnemyHealthController>().EnemyTakeDamage(bulletDamage);
        }
    }
}
