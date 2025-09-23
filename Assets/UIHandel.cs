using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandel : MonoBehaviour
{
    [SerializeField]Text cointCOuntDisplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cointCOuntDisplay.text = Manager.Instance.coinCount.ToString();
    }
}
