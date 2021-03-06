using System.Collections;
using System.Collections.Generic;
using System;//Actionを使うため
using UnityEngine;
using DG.Tweening;//DOTweenを使用するため

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AnimationCurve CustomEasing;
    [SerializeField] private GameObject ShotObj;

    [SerializeField] private Vector3 ClickPos;

    Tweener tweener;//DOTweenの情報を入れる

    public enum StatusType
    {
        HP = 0, Atk, Def, Spd
    }//列挙型enum

    public static int GetTypeNum<T>()
    {
        return Enum.GetValues(typeof(T)).Length;//列挙型の項目数を取得する
    }
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
        //transform.DOLocalMove(new Vector3(10,0,0),1f).OnComplete(CompleteFunction);//トゥイーン完了時にCompleteFunction()を呼び出す
        Test1 test1 = new Test1();
        test1.Method();

        //https://kan-kikuchi.hatenablog.com/entry/List_Lambda
        var list = new List<string> {
            "a", "aa", "aaa", "aaaa",
            "b", "bb", "bbb", "bbbb",
            "c", "cc", "ccc", "cccc"
            };

        //4文字以上の文字列はあるか
        var exists4Length = list.Exists(s => s.Length >= 4); //4文字以上の文字列があるのでTrue
        Debug.Log(exists4Length);
        var exists5Length = list.Exists(s => s.Length >= 5); //5文字以上の文字列があるのでfalse
        Debug.Log(exists5Length);
        //2文字の文字列を全て取得
        List<string> twoLengthTextList = list.FindAll(s => s.Length == 2); //aaとbbとccが入ったListを取得
        Debug.Log(twoLengthTextList);
        List<string> threeLengthTextList = list.FindAll(s => s.Length >= 3);//3文字以上の文字列取得
        Debug.Log(threeLengthTextList);
        for (int i = 0; i < threeLengthTextList.Count; i++)
        {
            Debug.Log(threeLengthTextList[i]);
        }

        Debug.Log(Test.GetTypeNum<Test.StatusType>());//指定の仕方が特殊

        //リストを作成
        List<int> numlist = new List<int>() { 1, 2, 3 };

        //中身を列挙
        foreach (int num in numlist)
        {
            print(num);
        }

        //反転
        print("反転");
        numlist.Reverse();

        //反転した中身を列挙
        foreach (int num in numlist)
        {
            print(num);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space!!");
            //StartCoroutine("StartMove");
            //StartCoroutine("Rewind");
            //StartCoroutine("StartMove2");
            //StartCoroutine("RelativeMove");
            //StartCoroutine("SequenceMove");
            //StartCoroutine("PunchMove");
            //StartCoroutine("DOPathMove");
            //StartCoroutine("Back");
            //StartCoroutine("Jump");
            //StartCoroutine("Move");
            //StartCoroutine("Virtual");
            //StartCoroutine("CustomMove");
            //RoundTrip_Right();
            //StartCoroutine("IDStart");
            Summon();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine("DelayMove");
        }

        if (Input.GetMouseButtonDown(0))
        {//クリックした座標に移動する
            ClickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//スクリーンの座標からワールド座標へ変換する
            ClickPos.z = 0;//z座標を0にする(カメラは―10なので)
            tweener = transform.DOLocalMove(ClickPos, 1f);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            tweener.Pause();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            tweener.Play();
        }

    }

    //https://kan-kikuchi.hatenablog.com/entry/Delegate
    //delegate処理の参考
    //https://kan-kikuchi.hatenablog.com/entry/FirstLINQ
    //こっちもいつか試す
    public class Test1
    {
        public void Method()
        {
            Test2 test2 = new Test2();

            /*Test2.Delegate delegateMethod = CallBack;//Callback関数を渡している
            delegateMethod += CallBack2;
            delegateMethod += CallBack3;
            test2.Method(delegateMethod);*/

            test2.CallBack += () => Debug.Log("処理終了");
            test2.Method();
        }

        //Action delegateMethod = () => Debug.Log("処理終了");
        public void CallBack()
        {
            Debug.Log("CallBack処理終了");
        }
        public void CallBack2()
        {
            Debug.Log("CallBack2終了");
        }
        public void CallBack3()
        {
            Debug.Log("CallBack3終了");
        }
    }
    public class Test2
    {
        //public delegate void Delegate();
        public event Action CallBack = null;
        /* public void Method(Delegate delegateMethod){//渡された関数を実行する
             Debug.Log("Method");

             delegateMethod();
         }*/
        public void Method()
        {
            Debug.Log("Method");
            if (CallBack != null)
            {
                CallBack();
            }
        }
    }


    void Summon()
    {
        GameObject Slime = Instantiate(ShotObj) as GameObject;
        Slime.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
    }

    IEnumerator DelayMove()
    {
        Debug.Log("Delay");
        var tween = DOVirtual.DelayedCall(2f,
        () => gameObject.SetActive(false));

        yield return new WaitForSeconds(3f);
        //tween.Kill();
    }

    IEnumerator IDStart()
    {
        transform.DOLocalMoveX(10f, 10f);
        var tween1 = transform.DOScale(5f, 3f);
        var tween2 = transform.DOLocalRotateQuaternion(
            Quaternion.AngleAxis(540, Vector3.up), 0.5f)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Incremental);
        yield return new WaitForSeconds(1f);

        tween1.Kill();
        yield return new WaitForSeconds(1f);
        tween2.Kill();
    }

    public void RoundTrip_Right()
    {
        transform.DOLocalMove(new Vector3(10f, 0, 0), 1f).OnComplete(RoundTrip_Left);

    }
    public void RoundTrip_Left()
    {
        transform.DOLocalMove(new Vector3(-10f, 0, 0), 1f).OnComplete(RoundTrip_Right);
    }
    IEnumerator CustomMove()
    {
        transform.DOLocalMove(new Vector3(10f, 0, 0), 2f).SetEase(CustomEasing);
        yield return null;
    }

    IEnumerator Virtual()
    {
        var tween = DOVirtual.DelayedCall(0.2f,
        () => gameObject.SetActive(false));
        yield return new WaitForSeconds(0.1f);
        tween.Kill();//非アクティブにするしょりを先に止めている
    }


    IEnumerator Move()
    {
        transform.DOLocalMove(new Vector3(10f, 0, 0), 1f).From(new Vector3(0f, 0, 0)).SetDelay(0.1f);//Fromで開始地点を設定することができる//setdelayは待機時間
        yield return null;
    }

    IEnumerator Jump()
    {
        //transform.DOLocalJump(new Vector3(10f,0,0),1f,3,1f).SetEase(Ease.Linear);
        transform.DOLocalJump(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), 2f, 3, 1f).SetEase(Ease.Linear);//その場で3回跳ねる
        yield return null;
    }

    IEnumerator Back()
    {
        yield return transform.DOLocalMove(new Vector3(10f, 0, 0), 1.5f).WaitForCompletion();

        yield return transform.DOLocalMove(new Vector3(0f, 0, 0), 1.5f).WaitForCompletion();

        DOTween.Sequence().Append(transform.DOLocalMoveX(10f, 1f))
        .Append(transform.DOLocalMoveY(1f, 1f))
        .Append(transform.DOLocalMoveX(5f, 1f))
        .Append(transform.DOScale(3.5f, 0.3f))
        .Insert(0.1f, transform.DOScale(1f, 2f));
    }

    IEnumerator DOPathMove()
    {
        transform.DOLocalPath(
            new[]
             {
                 new Vector3(-3f,-2f,0f),
                 new Vector3(3f,-2f,0f),
                 new Vector3(0f,5f,0f),
             },
             3f, PathType.CatmullRom).SetOptions(true);//SetOptions(true)とすることで開始した座標に戻る

        yield return null;
    }

    IEnumerator StartMove()
    {
        //transform.DOLocalMove(new Vector3(10f,0,0),1f).SetLoops(-1,LoopType.Yoyo);
        /*yield return new WaitForSeconds(0.5f);

        transform.DOPause();//一時停止

        yield return new WaitForSeconds(0.5f);

        transform.DOPlay();//再開*/
        transform.DOLocalMove(new Vector3(10f, 0, 0), 1f).SetDelay(0.5f);
        yield return new WaitForSeconds(1f);
        transform.DORestart();//最初からやり直す
        //完了したトゥイーンはやり直せないため、この例だと1回のみやり直す

    }

    IEnumerator PunchMove()
    {
        //移動場所/時間/振動数/振動する範囲
        transform.DOPunchPosition(new Vector3(5f, 0, 0), 2f, 5, 1f);
        transform.DOPunchScale(Vector3.one * 2f, 2f, 5, 1f);
        yield return null;
    }

    IEnumerator StartMove2()
    {
        transform.DOLocalMoveX(10f, 4f);
        yield return new WaitForSeconds(1);
        transform.DOComplete();//即完了状態にする
    }

    IEnumerator RelativeMove()
    {
        transform.DOLocalMove(new Vector3(1, 1, 0), 1f).SetRelative(true);//相対座標で指定して移動する
        yield return null;
    }

    IEnumerator Rewind()
    {
        transform.DOLocalMoveX(10f, 1f);
        yield return new WaitForSeconds(0.5f);

        transform.DORewind();//最初の状態に戻ってからポーズする

        yield return new WaitForSeconds(0.5f);

        transform.DOPlay();//再開する

    }

    IEnumerator SequenceMove()
    {//一つのグループにまとめて順番に処理する
        DOTween.Sequence()
        .Append(transform.DOLocalMoveX(10f, 1f))
        .Append(transform.DOLocalMoveY(1f, 1f))
        .Append(transform.DOLocalMoveX(5f, 1f))
        .Append(transform.DOLocalMoveY(3.5f, 0.3f));

        yield return null;
    }
    private void CompleteFunction()
    {
        Debug.Log("Complete!!!!");
    }
}
