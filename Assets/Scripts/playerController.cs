using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    Vector3 MOVEX = new Vector3(1.5f, 0, 0); // x�������ɂP�}�X�ړ�����Ƃ��̋���
    Vector3 MOVEY = new Vector3(0, 1.5f, 0); // y�������ɂP�}�X�ړ�����Ƃ��̋���

    float step = 10f;     // �ړ����x
    Vector3 target;      // ���͎�t���A�ړ���̈ʒu���Z�o���ĕۑ� 
    Vector3 prevPos;     // ���炩�̗��R�ňړ��ł��Ȃ������ꍇ�A���̈ʒu�ɖ߂����߈ړ��O�̈ʒu��ۑ�
	bool upushFlag = false;
	bool dpushFlag = false;
	bool lpushFlag = false;
	bool rpushFlag = false;

	Animator animator;   // �A�j���[�V����

    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
	{
        //�@ �ړ������ǂ����̔���B�ړ����łȂ���Γ��͂���t
		if (transform.position == target)
		{
			SetTargetPosition();
		}
		Move();
	}

	// �A ���͂ɉ����Ĉړ���̈ʒu���Z�o
	void SetTargetPosition()
	{

		prevPos = target;

		if (Input.GetKey(KeyCode.RightArrow))
		{
			if (rpushFlag == false)  // �������ςȂ��ł͂Ȃ��Ƃ�
			{
				rpushFlag = true;    // ������Ԃɂ���
				target = transform.position + MOVEX;
				//SetAnimationParam(1);			
			}
		}
		else
		{
			rpushFlag = false;    
		}

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			if (lpushFlag == false)  // �������ςȂ��ł͂Ȃ��Ƃ�
			{
				lpushFlag = true;    // ������Ԃɂ���
				target = transform.position - MOVEX;
				//SetAnimationParam(2);
			}
		}
		else
		{
			lpushFlag = false;
		}

		if (Input.GetKey(KeyCode.UpArrow))
		{
			if (upushFlag == false)  // �������ςȂ��ł͂Ȃ��Ƃ�
			{
				upushFlag = true;    // ������Ԃɂ���
				target = transform.position + MOVEY;
				//SetAnimationParam(3);
			}
		}
		else
		{
			upushFlag = false;
		}

		if (Input.GetKey(KeyCode.DownArrow))
		{
			if (dpushFlag == false)  // �������ςȂ��ł͂Ȃ��Ƃ�
			{
				dpushFlag = true;    // ������Ԃɂ���
				target = transform.position - MOVEY;
				//SetAnimationParam(0);
			}
		}
		else
		{
			dpushFlag = false;
		}
	}

	// WalkParam  0;���ړ��@1;�E�ړ��@2:���ړ��@3:��ړ�
	void SetAnimationParam(int param)
	{
		animator.SetInteger("WalkParam", param);
	}

	// �B �ړI�n�ֈړ�����
	void Move()
	{
		transform.position = Vector3.MoveTowards(transform.position, target, step * Time.deltaTime);
	}
}
