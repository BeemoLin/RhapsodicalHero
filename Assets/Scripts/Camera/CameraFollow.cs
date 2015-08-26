using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public Transform target;
	public float smoothing = 5f;
	
	Vector3 offset;
	
	void Start() {
		offset = transform.position - target.position;
	}
	
	void FixedUpdate() {
		Vector3 targetCamPos = target.position + offset;
		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
		
		float mouseScroll = Input.GetAxis("Mouse ScrollWheel");
		
		if (mouseScroll > 0) {
			Camera.main.fieldOfView = Mathf.Max(Camera.main.fieldOfView - 3, 35);
		} else if (mouseScroll < 0) {
			Camera.main.fieldOfView = Mathf.Min(Camera.main.fieldOfView + 3, 50);
		}
	}
	
}