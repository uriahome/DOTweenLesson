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

    [SerializeField] Vector3 centerPos = Vector3.zero;
    [SerializeField] Vector3 axisPos;
    [SerializeField] float period = 2f;
    [SerializeField] Rigidbody2D rb2D;

    void Start()
    {
        MoveCount = 0;
        ChangeMoveFlag = false;
        SpanTime = 1.0f;
        rb2D = this.gameObject.GetComponent<Rigidbody2D>();
        //StartCoroutine("ChangeMove");
        //Move();
        RigidMove();
    }

    // Update is called once per frame
    void Update()
    {
        //CircleMove();
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

    void RigidMove(){
        MoveCount++;
        if(MoveCount%3 ==2){
            ChangeMoveFlag = !ChangeMoveFlag;
        }
        Debug.Log("Move!!");
        if(ChangeMoveFlag){
            DOTween.Sequence().Append(rb2D.DOMove(new Vector3(5,-5,0),SpanTime))
            .Append(rb2D.DOMove(new Vector3(8,0,0),SpanTime))
            .Append(rb2D.DOMove(new Vector3(5,5,0),SpanTime))
            .OnComplete(RigidMove);
        }else{
            DOTween.Sequence().Append(rb2D.DOMove(new Vector3(8,0,0),SpanTime))
            .Append(rb2D.DOMove(new Vector3(5,-5,0),SpanTime))
            .Append(rb2D.DOMove(new Vector3(5,5,0),SpanTime))
            .OnComplete(RigidMove);
        }
    }

    void CircleMove(){
        var angleAxis = Quaternion.AngleAxis(360/period*Time.deltaTime,axisPos);

        var pos = transform.position;

        pos -= centerPos;
        pos = angleAxis * pos;
        pos += centerPos;

        this.transform.position = pos;

    }

    IEnumerator ChangeMove(){
        yield return new WaitForSeconds(5*SpanTime);
        ChangeMoveFlag = !ChangeMoveFlag;
        SpanTime *= 0.8f;//だんだん速くなる表現
        StartCoroutine("ChangeMove");
    }
}
