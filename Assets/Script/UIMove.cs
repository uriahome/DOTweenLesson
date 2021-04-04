using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;//DOTweenを使用するため
using UnityEngine.UI;

public class UIMove : MonoBehaviour
{
    //RectTransform target;
    Image target;
    // Start is called before the first frame update
    void Start()
    {
        //target = gameObject.GetComponent<RectTransform>();
        //target.DOAnchorPos(new Vector2(240f,0),0.6f).SetEase(Ease.OutBack);//移動
        //target.DOLocalRotate(new Vector3(360f,0,0),0.6f,RotateMode.FastBeyond360).SetEase(Ease.OutCubic);//回転
        //target.localScale = Vector3.one * 0.2f;
        //target.DOScale(1f,0.6f).SetEase(Ease.OutBack,5f);//拡大
        target = gameObject.GetComponent<Image>();
        //target.DOColor(new Color(1f, 0, 0), 1.5f);
        //target.DOFade(0.2f,1.5f);
        target.DOFillAmount(1f,2f).SetEase(Ease.InQuart);
        target.DOBlendableColor(new Color(0f,1f,1f),2f);
        target.DOBlendableColor(new Color(1f,1f,0f),1f).SetDelay(3f);
        target.DOBlendableColor(new Color(1f,0f,1f),1f).SetDelay(4f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
