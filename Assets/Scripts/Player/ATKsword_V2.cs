using UnityEngine;
using System.Collections;

public class ATKsword_V2 : MonoBehaviour
{
	private Animator anim;//获取人物
	private AnimatorStateInfo animStateInfo;//获取动画状态信息
	private const string IdleState = "Idle";//获取默认动作
	private const string Attack1State = "Atk01_sword";//获取攻击1
	private const string Attack2State = "Atk02_sword";//获取攻击2
	private const string Attack3State = "Atk03_sword";//获取攻击3
	private const float skillTime = 0.8f; // 接技總時間
	private const float changeTime = 0.2f; // 攻擊間格
	private float sTime = 0; // 技能間隔
	private float tTime = 0; // 連技計時
	private int hitCount = 0;  // 当前连击数（即 玩家按下攻击键的次数） 
	
	void Start()
	{
		anim = this.gameObject.GetComponent<Animator>();//获取动画组件
	}

	void Update()
	{
		if (Input.GetButton("Fire2"))
		{
			attack();
		}
		
		// 接技能判斷
		attackCheck ();
	}

	void attackCheck() {
		//取得目前動作
		animStateInfo = anim.GetCurrentAnimatorStateInfo(0);
		
		// 連技計時器
		if ((anim.GetInteger ("ActionID") == 0 || anim.GetInteger ("ActionID") == 4) && tTime > -1) {
			tTime -= Time.deltaTime;
			sTime -= Time.deltaTime;
		}
		
		//取得攻擊狀態
		bool inAttack = false;
		if (animStateInfo.IsName (Attack1State) ||
		    animStateInfo.IsName (Attack2State) ||
		    animStateInfo.IsName (Attack3State)) {
			inAttack = true;
		}
		
		// 每個技能0.6秒
		if (inAttack && animStateInfo.normalizedTime > 0.5f) {
			anim.SetInteger ("ActionID", 0);
		}
		
		// 連技時間歸零
		if (tTime <= 0) {
			hitCount = 0;
			sTime = 0;
			tTime = 0;
			anim.SetInteger ("ActionID", hitCount);
		}
	}

	void attack()
	{
		//第一擊不需要延遲
		if (hitCount == 0) {
			sTime = skillTime;
			tTime = skillTime;
			hitCount = 1;
			anim.SetInteger ("ActionID", hitCount);
		} else if (hitCount > 3 && tTime > 0 && sTime < (skillTime - changeTime)) {
			sTime = skillTime;
			tTime = skillTime;
			hitCount = 1;
			anim.SetInteger ("ActionID", hitCount);
		}
		// 攻擊間格時間 changeTime
		if (tTime > 0 && sTime < (skillTime - changeTime)) {
			hitCount += 1;
			sTime = skillTime;
			anim.SetInteger ("ActionID", hitCount);
		}
	}

}