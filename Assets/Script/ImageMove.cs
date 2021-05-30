using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ImageMove : MonoBehaviour
{
    [SerializeField] GameObject Bikkuri;
    [SerializeField] RectTransform RBikkuri;
    [SerializeField] Image BikkuriImage;
    // Start is called before the first frame update
    void Start()
    {
        RBikkuri = Bikkuri.GetComponent<RectTransform>();
       /* DOTween.Sequence().Append(BikkuriImage.DOFade(0.1f, 0.95f))
        .Join(Bikkuri.transform.DOScale(1.2f,1.0f))
        .Join(RBikkuri.DOJumpAnchorPos(new Vector3(0,0,0),50f,1,1f))
        .SetLoops(-1,LoopType.Restart);//拡大と透過とジャンプを繰り返す*/

        /*DOTween.Sequence().Append(Bikkuri.transform.DOScale(1.2f,1.0f))
        .Join(RBikkuri.DOJumpAnchorPos(new Vector3(0,0,0),50f,1,1f))
        .SetLoops(-1,LoopType.Restart);//拡大とジャンプを繰り返す*/
        
        
        DOTween.Sequence().Append(Bikkuri.transform.DOLocalRotate(new Vector3(0, 0, 40f), 1.0f,RotateMode.Fast))
        .Append(Bikkuri.transform.DOLocalRotate(new Vector3(0, 0, -40f), 1.0f,RotateMode.Fast))
        .OnComplete(Rotate);
        //.SetLoops(-1,LoopType.Restart);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Rotate(){
        DOTween.Sequence().Append(Bikkuri.transform.DOLocalRotate(new Vector3(0, 0, 40f), 1.0f,RotateMode.Fast))
        .Append(Bikkuri.transform.DOLocalRotate(new Vector3(0, 0, -40f), 1.0f,RotateMode.Fast))
        .OnComplete(Rotate);
    }
}
