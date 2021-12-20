using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TimingViewObject : MonoBehaviour
{
    Object timingBar_;          // タイミングを表すBar
    Vector3 downPosition_;       // 上から表示
    Vector3 upPosition_;         // 下から表示
    Vector3 scale_;              // 基本的な大きさ

    // Start is called before the first frame update
    void Start()
    {
        timingBar_ = Resources.Load("Sound/BeatBar");
        downPosition_ = new Vector3(777,60,0);
        upPosition_ = new Vector3(777, -500, 0);
        scale_ = new Vector3(16,10,0);
    }

    // Update is called once per frame
    void Update()
    {
        // 小節に来たフレームで true になる
        if (Music.IsJustChangedBar())
        {
        }

        // 拍に来たフレームで true になる
        if (Music.IsJustChangedBeat())
        {
            CreateMoveUpBeatBar();
            CreateMoveDownBeatBar();
        }
    }
    
    private void CreateMoveUpBeatBar()
    {
        var upBar = Instantiate(timingBar_,upPosition_,Quaternion.identity) as GameObject;
        upBar.transform.localScale = scale_;
        
    }
    private void CreateMoveDownBeatBar()
    {
        var downBar = Instantiate(timingBar_, downPosition_, Quaternion.identity) as GameObject;
        downBar.transform.localScale = scale_;

    }
}
