using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour {

	public GameObject Jogador;
	public float Velocidade = 4;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float distancia = Vector3.Distance (Jogador.transform.position, transform.position);

		Vector3 direcao = Jogador.transform.position - transform.position;
		Quaternion novaRotacao = Quaternion.LookRotation (direcao);
		GetComponent<Rigidbody> ().MoveRotation (novaRotacao);

		if (distancia > 2.5) {
			//Perseguir o Jogador
			GetComponent<Rigidbody> ().MovePosition (
				GetComponent<Rigidbody> ().transform.position +
				direcao.normalized * Velocidade * Time.deltaTime);

			GetComponent<Animator> ().SetBool ("Atacando", false);

		} else {
			//Atacar
			GetComponent<Animator> ().SetBool ("Atacando", true);
		}
	}

	public void AtacaJogador() {
		Time.timeScale = 0;

		Jogador.GetComponent<ControlaJogador> ().Vivo = false;
		Jogador.GetComponent<ControlaJogador> ().TextoGameOver.SetActive (true);
	}
}
