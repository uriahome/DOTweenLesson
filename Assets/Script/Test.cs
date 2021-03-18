using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;//DOTweenを使用するため

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("test");
        //transform.DOLocalMove(new Vector3(10f,0,0),1f);//1秒掛けて10,0,0に移動する(絶対位置)
        //transform.DOMove(new Vector3(10f,0,0),1f);//1秒掛けて10,0,0に移動する(絶対位置)
        //transform.DOLocalMove(new Vector3(10f,0,0),1f).SetEase(Ease.InOutQuart);//加速して減速する
        //transform.DOLocalMove(new Vector3(10f,0,0),1f).SetEase(Ease.InOutQuart).SetDelay(2f);//2秒待機してから開始する
        //transform.DOLocalMove(new Vector3(10f,0,0),1f).SetEase(Ease.InOutQuart).SetLoops(10,LoopType.Yoyo);//10回繰り返す(行き来する)(計5往復)
        //transform.DOLocalMove(new Vector3(10f,0,0),1f).SetEase(Ease.InOutQuart).SetLoops(10,LoopType.Restart);//10回繰り返す(最初の状態に戻る)
        //transform.DOLocalMove(new Vector3(10f,0,0),1f).SetEase(Ease.InOutQuart).SetLoops(10,LoopType.Incremental);//10回繰り返す(その場で続きを開始する(加算する))
        //transform.DOLocalMove(new Vector3(10f,0,0),1f).SetEase(Ease.InOutQuart).SetLoops(-1,LoopType.Yoyo);//-1で無限に繰り返す
        transform.DOLocalMove(new Vector3(10,0,0),1f).OnComplete(CompleteFunction);//トゥイーン完了時にCompleteFunction()を呼び出す
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("Space!!");
            //StartCoroutine("StartMove");
            StartCoroutine("Rewind");
        }

    }

    IEnumerator StartMove(){
        //transform.DOLocalMove(new Vector3(10f,0,0),1f).SetLoops(-1,LoopType.Yoyo);
        /*yield return new WaitForSeconds(0.5f);

        transform.DOPause();//一時停止

        yield return new WaitForSeconds(0.5f);

        transform.DOPlay();//再開*/
        transform.DOLocalMove(new Vector3(10f,0,0),1f).SetDelay(0.5f);
        yield return new WaitForSeconds(1f);
        transform.DORestart();//最初からやり直す
        //完了したトゥイーンはやり直せないため、この例だと1回のみやり直す

    }

    IEnumerator Rewind(){
        transform.DOLocalMoveX(10f,1f);
        yield return new WaitForSeconds(0.5f);

        transform.DORewind();//最初の状態に戻ってからポーズする
        
        yield return new WaitForSeconds(0.5f);

        transform.DOPlay();//再開する

    }
    private void CompleteFunction(){
        Debug.Log("Complete!!!!");
    }
}
