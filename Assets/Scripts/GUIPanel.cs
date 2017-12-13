using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIPanel : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject CharAtt;
    public GameObject Pause;

    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            CharAtt.SetActive(!CharAtt.activeInHierarchy);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause.SetActive(!Pause.activeInHierarchy);
        }
    }
}
