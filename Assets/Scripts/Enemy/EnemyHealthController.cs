using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    [SerializeField] float maxHealth,currentHealth;
    
    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void EnemyTakeDamage(float damage)
    {
        currentHealth -= damage;
        CinemachineShake.instance.ShakeCamera(2.5f, .1f);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        
        
    }

    
}
