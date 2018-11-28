using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour {

    [SerializeField] Text livesText;

	void Update () {
        livesText.text = PlayerStat.lives.ToString() + " LIVES";	
	}
}
