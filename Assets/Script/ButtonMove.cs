using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
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
        transform.DOScale(1.2f,0.5f).SetEase(Ease.OutElastic).SetLoops(-1,LoopType.Restart);
    }
}
