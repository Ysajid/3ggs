using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour {
	private float initialTouchTime;
	private float finalTouchTime;
	private Vector2 initialTouchPos;
	private Vector2 finalTouchPos;

	private float xAxisForce;
	private float yAxisForce;
	private float zAxisForce;

	private Vector3 userForce;

	public Rigidbody egg;

	private bool canSwipe = true;

	void Start(){
		
		egg.useGravity = false;
	}


	//when it is touched
	public void IsTocuh () {
		if (canSwipe) {
			initialTouchTime = Time.time;
			initialTouchPos = Input.mousePosition;
		}
	}

	// when finger is lifted
	public void IsTouchRemoved(){
		if (canSwipe) {
			finalTouchTime = Time.time;
			finalTouchPos = Input.mousePosition;
			EggThrouw ();
		}
	}

	private void EggThrouw(){
	
		xAxisForce = finalTouchPos.x - initialTouchPos.x;
		yAxisForce = finalTouchPos.y - initialTouchPos.y;
		zAxisForce = finalTouchTime - initialTouchTime;

		userForce = new Vector3 (xAxisForce/50f , yAxisForce/40f, zAxisForce * 8f);
		egg.useGravity = true;
		egg.velocity = userForce;
		//canSwipe = false;
	}
}
