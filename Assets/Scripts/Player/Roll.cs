using UnityEngine;
using System.Collections;

public class Roll : MonoBehaviour
{
	private Animator anim;//获取人物
	private AnimatorStateInfo animStateInfo;//获取动画状态信息
	private const string IdleState = "Idle";//获取默认动作
	private const string Attack1State = "IsRolling";//获取攻击1
	
	private int HitCount = 0;  // 当前连击数（即 玩家按下攻击键的次数） 

	void Start()
	{
		anim = this.gameObject.GetComponent<Animator>();//获取动画组件
	}
	
	void Update()
	{
		animStateInfo = anim.GetCurrentAnimatorStateInfo(0);
		if (!animStateInfo.IsName(IdleState)&&animStateInfo.normalizedTime>0.7f)
			{
			// 每次设置完参数之后，都应该在下一帧开始时将参数设置清空，避免连续切换  
			anim.SetInteger("IsRolling",0);
			HitCount = 0;
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			//如果按了空格键则执行攻击方法
			roll();
		}
	}
	
	void roll()
	{
		
		if (HitCount==0&&animStateInfo.normalizedTime>0.1f)
		{
			// 在待命状态下，按下攻击键，进入攻击1状态，并记录连击数为1 
			anim.SetInteger("IsRolling", 1);
			HitCount = 1;
		}

	}
}