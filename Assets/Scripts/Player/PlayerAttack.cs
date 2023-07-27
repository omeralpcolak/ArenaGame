using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletSpawnPoint1, bulletSpawnpoint2;
    public float attackCooldown;

    private void Start()
    {
        StartCoroutine(AttackRoutine());
    }


    IEnumerator AttackRoutine()
    {
        Vector3 playerFacingDirection = transform.forward;
        Instantiate(bullet, bulletSpawnPoint1.position, Quaternion.LookRotation(playerFacingDirection));
        Instantiate(bullet, bulletSpawnpoint2.position, Quaternion.LookRotation(playerFacingDirection));
        yield return new WaitForSeconds(attackCooldown);
        StartCoroutine(AttackRoutine());
    }
}
