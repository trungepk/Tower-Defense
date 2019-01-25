using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour {

    [SerializeField] SceneFader sceneFader;

    public void Select(string levelName)
    {
        sceneFader.FadeTo(levelName);
    }
}
