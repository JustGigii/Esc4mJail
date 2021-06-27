using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabControl : MonoBehaviour
{
	public float speed;
	private Rigidbody2D rb;
	private Vector2 screenBounds;
	bool Active;
	// Start is called before the first frame update
	void Start()
    {
		rb = this.GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(-speed, 0);
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		Active = false;

	}

	// Update is called once per frame
	void Update()
	{
		if (Active && Input.GetKeyDown(KeyCode.Space))
		{
			StartGame.CounterSuccess++;
			Destroy(this.gameObject);
			print("Down");
		}
		
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Minigame")
			Active = true;
		print("in");
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Minigame")
			Destroy(this.gameObject);
		Active = false;
		print("Out");
	}
}
