using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlay : MonoBehaviour
{
	public int Target;
	public int win;
	// Start is called before the first frame update
	void Start()
    {
		win = 0;
	}

    // Update is called once per frame
    void Update()
    {
		if (StartGame.InGame && StartGame.CounterSuccess != 0)
			win = StartGame.CounterSuccess;
		DIalogControl.Sentens = "you success " + win + "/" + Target;

	}
	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.tag == "Player")
		{
			StartGame.Target = Target;
			StartGame.InGame = true;
		}
	}
}
