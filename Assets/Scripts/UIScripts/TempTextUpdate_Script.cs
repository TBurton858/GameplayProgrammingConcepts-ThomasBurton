using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TempTextUpdate_Script : MonoBehaviour
{
    public int score;
    public int lives;

    public TMP_Text scoreText;
    public TMP_Text livesText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = "" + lives;
        scoreText.text = "" + score;
    }
}
