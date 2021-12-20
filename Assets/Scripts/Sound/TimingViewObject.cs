using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TimingViewObject : MonoBehaviour
{
    Object timingBar_;          // �^�C�~���O��\��Bar
    Vector3 downPosition_;       // �ォ��\��
    Vector3 upPosition_;         // ������\��
    Vector3 scale_;              // ��{�I�ȑ傫��

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
        // ���߂ɗ����t���[���� true �ɂȂ�
        if (Music.IsJustChangedBar())
        {
        }

        // ���ɗ����t���[���� true �ɂȂ�
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
