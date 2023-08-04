using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; 

public class PickUp : MonoBehaviour
{
    [SerializeField] GameObject ring;
    public float abilityDuration = 10f; 
    public string abilityName = "FastAttack";

    private void Awake()
    {
        
    }
    void Start()
    {
        PickUpAnimation();
    }

    
    void Update()
    {
        
    }

    void PickUpAnimation()
    {
        transform.DORotate(new Vector3(0f, 360f, 0f), 1f, RotateMode.FastBeyond360)
        .SetLoops(-1, LoopType.Restart)
        .SetRelative()
        .SetEase(Ease.Linear);

        ring.transform.DORotate(new Vector3(360f,0f,0f),1f,RotateMode.FastBeyond360)
        .SetLoops(-1, LoopType.Restart)
        .SetRelative()
        .SetEase(Ease.Linear);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            transform.DOScale(0, 0.5f).OnComplete(delegate
            {
                Destroy(gameObject);
            });

            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.ActivateAbility(abilityName, abilityDuration);
            }
        }
    }

    

}
