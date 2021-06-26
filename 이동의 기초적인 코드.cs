using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Math;

public class GameDirector : MonoBehaviour
{
    GameObject EncounterGauge;
    GameObject player;
    GameObject MainCamera;
    float diffX;
    float diffY;
    float currentEncountTime = 0f;
    float length;
    float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("player");
        this.EncounterGauge = GameObject.Find("EncounterGauge");
        this.MainCamera = GameObject.Find("Main Camera");
        this.EncounterGauge.GetComponent<Image>().fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            var touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            var curPos = Camera.main.ScreenToWorldPoint(player.transform.position);
            Debug.Log(new Vector2(touchPos.x, player.transform.position.x));
            Debug.Log(new Vector2(touchPos.y, player.transform.position.y));
            diffX = (touchPos.x - player.transform.position.x);
            diffY = (touchPos.y - player.transform.position.y);
            length = (float)Sqrt((float)(diffX * diffX + diffY * diffY));
            player.transform.Translate(diffX / length / speed, diffY / length / speed, 0);
            curPos = Camera.main.ScreenToWorldPoint(player.transform.position);
            
            if (Vector3.Distance(curPos, MainCamera.transform.position) > 1)
            {
                MainCamera.transform.Translate((MainCamera.transform.position - curPos) * speed);
            }
            //player.localPosition = Vector2.MoveTowards(player.position, Input.GetTouch(0).position, 0.2);
            currentEncountTime += 0.005f;
            this.EncounterGauge.GetComponent<Image>().fillAmount = currentEncountTime;
            if (currentEncountTime >= 0.5f)
            {
                Debug.Log("Battle Start!");
                currentEncountTime = 0f;
            }
        }
    }
}
