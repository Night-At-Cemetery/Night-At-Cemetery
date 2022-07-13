using UnityEngine;
using TMPro;
using Player;

public class ScoreText : MonoBehaviour
{
    // Change to how many digits you want
    public int scoreLength = 9;
    // score as a string
    public string scoreString;
    public TextMeshProUGUI thisText;

    private string scoreText;
    private void Update()
    {
        scoreText = "";
        scoreString = (PlayerManager.Instance.score).ToString();
        int numZeros = scoreLength - scoreString.Length;
        
        
        for(int i = 0; i < numZeros; i++){
            scoreText += "0";
        }

        scoreText += scoreString;
        
        thisText.text = scoreText;
        
        
    }
}
