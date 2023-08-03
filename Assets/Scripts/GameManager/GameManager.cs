using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pickUp;
    public GameObject pickUpEffect;
    
    void Start()
    {
        
        StartCoroutine(PickUpSpawn());
    }

    // Update is called once per frame
    void Update()
    {
          
    }

    void RandomPosForPickUp()
    {
        float randomX = Random.Range(-7f, 7f);
        float randomY = .56f;
        float randomZ = Random.Range(-7f, 7f);

        Vector3  randomPos = new Vector3(randomX, randomY, randomZ);
        pickUp.transform.position = randomPos;
    }

    IEnumerator PickUpSpawn()
    {
        RandomPosForPickUp();
        float offsetY = -.40f;
        Vector3 pickUpEffectPos = new Vector3(pickUp.transform.position.x, pickUp.transform.position.y + offsetY, pickUp.transform.position.z);
        pickUpEffect.transform.position = pickUpEffectPos;
        Instantiate(pickUpEffect, pickUpEffect.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(pickUp, pickUp.transform.position, pickUp.transform.rotation);
        
    }

    

}
