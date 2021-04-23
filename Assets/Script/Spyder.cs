 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;//DOTweenを使用するため

public class Spyder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        /*var Seq = DOTween.Sequence();
        Seq.Append(transform.DOLocalMoveX(5f,1f));
        Seq.Append(transform.DOLocalMoveY(2f,1f));
        Seq.Join(transform.DOScale(2.5f,0.3f));
        Seq.Append(transform.DOLocalMoveX(0f,1f));
        Seq.Join(transform.DOScale(1f,0.3f));
        */
         
        //transform.DOLocalMove(new Vector3(this.transform.position.x+3f,0,0),2f).From(new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z)).OnComplete(Move);

        transform.DOLocalPath(new Vector3[]{//カーブしながら各点を移動する
            new Vector3(8f,-1.5f,0f),
            new Vector3(5f,1.5f,0f),
            new Vector3(-1f,3f,0f)
        },3f,PathType.CatmullRom);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Move(){
        transform.DOLocalMove(new Vector3(this.transform.position.x+3f,0,0),2f).From(new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z)).OnComplete(Move);
    }
}
