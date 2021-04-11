using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;//DOTweenを使用するため

public class Shot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOLocalMove(new Vector3(10f,0,0),1f).SetRelative(true).OnComplete(Finish);//相対位置で移動する。完了した場合Finish()を実行する
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Finish(){
        Destroy(this.gameObject);//自身の削除
    }
}
