using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; 

public class PickUp : MonoBehaviour
{
    [SerializeField] GameObject ring;
    void Start()
    {
        PickUpAnimation();
    }

    // Update is called once per frame
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
}
