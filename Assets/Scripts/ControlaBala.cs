using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaBala : MonoBehaviour {
	public float Velocidade = 30;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GetComponent<Rigidbody> ().MovePosition (
			GetComponent<Rigidbody> ().position +
			Vector3.forward * Velocidade * Time.deltaTime);
	}
}
