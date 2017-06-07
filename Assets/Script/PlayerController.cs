using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float firetime;
	private float firetimecounter;

	private bool currentMoving;
	private bool currentFire;
	private Animator anime;
	private Vector2 lastMove;


	// Use this for initialization
	void Start () {

		anime = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {

		currentMoving = false;

		if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f) 
		{
			transform.Translate (new Vector3 (Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
			currentMoving = true;
			lastMove = new Vector2 (Input.GetAxisRaw ("Horizontal"), 0f);
		}
		else if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f) 
		{
			transform.Translate (new Vector3 (0f, Input.GetAxisRaw ("Vertical") * moveSpeed * Time.deltaTime, 0f));
			currentMoving = true;
			lastMove = new Vector2 (0f, Input.GetAxisRaw ("Vertical"));
		}

		if (Input.GetKeyDown(KeyCode.Z)) 
		{
			firetimecounter = firetime;
			currentFire = true;
			anime.SetBool ("CurrentFire", true);	
		}

		if (firetimecounter > 0) 
		{
			firetimecounter -= Time.deltaTime;
		} 
		else 
		{
			currentFire = false;
			anime.SetBool ("CurrentFire", false);
		}
	
		anime.SetFloat ("MoveX", Input.GetAxisRaw ("Horizontal"));
		anime.SetFloat ("MoveY", Input.GetAxisRaw ("Vertical"));
		anime.SetBool ("CurrentMoving", currentMoving);
		anime.SetFloat ("LastMoveX", lastMove.x);
		anime.SetFloat ("LastMoveY", lastMove.y);

		}
}
