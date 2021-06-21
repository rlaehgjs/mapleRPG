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

    public void move()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentEncountTime += 0.003f;
        this.EncounterGauge.GetComponent<Image>().fillAmount = currentEncountTime;
        if (currentEncountTime >= 0.8f)
        {
            Debug.Log("Battle Start!");
            currentEncountTime = 0f;
        }
    }
}
