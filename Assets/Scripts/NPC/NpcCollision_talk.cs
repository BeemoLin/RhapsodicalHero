using UnityEngine;
using System.Collections;
using Fungus;

public class NpcCollision_talk : MonoBehaviour {
	
	public Flowchart flowChart;
	private Clickable2D clickable2D;
	private bool isChart = false;
	
	void Awake () {
		clickable2D = GetComponent<Clickable2D>();
	}
	
	void Update() {
		
		if (flowChart != null && flowChart.GetVariable<BooleanVariable> ("charting")) {
			isChart = flowChart.GetVariable<BooleanVariable> ("charting").value;
		}
		
		if (isChart) {
			clickable2D.clickEnabled = false;
		} else {
			clickable2D.clickEnabled = true;
		}
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player") {
			clickable2D.clickEnabled = true;
		}
	}
	
	void OnTriggerExit(Collider other) {
		if(other.tag == "Player") {
			clickable2D.clickEnabled = false;
		}
	}
	
 }