using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    [SerializeField] float maxHealth,currentHealth;
    public float shakeIntensity = 5f;
    public float shakeDuration = .2f;
    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void EnemyTakeDamage(float damage)
    {
        currentHealth -= damage;
        CinemachineShake.instance.ShakeCamera(3f, .1f);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        
        
    }

    
}
