using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
	public GameObject asteroidPrefab;
	 float respawnTime;
	private Vector2 screenBounds;
	static public bool InGame;
	static public int Target;
	int Cunter;
	public GameObject Poss;
	GameObject image;
	 GameObject Tab;
	static public int CounterSuccess;
	// Use this for initialization
	void Start()
	{
		image = GetComponent<GameObject>();
		InGame = false;
		Cunter = 0;
		CounterSuccess = 0;
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		StartCoroutine(asteroidWave());
	}
	private void spawnEnemy()
	{
		Tab = Instantiate(asteroidPrefab) as GameObject;
		Tab.transform.position = new Vector3(Poss.transform.position.x+ 9.5f, Poss.transform.position.y - 4.6f); 
	}
	IEnumerator asteroidWave()
	{
		while (true)
		{
			yield return new WaitForSeconds(0.2f);
			if(InGame)
			{
				Vector3 Come = new Vector3(Poss.transform.position.x, Poss.transform.position.y - 4.6f);
				transform.position = Come;
			respawnTime = Random.Range(0.5f, 1.5f);
			yield return new WaitForSeconds(respawnTime);
			Cunter++;
			if (Cunter == Target+1)
			{
				yield return new WaitForSeconds(1.0f);
				InGame = false;
				DIalogControl.InDialog = true;
				transform.position= new Vector3(999f,999f);
				Cunter = 0;
				CounterSuccess = 0;
			}
			else
				spawnEnemy();
		}
			}
	}
}
