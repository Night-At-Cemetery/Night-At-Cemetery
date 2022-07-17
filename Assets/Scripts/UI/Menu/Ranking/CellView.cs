using UnityEngine;
using UnityEngine.UI;
using EnhancedUI.EnhancedScroller;
using TMPro;

namespace EnhancedScrollerDemos.SuperSimpleDemo
{
    /// <summary>
    /// This is the view of our cell which handles how the cell looks.
    /// </summary>
    public class CellView : EnhancedScrollerCellView
    {
        /// <summary>
        /// A reference to the UI Text element to display the cell data
        /// </summary>
        public Image levelBackground;
        public TMP_Text levelText;

        
        public TMP_Text playerName;
        public TMP_Text playerScore;

        /// <summary>
        /// This function just takes the Demo data and displays it
        /// </summary>
        /// <param name="data"></param>
        public void SetData(Data data)
        {
            Color color = Color.gray;

            if (data.level == 1)
            {
                color = Color.red;
            } else if (data.level == 2)
            {
                color = Color.yellow;
            } else if (data.level == 3)
            {
                color = Color.green;
            }

            levelBackground.color = color;
            levelText.text = data.level.ToString();

            playerName.text = data.playerName;
            playerScore.text = data.playerScore.ToString();
        }
    }
}