using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBoxEventTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        // Player인지 확인하는 작업
        if(col.CompareTag("Player"))
        {
            print("파란 박스에 도착하였습니다.");
        }
    }

    private void OnTriggerStay(Collider col)
    {
        // Player인지 확인하는 작업
        if(col.CompareTag("Player"))
        {
            print("파란 박스 안에 있습니다.");
        }
    }

    private void OnTriggerExit(Collider col)
    {
        // Player인지 확인하는 작업
        if(col.CompareTag("Player"))
        {
            print("파란 박스에서 나왔습니다.");
        }
    }
}
