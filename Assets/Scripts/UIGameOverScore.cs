using UnityEngine;
using UnityEngine.UI;

public class UIGameOverScore : MonoBehaviour
{
    public Text finalScore;

    void Start()
    {
        finalScore.text = $"Score\n{GlobalVar.score.ToString()}";
    }

}
