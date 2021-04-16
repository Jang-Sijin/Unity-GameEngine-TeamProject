using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBoxCollisionTrigger : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        if(col.collider.CompareTag("Player"))
        {
            print(col.impulse.magnitude);

            if(col.impulse.magnitude > 10) // impulse는 진입 각도 // 충돌 크기가 10일 경우 분기가 나눠짐
            {
                print("깨지겠다.");
            }
            else
            {
                print("안깨진다...");
            }
        }
    }
}
