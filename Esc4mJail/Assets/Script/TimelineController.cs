using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimelineController : MonoBehaviour
{
	public string Name;
	public Dialogues Npc;
	public PlayableDirector[] playableDirectors;
	//public TimelineAsset timelines;
	public static bool Continue;
	public string[] Dialog;
	int CountTree;
	public Animator playerAnimator;
	public string[] Postions;
	bool transfer;
	int Counter;
	 RuntimeAnimatorController playerAnim;
	//public Animator Ani;
	// Start is called before the first frame update

	void Start()
	{
		Counter = 0;
		playerAnim = playerAnimator.runtimeAnimatorController;
		playerAnimator.runtimeAnimatorController = null;
		Continue = false;
		int CountTree = 0;
		Npc.SetTree(Dialog[CountTree]);
		playableDirectors[CountTree].Play();

	}
    // Update is called once per frame
    void Update()
    {
		if (Continue)
		{
			CountTree++;
			Npc.SetTree(Dialog[CountTree]);
			playableDirectors[CountTree].Play();
			Counter = 0;
			Continue = false;
		}	
		if (playableDirectors[CountTree].state != PlayState.Playing)
		{
			playerAnimator.runtimeAnimatorController = playerAnim;
			if (!Npc.End())
				DIalogControl.StartDialog(name, Npc, true);
			if (Counter == 0)
			{
				print(Postions[CountTree]);
				string[] position = Postions[CountTree].Split(',');
				float X = float.Parse(position[0]);
				float Y = float.Parse(position[1]);
				transform.position = new Vector3(X, Y);
				Counter++;
				playerAnim = playerAnimator.runtimeAnimatorController;
				playerAnimator.runtimeAnimatorController = null;
			}
		}	
	}
}
