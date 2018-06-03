using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestScript : MonoBehaviour
{

	public GameObject QuestNotCompleted;
	public GameObject QuestCompleted;
	public GameObject GoblinQuest;
	public int GoblinCounter;
	public Text GoblinText;
	public GameObject HobgoblinQuest;
	public int HobgoblinCounter;
	public Text HobgoblinText;
	public GameObject WolfQuest;
	public int WolfCounter;
	public Text WolfText;
	public bool QuestIsAccepted = false;
	public bool QuestIsCompleted = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (GoblinQuest.activeInHierarchy == true && QuestIsCompleted == false)
		{
			GoblinText.text = "Goblin killed : " + GoblinCounter + "/15";
			if (GoblinCounter == 15)
			{
				QuestIsCompleted = true;
			}
		}
		
		if (HobgoblinQuest.activeInHierarchy == true && QuestIsCompleted == false)
		{
			HobgoblinText.text = "Hobgoblin killed : " + HobgoblinCounter + "/7";
			if (HobgoblinCounter == 7)
			{
				QuestIsCompleted = true;
			}
		}
		
		if (WolfQuest.activeInHierarchy == true && QuestIsCompleted == false)
		{
			WolfText.text = "Wolf killed : " + WolfCounter + "/13";
			if (WolfCounter == 13)
			{
				QuestIsCompleted = true;
			}
		}
	}

	public void AcceptQuest()
	{
		QuestIsAccepted = true;
		QuestNotCompleted.SetActive(false);

		int quest = Random.Range(1, 4);
		if (quest == 1)
		{
			GoblinQuestInfo();
		}
		else if (quest == 2)
		{
			HobgoblinQuestInfo();
		}
		else if (quest == 3)
		{
			WolfQuestInfo();
		}
	}

	public void CompleteQuest()
	{
		QuestIsAccepted = false;
		QuestIsCompleted = true;
		QuestCompleted.SetActive(false);
		GameObject.Find("Barbarian mage").GetComponent<CharacterScript>().GiveRandomBuff();
	}

	private void GoblinQuestInfo()
	{
		GoblinQuest.SetActive(true);
	}
	
	private void HobgoblinQuestInfo()
	{
		HobgoblinQuest.SetActive(true);
	}
	
	private void WolfQuestInfo()
	{
		WolfQuest.SetActive(true);
	}
}
