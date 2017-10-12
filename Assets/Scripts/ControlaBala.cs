using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaBala : MonoBehaviour {
	public float Velocidade = 30;

	private Rigidbody rigidBody;
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rigidBody.MovePosition (
			rigidBody.position +
			transform.forward * Velocidade * Time.deltaTime);
	}

	void OnTriggerEnter (Collider objetoDeColisao)
	{
		if (objetoDeColisao.tag == "Inimigo") {
			Destroy (objetoDeColisao.gameObject);
		}

		Destroy (gameObject);
	}
}
