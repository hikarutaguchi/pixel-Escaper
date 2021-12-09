using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class playerController : MonoBehaviour
{
	Vector3 MOVEX = new Vector3(1.0f, 0, 0); // x軸方向に１マス移動するときの距離
	Vector3 MOVEY = new Vector3(0, 1.0f, 0); // y軸方向に１マス移動するときの距離

	/// <summary>
	/// タイルマップデータ
	/// </summary>
	[SerializeField] private GameObject tileMap;

	float step = 10f;     // 移動速度
	Vector3 target;      // 入力受付時、移動後の位置を算出して保存 
	Vector3 prevPos;     // 何らかの理由で移動できなかった場合、元の位置に戻すため移動前の位置を保存
	bool upushFlag = false;
	bool dpushFlag = false;
	bool lpushFlag = false;
	bool rpushFlag = false;

	Animator animator;   // アニメーション

	private void Awake()
	{
		target = transform.position;
		var tilemap = tileMap.GetComponent<Tilemap>();
		var position = new Vector3Int(-4, 0, 0);
		target = new Vector3(tilemap.GetCellCenterLocal(position).x, tilemap.GetCellCenterLocal(position).y, 0);
	}

	// Start is called before the first frame update
	void Start()
	{
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		//① 移動中かどうかの判定。移動中でなければ入力を受付
		if (transform.position == target)
		{
			SetTargetPosition();
		}
		Move();
	}

	// ② 入力に応じて移動後の位置を算出
	void SetTargetPosition()
	{

		prevPos = target;

		if (Input.GetKey(KeyCode.RightArrow))
		{
			if (rpushFlag == false)  // 押しっぱなしではないとき
			{
				rpushFlag = true;    // 押し状態にする
				target = transform.position + MOVEX;
				SetAnimationParam(1);
			}
		}
		else
		{
			rpushFlag = false;
		}

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			if (lpushFlag == false)  // 押しっぱなしではないとき
			{
				lpushFlag = true;    // 押し状態にする
				target = transform.position - MOVEX;
				SetAnimationParam(2);
			}
		}
		else
		{
			lpushFlag = false;
		}

		if (Input.GetKey(KeyCode.UpArrow))
		{
			if (upushFlag == false)  // 押しっぱなしではないとき
			{
				upushFlag = true;    // 押し状態にする
				target = transform.position + MOVEY;
				SetAnimationParam(3);
			}
		}
		else
		{
			upushFlag = false;
		}

		if (Input.GetKey(KeyCode.DownArrow))
		{
			if (dpushFlag == false)  // 押しっぱなしではないとき
			{
				dpushFlag = true;    // 押し状態にする
				target = transform.position - MOVEY;
				SetAnimationParam(0);
			}
		}
		else
		{
			dpushFlag = false;
		}
		if(target.x > -1 || target.x < -6 || target.y > 3 || target.y < -2)
        {
			target = prevPos;
		}
	}

	// WalkParam  0;下移動　1;右移動　2:左移動　3:上移動
	void SetAnimationParam(int param)
	{
		animator.SetTrigger("WorkFlag");
		//animator.SetInteger("WalkParam", param);
	}

	// ③ 目的地へ移動する
	void Move()
	{
		transform.position = Vector3.MoveTowards(transform.position, target, step * Time.deltaTime);
	}
}
