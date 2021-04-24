using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonMove : MonoBehaviour
{
    // Start is called before the first frame update
    public bool IsClick;
    Button button;

    string CheckChar = "a";
    public string TestChar = "a";
    void Start()
    {
        IsClick = false;
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
        if(TestChar.Contains(CheckChar)){
            Debug.Log("aaa");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnClick()
    {
        //DOTween.Sequence().Append(transform.DOScale(1.3f,0.5f).SetEase(Ease.OutElastic))
        //.Append(transform.DOScale(0.8f,0.5f).SetEase(Ease.OutElastic));
        transform.DOScale(1.2f,0.5f).SetEase(Ease.OutElastic).SetLoops(-1,LoopType.Yoyo);//拡大縮小を繰り返す
        //transform.DOScale(1.2f,0.5f).SetEase(Ease.OutElastic).SetLoops(-1,LoopType.Restart);


        /*if (IsClick)
        {
            transform.DOScale(1.0f, 0.5f).SetEase(Ease.OutElastic);//縮小
            GetComponentInChildren<Text>().text = "小さい";
        }
        else
        {
            transform.DOScale(1.4f, 0.5f).SetEase(Ease.OutElastic);//巨大化
            GetComponentInChildren<Text>().text = "大きい";
        }
        IsClick = !IsClick;//bool反転ですっきりさせた
        */
    }

}
