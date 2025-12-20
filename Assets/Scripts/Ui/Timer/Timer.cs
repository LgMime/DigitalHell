using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public TextMeshProUGUI TextMeshPro;

    public float AllSecund = 0f;//for dificult

    //for ui
    public float Secund = 0f;
    public float Min = 0f;
    //

    private string TextSecunda;
    private string TextMin;
    private string result;
    private void Start()
    {
        TextMeshPro = GetComponent<TextMeshProUGUI>();
    }

    public void Update()
    {
        Secund += Time.deltaTime;
        AllSecund += Time.deltaTime;
        MinutConvert();
        TextMeshPro.text = result;
    }

    public void MinutConvert()
    {
        if (Secund >= 60f)
        {
            Secund = 0f;
            Min += 1f;
        }
        TextMin = Mathf.FloorToInt(Min).ToString();
        TextSecunda = Mathf.FloorToInt(Secund).ToString();
        result = TextMin +":" + TextSecunda;
    }
}
