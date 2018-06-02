using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIPanel : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}

    public GameObject CharAtt;
    public GameObject Pause;
    public GameObject MapSound;
    public GameObject EndGameSound;
    public GameObject AttackButton;
    public GameObject DefenceButton;
    public GameObject MovementSpeedButton;
    public GameObject Quest1;

    // Update is called once per frame
    void Update ()
    {
        MenusWithKeys();
    }

    // Activate/Deactivate by clicking pause button
    public void PauseMenu()
    {
        Pause.SetActive(!Pause.activeInHierarchy);
    }

    // Use to open and close sound
    public void SoundOnOffMap()
    {
        if (GameObject.Find("Barbarian mage").GetComponent<CharacterScript>().isDead == true)
        {
            MapSound.SetActive(false);
            EndGameSound.SetActive(!EndGameSound.activeInHierarchy);
        }else if(GameObject.Find("troll_02_01_Mecanim").GetComponent<TrollScript>().isdead == true)
        {
            MapSound.SetActive(false);
            EndGameSound.SetActive(!EndGameSound.activeInHierarchy);
        }
        else
        {
            EndGameSound.SetActive(false);
            MapSound.SetActive(!MapSound.activeInHierarchy);
        }
            
    }

    public void SoundOnOffMenu()
    {
        MapSound.SetActive(!MapSound.activeInHierarchy);
    }

    //'Esc' for PauseMenu
    private void MenusWithKeys()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Quest1.activeInHierarchy == true)
            {
                Quest1.SetActive(false);
            }
            else
            {
                Pause.SetActive(!Pause.activeInHierarchy);
            }
        }
    }

    // Use to change scene
    public void ChangeSceen(string scenename)
    {
        //Application.LoadLevel(scenename);
        SceneManager.LoadScene(scenename, LoadSceneMode.Single);
    }

    // Use to exit game
    public void Exit()
    {
        Debug.Log("exited");
        Application.Quit();
    }

    public void AttributeButtons(int value)
    {
        if (value == 1)
        {
            AttackButton.SetActive(true);
            DefenceButton.SetActive(true);
            MovementSpeedButton.SetActive(true);
        }
        else if (value == 0)
        {
            AttackButton.SetActive(false);
            DefenceButton.SetActive(false);
            MovementSpeedButton.SetActive(false);
        }
    }
}
