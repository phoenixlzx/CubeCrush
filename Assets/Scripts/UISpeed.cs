using UnityEngine;
using UnityEngine.UI;

public class UISpeed : MonoBehaviour
{
    public Text speedText;

    void Update()
    {
        speedText.text = $"Speed\n{GlobalVar.spawnSpeed.ToString()}";
    }
}
