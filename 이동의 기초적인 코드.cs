using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    GameObject EncounterGauge;
    float currentEncountTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        this.EncounterGauge = GameObject.Find("EncounterGauge");
    }

    // Update is called once per frame
    void Update()
    {
        //화면 움직이는 것 추가 필요.
        currentEncountTime += 0.003f;
        this.EncounterGauge.GetComponent<Image>().fillAmount = currentEncountTime;
        if (currentEncountTime >= 0.8f)
        {
            Debug.Log("Battle Start!");
            currentEncountTime = 0f;
        }
    }
}
