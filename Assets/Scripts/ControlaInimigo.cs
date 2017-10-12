using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour {

	public GameObject Jogador;
	public float Velocidade = 4;

	private Rigidbody rigidBody;
	private Animator animator;

	// Use this for initialization
	void Start () {
		Jogador = GameObject.FindWithTag("Jogador");
		int geraTipoZumbi = Random.Range (1, 28);
		transform.GetChild (geraTipoZumbi).gameObject.SetActive (true);

		rigidBody = GetComponent<Rigidbody> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float distancia = Vector3.Distance (Jogador.transform.position, transform.position);

		Vector3 direcao = Jogador.transform.position - transform.position;
		Quaternion novaRotacao = Quaternion.LookRotation (direcao);
		GetComponent<Rigidbody> ().MoveRotation (novaRotacao);

		if (distancia > 2.5) {
			//Perseguir o Jogador
			rigidBody.MovePosition (
				rigidBody.transform.position +
				direcao.normalized * Velocidade * Time.deltaTime);

			animator.SetBool ("Atacando", false);

		} else {
			//Atacar
			animator.SetBool ("Atacando", true);
		}
	}

	public void AtacaJogador() {
		Time.timeScale = 0;

		Jogador.GetComponent<ControlaJogador> ().Vivo = false;
		Jogador.GetComponent<ControlaJogador> ().TextoGameOver.SetActive (true);
	}
}
