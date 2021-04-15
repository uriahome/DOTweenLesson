using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;//DOTweenを使用するため

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Move(){
        Debug.Log("Move!!");
        DOTween.Sequence().Append(transform.DOLocalMove(new Vector3(5,5,0),1f))
        .Append(transform.DOLocalMove(new Vector3(8,0,0),1f))
        .Append(transform.DOLocalMove(new Vector3(5,-5,0),1f))
        .OnComplete(Move);
    }
}
