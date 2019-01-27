using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour {
    [SerializeField] string menuSceneName = "Main Menu";
    [SerializeField] string nextLevel;
    [SerializeField] int levelToUnlock;
    [SerializeField] SceneFader sceneFader;

    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        sceneFader.FadeTo(nextLevel);
    } 

    public void ReturnMenu()
    {
        sceneFader.FadeTo(menuSceneName);
    }

}
