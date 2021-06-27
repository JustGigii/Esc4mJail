using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerControl : MonoBehaviour
{
	public float Speed;
	private Rigidbody2D Player;
	private Animator Ani;
	float X = 0;
	float Y = 0;
	// Start is called before the first frame update
	void Start()
	{
		Player = GetComponent<Rigidbody2D>();
		Ani = GetComponent<Animator>();
		X = 0;
		Y = -1;
	}

	// Update is called once per frame
	void Update()
	{
		if (!(DIalogControl.InDialog || StartGame.InGame))
		{
			if (Input.GetAxis("Vertical") >= 0.5f || Input.GetAxis("Vertical") <= -0.5f)
			{

				Player.velocity = new Vector2(Player.velocity.x, Input.GetAxis("Vertical") * Speed);


			}
			else
			{
				Player.velocity = new Vector2(Player.velocity.x, 0f);


			}
			if (Input.GetAxis("Horizontal") >= 0.5f || Input.GetAxis("Horizontal") <= -0.5f)
			{
				Player.velocity = new Vector2(Input.GetAxis("Horizontal") * Speed, Player.velocity.y);
			}
			else
			{
				Player.velocity = new Vector2(0f, Player.velocity.y);

			}
			if (Input.GetAxis("Vertical") != 0f || Input.GetAxis("Horizontal") != 0f)
			{
				Ani.SetBool("IsMove", true);
				Ani.SetFloat("Y", Input.GetAxis("Vertical"));
				Y = Input.GetAxis("Vertical");
				Ani.SetFloat("X", Input.GetAxis("Horizontal"));
				X = Input.GetAxis("Horizontal");
			}
			else
			{
				Ani.SetBool("IsMove", false);
				Ani.SetFloat("Y", 0);
				Ani.SetFloat("X", 0);
			}
			if (!Ani.GetBool("IsMove"))
			{
				Ani.SetFloat("LastX", X);
				Ani.SetFloat("LastY", Y);
			}
			else
			{
				Ani.SetFloat("LastX", 0);
				Ani.SetFloat("LastY", 0);
			}
		}
		else
		{
			Player.velocity = new Vector2(0f, 0f);
			Ani.SetBool("IsMove", false);
			Ani.SetFloat("Y", 0);
			Ani.SetFloat("X", 0);
		}
	}
}
