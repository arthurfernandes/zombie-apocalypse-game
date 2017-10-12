using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaJogador : MonoBehaviour {

	public float Velocidade = 10;
	public LayerMask MascaraChao;
	public GameObject TextoGameOver;
	public bool Vivo = true;

	private Vector3 direcao;
	private Rigidbody rigidBody;
	private Animator animator;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;

		rigidBody = GetComponent<Rigidbody> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Inputs do Jogador
		float eixoX = Input.GetAxis ("Horizontal");
		float eixoZ = Input.GetAxis ("Vertical");

		direcao = new Vector3 (eixoX, 0, eixoZ);

		if (direcao != Vector3.zero) {
			animator.SetBool ("Movendo", true);		
		} else {
			animator.SetBool ("Movendo", false);
		}

		if(Vivo == false)
		{
			if(Input.GetButtonDown("Fire1"))
			{
				SceneManager.LoadScene("game");
			}
		}
	}

	void FixedUpdate() {
		//Movimentacao do Jogador
		rigidBody.MovePosition (
			rigidBody.position +
			(direcao * Velocidade * Time.deltaTime));

		//Rotaciona Jogador
		Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);

		RaycastHit impacto;

		if (Physics.Raycast (raio, out impacto, 100, MascaraChao)) {
			Vector3 posicaoMiraJogador = impacto.point - transform.position;
			posicaoMiraJogador.y = transform.position.y;
			Quaternion novaRotacao = Quaternion.LookRotation (posicaoMiraJogador);

			rigidBody.MoveRotation (novaRotacao);
		}
	}
}
