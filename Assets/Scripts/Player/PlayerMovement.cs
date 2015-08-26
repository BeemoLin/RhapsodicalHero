using UnityEngine;
using Fungus;

public class PlayerMovement : MonoBehaviour
{
	public Flowchart flowChart;

	public float speed = 0.0f;
	
	Vector3 movement;
	float targetRotate;
	Animator anim;
	Rigidbody playerRigidbody;
	int floorMask;
	float camRayLength = 100f;
	
	private bool isChart = false;
	
	void Awake() {
		floorMask = LayerMask.GetMask("Floor");
		anim = GetComponent <Animator> ();
		playerRigidbody = GetComponent <Rigidbody> ();
		targetRotate = 0.0f;
	}
	
	void FixedUpdate() {
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");

		if (flowChart != null && flowChart.GetVariable<BooleanVariable> ("charting") != null) {
			isChart = flowChart.GetVariable<BooleanVariable> ("charting").value;
		}
		
		if(!Input.GetButton ("Fire1") && !anim.GetBool ("IsAttack") && !isChart) {
			Animating (h, v);
		}
		if (!isChart) {
			Turning (h, v);
		}
		
	}
	

	
	void Turning(float h, float v) {
		float tiltAroundZ = h;
		float tiltAroundX = v;
		
		if(h > 0 && v == 0) { // 只按左右
			targetRotate = 270f;
		} else if(h < 0 && v == 0) { // 只按左右
			targetRotate = 90f;
		} else if(h == 0 && v > 0) { // 只按上下
			targetRotate = 180f;
		} else if(h == 0 && v < 0) { // 只按上下
			targetRotate = 0f;
		} else if(h > 0 && v > 0) {
			targetRotate = 225.0f;
		} else if(h < 0 && v > 0) {
			targetRotate = 120.0f;
		} else if(h > 0 && v < 0) {
			targetRotate = 325.0f;
		} else if(h < 0 && v < 0) {
			targetRotate = 45.0f;
		}
	
		
		Quaternion target = Quaternion.Euler (tiltAroundX, targetRotate, tiltAroundZ);
		
		transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 50);
		//		Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		//
		//		RaycastHit floorHit;
		//
		//		if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask)) {
		//			Vector3 playerToMouse = floorHit.point - transform.position;
		//			playerToMouse.y = 0f;
		//
		//			Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
		//
		//			Debug.Log(newRotation.y);
		//			playerRigidbody.MoveRotation(newRotation);
		//		}
	}
	
	void Animating(float h, float v) {
		bool walking = h != 0f || v != 0f;
		if (!anim.GetBool ("IsAttack")) {
			anim.SetBool ("IsRuning", walking);
		}
	}
	
}