using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeZumbis : MonoBehaviour {
	public GameObject Zumbi;
	public float contadorTempo = 0;
	public float timeGerarZumbi = 2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		contadorTempo += Time.deltaTime;

		if (contadorTempo > timeGerarZumbi) {
			Instantiate (Zumbi, transform.position, transform.rotation);		
			contadorTempo = 0;
		}
	}
}
