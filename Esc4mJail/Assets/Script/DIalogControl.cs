using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DIalogControl : MonoBehaviour
{
	public Text Name;
	public Text Dialog;
	public Text choice1;
	public Text choice2;
	public Text choice3;
	Image View;
	static string NameChar;
	static public Dialogues Npc;
	static public bool InDialog;
	Color Mark;
	Color Reg;
	bool Choose;
	int select;
	bool KeyUp;
	public static string Sentens;
	// Start is called before the first frame update
	void Start()
	{
		Sentens = null;
		Name.text = "";
		Dialog.text = "";
		InDialog = false;
		View = GetComponent<Image>();
		View.enabled = false;
		choice1.enabled = false;
		choice2.enabled = false;
		choice3.enabled = false;
		Mark = Color.green;
		Reg = Color.gray;
		Choose = false;
		select = 0;
		KeyUp = false;
	}
	void Update()
	{
		if (InDialog && Npc != null)
		{
			Name.text = NameChar;
			if (KeyUp == true)
			{
				if (!Input.GetKeyDown(KeyCode.Space))
					KeyUp = false;
			}
			else
			{
				if (Choose == false)
				{
					View.enabled = true;
					choice1.enabled = false;
					choice2.enabled = false;
					choice3.enabled = false;
					Dialog.text = Npc.GetCurrentDialogue();
				}
				if (Npc.GetChoices().Length != 0)
				{
					if (Choose == false)
					{
						choice1.color = Mark;
						choice1.text = Npc.GetChoices()[0];
						choice2.enabled = true;
						choice2.text = Npc.GetChoices()[1];
						choice2.color = Reg;
						Choose = true;
						if (Npc.GetChoices().Length > 2)
						{
							choice3.text = Npc.GetChoices()[2];
							choice1.enabled = true;
							choice3.enabled = true;
							choice3.color = Reg;
						}
						select = 0;
					}
					choice();
				}
				else if (Npc.End())
				{
					if (Input.GetKeyDown(KeyCode.Space))
					{
						if (Npc.HasTrigger())
						{
							switch (Npc.GetTrigger())
							{
								case "Play":
									TimelineController.Continue = true;
									break;
							}
						}
						InDialog = false;
						Name.text = "";
						Dialog.text = "";
						View.enabled = false;
						choice1.enabled = false;
						choice2.enabled = false;
						choice3.enabled = false;
						KeyUp = true;
						Npc = null;
					}
					else
					{
						Dialog.text = Npc.GetCurrentDialogue();
					}
				}
				else if (Input.GetKeyDown(KeyCode.Space))
				{
					Npc.Next();
					KeyUp = true;
				}
			}
		}
		else if (InDialog && Sentens != null)
		{
			View.enabled = true;
			Name.text = "Game";
			Dialog.text = Sentens;
			if (Input.GetKeyDown(KeyCode.Space))
			{
				KeyUp = true;
				InDialog = false;
				View.enabled = false;
				Name.text = "";
				Dialog.text = "";
			}

		}

	}
	void choice()
	{
		if (Npc.GetChoices().Length > 2)
		{
			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				if (choice1.color == Mark)
				{
					choice1.color = Reg;
					choice2.color = Mark;
					select++;
				}
				else if (choice2.color == Mark)
				{
					choice2.color = Reg;
					choice3.color = Mark;
					select++;
				}
				else if (choice3.color == Mark)
				{
					choice3.color = Reg;
					choice1.color = Mark;
					select = 0;
				}
			}
			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				if (choice1.color == Mark)
				{
					choice1.color = Reg;
					choice3.color = Mark;
					select = 2;
				}
				else if (choice2.color == Mark)
				{
					choice2.color = Reg;
					choice1.color = Mark;
					select--;
				}
				else if (choice3.color == Mark)
				{
					choice3.color = Reg;
					choice2.color = Mark;
					select--;
				}
			}
		}
		else
		{
			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				if (choice1.color == Mark)
				{
					choice1.color = Reg;
					choice2.color = Mark;
					select=1;
				}
				else if (choice2.color == Mark)
				{
					choice2.color = Reg;
					choice1.color = Mark;
					select = 0;
				}
			}
			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				if (choice1.color == Mark)
				{
					choice1.color = Reg;
					choice3.color = Mark;
					select = 1;
				}
				else if (choice3.color == Mark)
				{
					choice3.color = Reg;
					choice1.color = Mark;
					select=0;
				}
			}
		}
			if (Input.GetKeyDown(KeyCode.Space))
			{
				Choose = false;
				Npc.NextChoice(Npc.GetChoices()[select]);
			KeyUp = true;
			}
		
	}
	public static void StartDialog(string Name,Dialogues Dialogues, bool Start)
	{
		NameChar = Name;
		Npc = Dialogues;
		InDialog = Start;
	}
}

