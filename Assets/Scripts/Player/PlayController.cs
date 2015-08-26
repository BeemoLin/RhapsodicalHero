using UnityEngine;
using System.Collections;

public class PlayController: MonoBehaviour 
{
	
	//人物行走的4个方向
	public const int PLAY_UP = 0;
	public const int PLAY_RIGHT = 1;
	public const int PLAY_DOWN = 2;
	public const int PLAY_LEFT = 3;
	
	//记录当前人物的状态
	private int gameState = 0;
	
	//人物移动的速度
	private int moveSpeed = 1;
	void Awake () 
	{
		gameState = PLAY_DOWN;
	}
	
	void Update () 
	{
		KeyMover();
	}
	
	void KeyMover()
	{
		if(Input.GetKey(KeyCode.A))
		{
			setGameState(PLAY_LEFT);
		}
		else if(Input.GetKey(KeyCode.D))
		{
			setGameState(PLAY_RIGHT);
		}
		else if(Input.GetKey(KeyCode.S))
		{
			setGameState(PLAY_DOWN);
		}
		else if(Input.GetKey(KeyCode.W))
		{
			setGameState(PLAY_UP);
		}
	}
	
	public void setGameState(int newState)
	{
		//根据当前模型方向一上一次备份的方向计算出模型的角度
		int rotareValue = (newState - gameState) * 90;
		Vector3 transFormValue = new Vector3();
		//模型移动的数值
		switch(newState)
		{
		case PLAY_UP:
			transFormValue = Vector3.forward * Time.deltaTime;
			break;
		case PLAY_DOWN:
			transFormValue = (-Vector3.forward) * Time.deltaTime;
			break;
		case PLAY_LEFT:
			transFormValue = Vector3.left * Time.deltaTime;
			break;
		case PLAY_RIGHT:
			transFormValue = (-Vector3.left) * Time.deltaTime;
			break;
		}
		//模型旋转
		transform.Rotate(Vector3.up ,rotareValue);
		//移动人物
		transform.Translate(transFormValue * moveSpeed,Space.World);
		gameState = newState;
		
	}
}