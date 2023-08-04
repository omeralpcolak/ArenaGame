using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool hasAbility = false;
    private float abilityTimer = 0f;

    
    public bool hasFastAttack = false;
    private float fastAttackDuration = 10f;
    private float originalAttackCooldown;
    public GameObject fastAttackAbilityEffect;

    
    private PlayerAttack playerAttack;

    private void Awake()
    {
        playerAttack = GetComponent<PlayerAttack>();
    }
    // Update is called once per frame
    void Update()
    {
        if (hasAbility)
        {
            abilityTimer -= Time.deltaTime;
            if (abilityTimer <= 0)
            {
                // Ability duration is over, disable the ability
                hasAbility = false;
                Debug.Log("Ability deactivated!");

                DeactivateAbilityEffect();
            }
        }
    }

    public void ActivateAbility(string abilityName, float duration)
    {
        hasAbility = true;
        abilityTimer = duration;

        switch (abilityName)
        {
            case "FastAttack":
                hasFastAttack = true;
                originalAttackCooldown = playerAttack.attackCooldown;
                playerAttack.attackCooldown /= 1.5f;
                Debug.Log("Ability activated: FastAttack");
                StartCoroutine(DeactivateFastAttackAfterDuration());
                break;

            default:
                Debug.Log("Unknown ability: " + abilityName);
                break;
        }
    }

    public void DeactivateAbilityEffect()
    {
        if (fastAttackAbilityEffect != null)
        {
            fastAttackAbilityEffect.SetActive(false);
        }
    }

    private IEnumerator DeactivateFastAttackAfterDuration()
    {
        yield return new WaitForSeconds(fastAttackDuration);
        hasFastAttack = false;
        playerAttack.attackCooldown = originalAttackCooldown; 
        Debug.Log("FastAttack ability deactivated!");
    }
}
