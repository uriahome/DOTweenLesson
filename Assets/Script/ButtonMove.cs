using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonMove : MonoBehaviour
{
    // Start is called before the first frame update
    public bool IsClick;
    void Start()
    {
        IsClick = false;
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClick()
    {
        //DOTween.Sequence().Append(transform.DOScale(1.3f,0.5f).SetEase(Ease.OutElastic))
        //.Append(transform.DOScale(0.8f,0.5f).SetEase(Ease.OutElastic));
        //transform.DOScale(1.2f,0.5f).SetEase(Ease.OutElastic).SetLoops(-1,LoopType.Yoyo);
        //transform.DOScale(1.2f,0.5f).SetEase(Ease.OutElastic).SetLoops(-1,LoopType.Restart);
        if(IsClick){
            transform.DOScale(1.0f,0.5f).SetEase(Ease.OutElastic);//縮小
            GetComponentInChildren<Text>().text = "小さい";
        }else{
            transform.DOScale(1.4f,0.5f).SetEase(Ease.OutElastic);//巨大化
            GetComponentInChildren<Text>().text = "大きい";
        }
        IsClick = !IsClick;//bool反転ですっきりさせた
    }
}
