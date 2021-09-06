using UnityEngine;
using UnityEngine.UI;

public class UIRemain : MonoBehaviour
{
    public Text remainText;

    void Update()
    {
        remainText.text = $"Remain\n{GlobalVar.remain.ToString()}";
    }
}
