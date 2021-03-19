using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;//DOTweenを使用するため

public class UIMove : MonoBehaviour
{
    RectTransform target;
    // Start is called before the first frame update
    void Start()
    {
        target = gameObject.GetComponent<RectTransform>();
        target.DOAnchorPos(new Vector2(240f,0),0.6f).SetEase(Ease.OutBack);//移動
        target.DOLocalRotate(new Vector3(360f,0,0),0.6f,RotateMode.FastBeyond360).SetEase(Ease.OutCubic);//回転
        target.localScale = Vector3.one * 0.2f;
        target.DOScale(1f,0.6f).SetEase(Ease.OutBack,5f);//拡大

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
