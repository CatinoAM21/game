using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class blocks : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textMesH;

    public void UpdateScore(int score, string Block, int cost)
    {
        textMesH.text = "Budget: " + score.ToString() + "\nBlock Selected: " + Block + "\nCost: " + cost.ToString();
    }
}
