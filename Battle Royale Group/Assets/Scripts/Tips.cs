using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tips : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public Transform player3;

    public GameObject tip_iceBrick;
    public GameObject iceBrick;

    public GameObject tip_elevatorTip;
    ElevatorButton elevatorButtonCode;
    public bool ifTriggered;

    public GameObject tip_waterTip;
    public GameObject waterPlatform;

    // Start is called before the first frame update
    void Start()
    {
        elevatorButtonCode = FindObjectOfType<ElevatorButton>();
        ifTriggered = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(elevatorButtonCode.ifMove){
            ifTriggered = true;
        }
        //print(iceBrick.activeSelf);
        if(((player1.position.x>5 && player1.position.x<10)||(player2.position.x>5 && player2.position.x<10)||(player3.position.x>5 && player3.position.x<10))&&iceBrick.activeSelf){
            tip_iceBrick.SetActive(true);
        }
        else if(((player1.position.x>22 && player1.position.x<35)||(player2.position.x>22 && player2.position.x<35)||(player3.position.x>22 && player3.position.x<35))&&!ifTriggered){
            tip_elevatorTip.SetActive(true);
        }
        else if(((player1.position.x>108 && player1.position.x<114)||(player2.position.x>108 && player2.position.x<114)||(player3.position.x>108 && player3.position.x<114))&&waterPlatform.activeSelf){
            tip_waterTip.SetActive(true);
        }
        else
        {
            tip_iceBrick.SetActive(false);
            tip_elevatorTip.SetActive(false);
            tip_waterTip.SetActive(false);
        }

        
    }
}
