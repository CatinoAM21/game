using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class blocks : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textMesH;

    public void UpdateScore(int score)
    {
        textMesH.text = "Blocks Left: " + score.ToString();
    }
}
