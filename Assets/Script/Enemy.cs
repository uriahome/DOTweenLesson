using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;//DOTweenを使用するため

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] bool ChangeMoveFlag;
    void Start()
    {
        ChangeMoveFlag = false;
        StartCoroutine("ChangeMove");
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Move(){
        Debug.Log("Move!!");
        if(ChangeMoveFlag){
            DOTween.Sequence().Append(transform.DOLocalMove(new Vector3(5,-5,0),1f))
            .Append(transform.DOLocalMove(new Vector3(8,0,0),1f))
            .Append(transform.DOLocalMove(new Vector3(5,5,0),1f))
            .OnComplete(Move);
        }else{
            DOTween.Sequence().Append(transform.DOLocalMove(new Vector3(5,5,0),1f))
            .Append(transform.DOLocalMove(new Vector3(8,0,0),1f))
            .Append(transform.DOLocalMove(new Vector3(5,-5,0),1f))
            .OnComplete(Move);
        }
    }

    IEnumerator ChangeMove(){
        yield return new WaitForSeconds(5f);
        ChangeMoveFlag = !ChangeMoveFlag;
        StartCoroutine("ChangeMove");
    }
}
