using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PickUpEffect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            transform.DOScale(0, .5f).OnComplete(delegate
            {
                Destroy(gameObject);
            });
        }
    }
}
