 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;//DOTweenを使用するため

public class Spyder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        var Seq = DOTween.Sequence();
        Seq.Append(transform.DOLocalMoveX(5f,1f));
        Seq.Append(transform.DOLocalMoveY(2f,1f));
        Seq.Join(transform.DOScale(2.5f,0.3f));
        Seq.Append(transform.DOLocalMoveX(0f,1f));
        Seq.Join(transform.DOScale(1f,0.3f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
