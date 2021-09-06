using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{
    public Text scoreText;

    void Update()
    {
        scoreText.text = $"Score\n{GlobalVar.score.ToString()}";
    }
}
