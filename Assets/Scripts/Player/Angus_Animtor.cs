using UnityEngine;
using System.Collections;

//
// アニメーション簡易プレビュースクリプト
// 2015/4/25 quad arrow
//

// Require these components when using this script
[RequireComponent(typeof(Animator))]

public class Angus_Animtor : MonoBehaviour
{
	
	private Animator anim;						// Animatorへの参照
	private AnimatorStateInfo currentState;		// 現在のステート状態を保存する参照
	private AnimatorStateInfo previousState;	// ひとつ前のステート状態を保存する参照
	
	
	// Use this for initialization
	void Start ()
	{
		// 各参照の初期化
		anim = GetComponent<Animator> ();
		currentState = anim.GetCurrentAnimatorStateInfo (0);
		previousState = currentState;
		
	}
	
	void Update () 
	{
		if(Input.GetKey(KeyCode.S))
			anim.SetBool ("IsRuning", true);
		if(Input.GetKeyUp(KeyCode.S))
			anim.SetBool ("IsRuning", false);
	;

	}
		}
