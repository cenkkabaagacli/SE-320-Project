using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIPanel : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}

    public GameObject CharAtt;
    public GameObject Pause;

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

    // 'C' for CharacterAttributes, 'Esc' for PauseMenu
    private void MenusWithKeys()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            CharAtt.SetActive(!CharAtt.activeInHierarchy);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause.SetActive(!Pause.activeInHierarchy);
        }
    }

    // Use to change scene
    public void ChangeSceen(string scenename)
    {
        Application.LoadLevel(scenename);
    }

    // Use to exit game
    public void Exit()
    {
        Application.Quit();
    }

}
