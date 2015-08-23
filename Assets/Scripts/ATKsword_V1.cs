using UnityEngine;
using System.Collections;

public class ATKsword_V1 : MonoBehaviour
{
	private Animator anim;//获取人物
	private AnimatorStateInfo animStateInfo;//获取动画状态信息
	private const string IdleState = "Idle";//获取默认动作
	private const string Attack1State = "Atk01_sword";//获取攻击1
	private const string Attack2State = "Atk02_sword";//获取攻击2
	private const string Attack3State = "Atk03_sword";//获取攻击3
	private int HitCount = 0;  // 当前连击数（即 玩家按下攻击键的次数） 
	
	void Start()
	{
		anim = this.gameObject.GetComponent<Animator>();//获取动画组件
	}

	void Update()
	{
		animStateInfo = anim.GetCurrentAnimatorStateInfo(0);
		if (!animStateInfo.IsName(IdleState)&&animStateInfo.normalizedTime>0.8f)
		{
			// 每次设置完参数之后，都应该在下一帧开始时将参数设置清空，避免连续切换  
			anim.SetInteger("ActionID", 0);
			HitCount = 0;
		}
		if (Input.GetKey(KeyCode.Space))
		{
			//如果按了空格键则执行攻击方法
			attack();
		}
	}
	
	void attack()
	{
	
		if (HitCount==0&&animStateInfo.normalizedTime>0.5f)
		{
			// 在待命状态下，按下攻击键，进入攻击1状态，并记录连击数为1 
			anim.SetInteger("ActionID",1);
			HitCount = 1;
		}
		if (animStateInfo.IsName(Attack1State)&&HitCount==1&&animStateInfo.normalizedTime>0.5f)
		{
			// 在攻击1状态下，按下攻击键，记录连击数为2（切换状态在Update()中）  
			anim.SetInteger("ActionID",2);
			HitCount = 2;
		}
		if (animStateInfo.IsName(Attack2State)&&HitCount==2&&animStateInfo.normalizedTime>0.5f)
		{
			// 在攻击2状态下，按下攻击键，记录连击数为3（切换状态在Update()中）  
			anim.SetInteger("ActionID",3);
			HitCount = 3;
		}
	}
}