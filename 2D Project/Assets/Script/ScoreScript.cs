using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int scorevalue = 14;
    Text score1;
    // Use this for initialization
    void Start()
    {
        score1 = GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        score1.text = "score : " + scorevalue;
    }
}
