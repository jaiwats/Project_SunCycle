
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    

    public Transform MainBody;
    public Text ScoreText;


    // Update is called once per frame
    void Update()
    {
        ScoreText.text = MainBody.position.z.ToString("0");
    }
}
