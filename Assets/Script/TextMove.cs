using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;//DOTweenを使用するため
using UnityEngine.UI;//UIをいじるため

public class TextMove : MonoBehaviour
{

    Text TargetText;
    // Start is called before the first frame update
    void Start()
    {
        TargetText = gameObject.GetComponent<Text>();
        TargetText.DOText("1234567890",1f, scrambleMode :ScrambleMode.All);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            //TargetText.DOText("うりあの魔導書",1f, scrambleMode :ScrambleMode.All);
            TargetText.DOCounter(1,1000,1.5f,true);//trueにすると3桁区切りでカンマを挿入する
        }
    }
}
