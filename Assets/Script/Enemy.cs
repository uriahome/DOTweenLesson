using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;//DOTweenを使用するため

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] bool ChangeMoveFlag;
    [SerializeField] float SpanTime;
    [SerializeField] int MoveCount;
    void Start()
    {
        MoveCount = 0;
        ChangeMoveFlag = false;
        SpanTime = 1.0f;
        //StartCoroutine("ChangeMove");
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Move(){
        MoveCount++;
        if(MoveCount%3 ==2){
            ChangeMoveFlag = !ChangeMoveFlag;
        }
        Debug.Log("Move!!");
        if(ChangeMoveFlag){
            DOTween.Sequence().Append(transform.DOLocalMove(new Vector3(5,-5,0),SpanTime))
            .Append(transform.DOLocalMove(new Vector3(8,0,0),SpanTime))
            .Append(transform.DOLocalMove(new Vector3(5,5,0),SpanTime))
            .OnComplete(Move);
        }else{
            DOTween.Sequence().Append(transform.DOLocalMove(new Vector3(8,0,0),SpanTime))
            .Append(transform.DOLocalMove(new Vector3(5,-5,0),SpanTime))
            .Append(transform.DOLocalMove(new Vector3(5,5,0),SpanTime))
            .OnComplete(Move);
        }
    }

    IEnumerator ChangeMove(){
        yield return new WaitForSeconds(5*SpanTime);
        ChangeMoveFlag = !ChangeMoveFlag;
        SpanTime *= 0.8f;//だんだん速くなる表現
        StartCoroutine("ChangeMove");
    }
}
