using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundSurvived : MonoBehaviour
{
    public Text roundText;

    private void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        roundText.text = "0";
        int round = 0;
        while( round < PlayerStats.rounds)
        {
            round++;
            roundText.text = round.ToString();

            yield return new WaitForSeconds(.05f);
        }
    }
}
