using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

static class Items
{
    public const int MaxCnt = 4;
}

public class Quest_Text : MonoBehaviour
{
    public Text Quest_Name;
    public Text Quest_item;

    public int Quest_item_count = 0;


    void Update()
    {
        if (Quest_item_count >= Items.MaxCnt)
        {
            Quest_Name.text = "이 곳을 탈출하라";
            Quest_item.text = "무전기를 작동시켜라";
        }
        else
        {
            Quest_Name.text = "아이템을 전부 획득하라.";
            Quest_item.text = "item " + Quest_item_count.ToString() +"/"+Items.MaxCnt.ToString();
        }
    }
}
