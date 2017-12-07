using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneToLevel1 : MonoBehaviour
{

    public void ChangeSceenToLevel1(string scenename)
    {
        Application.LoadLevel(scenename);
    }
}
