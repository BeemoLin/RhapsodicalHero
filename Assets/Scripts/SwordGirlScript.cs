//基于Mecanim动画系统的三连击效果，目前最大的问题就是玩家在攻击后无法
//自动恢复到Idle状态，需要执行一次攻击才可以回到Idle状态

using UnityEngine;
using System.Collections;

public class SwordGirlScript : MonoBehaviour {
	
	//Mecanim动画组件
	private Animator mAnimator=null;
	//动画状态信息
	private AnimatorStateInfo mStateInfo;
	//定义状态常量值，前面不要带层名啊，否则无法判断动画状态
	private const string IdleState="Idle";
	private const string Attack1State="Atk01_sword";
	private const string Attack2State="Atk02_sword";
	private const string Attack3State="Atk03_sword";
	
	//定义玩家连击次数
	private int mHitCount=0;
	
	void Start () 
	{
		//获取动画组件
		mAnimator=GetComponent<Animator>();
		//获取状态信息
		mStateInfo=mAnimator.GetCurrentAnimatorStateInfo(0);
	}
	
	void Update () 
	{
		Debug.Log (mHitCount);
		//如果玩家处于攻击状态，且攻击已经完成，则返回到Idle状态
		if(!mStateInfo.IsName(IdleState))
		{
			mAnimator.SetInteger("ActionID",0);
			mHitCount=0;
		}

		//如果按下鼠标左键，则开始攻击
		if(Input.GetMouseButtonDown(0))
		
		{
			Attack();
		}
	}
	
	void Attack()
	{
		//获取状态信息
		mStateInfo=mAnimator.GetCurrentAnimatorStateInfo(0);
		//如果玩家处于Idle状态且攻击次数为0，则玩家按照攻击招式1攻击，否则按照攻击招式2攻击，否则按照攻击招式3攻击
		if(mStateInfo.IsName(IdleState) && mHitCount==0 && mStateInfo.normalizedTime>0.7F)
		{
			mAnimator.SetInteger("ActionID",1);
			mHitCount=1;
		}else if(mStateInfo.IsName(Attack1State) && mHitCount==1 && mStateInfo.normalizedTime>0.3F)
		{
			mAnimator.SetInteger("ActionID",2);
			mHitCount=2;
		}else if(mStateInfo.IsName(Attack2State)&& mHitCount==2 && mStateInfo.normalizedTime>0.45F)
		{
			mAnimator.SetInteger("ActionID",3);
			mHitCount=3;
	   
	}
	}
}