using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundSurvived : MonoBehaviour
{
    [SerializeField] Text roundSurvivedText;

    private void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        roundSurvivedText.text = "0";
        int round = 0;
        while (round < PlayerStat.rounds)
        {
            round++;
            roundSurvivedText.text = round.ToString();
            yield return new WaitForSeconds(.04f);
        }
    }
}
