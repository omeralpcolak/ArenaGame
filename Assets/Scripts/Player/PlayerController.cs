using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    private bool hasAbility = false;
    private float abilityTimer = 0f;
    private float abilityDuration = 6f;

    public bool hasFastAttack = false;
    private float originalAttackCooldown;
    public GameObject fastAttackAbilityEffect;
    public GameObject fastAttacTxt;

    public bool hasSuperSpeed = false;
    private float originalSpeed;
    public GameObject superSpeedEffect;
    public GameObject superSpeedTxt;

    
    private PlayerAttack playerAttack;
    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerAttack = GetComponent<PlayerAttack>();
        playerMovement = GetComponent<PlayerMovement>();
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
                fastAttackAbilityEffect.SetActive(true);
                fastAttacTxt.SetActive(true);
                originalAttackCooldown = playerAttack.attackCooldown;
                playerAttack.attackCooldown /= 2f;
                Debug.Log("Ability activated: FastAttack");
                StartCoroutine(DeactivateFastAttackAfterDuration());
                break;

            case "SuperSpeed":
                hasSuperSpeed = true;
                superSpeedEffect.SetActive(true);
                superSpeedTxt.SetActive(true);
                originalSpeed = playerMovement.movementSpeed;
                playerMovement.movementSpeed *= 1.5f;
                Debug.Log("Ability activated: SuperSpeed");
                StartCoroutine(DeactivateSuperSpeedAfterDuration());
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
            fastAttackAbilityEffect.transform.DOScale(0, 0.5f).OnComplete(delegate
            {
                fastAttackAbilityEffect.SetActive(false);
            });
        }

        if (superSpeedEffect != null)
        {
            superSpeedEffect.transform.DOScale(0, 0.5f).OnComplete(delegate
            {
                superSpeedEffect.SetActive(false);
            });
        }
    }

    private IEnumerator DeactivateFastAttackAfterDuration()
    {
        yield return new WaitForSeconds(abilityDuration);
        hasFastAttack = false;
        fastAttacTxt.SetActive(false);
        playerAttack.attackCooldown = originalAttackCooldown; 
        Debug.Log("FastAttack ability deactivated!");
    }

    private IEnumerator DeactivateSuperSpeedAfterDuration()
    {
        yield return new WaitForSeconds(abilityDuration);
        hasSuperSpeed = false;
        superSpeedTxt.SetActive(false);
        playerMovement.movementSpeed = originalSpeed;
        Debug.Log("SuperSpeed is deactivated!");

    }
}
