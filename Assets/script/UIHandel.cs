using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIHandel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI cointCOuntDisplay;
    [SerializeField] Slider healthSlider;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] float scorecount;
    int toatalHealt;
    // Start is called before the first frame update
    void Start()
    {
        healthSlider.minValue = 0;
        healthSlider.maxValue = Manager.Instance.goalhealt;
        toatalHealt = Manager.Instance.goalhealt;
    }

    // Update is called once per frame
    void Update()
    {
        scorecount += Time.deltaTime;
       
        score.text = ((int)scorecount).ToString();
        healthSlider.value = Manager.Instance.goalhealt;
        cointCOuntDisplay.text =  "$ " +  Manager.Instance.coinCount.ToString();
    }
}
