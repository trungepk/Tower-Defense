using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    [SerializeField] Text roundSurvivedText;

    private void OnEnable()
    {
        roundSurvivedText.text = PlayerStat.rounds.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void ReturnMenu()
    {

    }
}
