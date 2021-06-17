using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ActionController : MonoBehaviour
{
    [SerializeField]
    private float range; // 습득 가능한 최대 거리.
    private bool pickupActivated = false; // 습득 가능할 시 true.
    private RaycastHit hitInfo; // 총돌체 정보 저장.

    // 아이템 레이어에만 반응하도록 레이어 마스크를 설정.
    [SerializeField]
    private LayerMask layerMask;

    // 필요한 컴포넌트.
    [SerializeField]
    private Text actionText;

    //------------------------------------------
    private Quest_Text questtext;
    private AudioSource backGroundMixer;
    private AudioSource pageOneMixer;
    private AudioSource pageTwoMixer;
    
    // Update is called once per frame
    void Update()
    {
        CheckItem();
        TryAction();
    }

    private void TryAction()
    {
        if(Input.GetKeyDown(KeyCode.E)) // 키보드 E키를 눌렀을 때
        {
            CheckItem();
            CanPickUp();
        }
    }

    private void CanPickUp()
    {
        if(pickupActivated)
        {
            if(hitInfo.transform != null)
            {
                questtext = GameObject.Find("In_Game_Ui").GetComponent<Quest_Text>();
                questtext.Quest_item_count++;
                if (questtext.Quest_item_count >= 1 && questtext.Quest_item_count <= 2)
                {
                    backGroundMixer = GameObject.Find("Background_Audio").GetComponent<AudioSource>();
                    backGroundMixer.enabled = false;
                    pageOneMixer = GameObject.Find("Page1_Audio").GetComponent<AudioSource>();
                    pageOneMixer.enabled = true;
                }
                else if (questtext.Quest_item_count >= 3 && questtext.Quest_item_count <= 4)
                {
                    pageOneMixer = GameObject.Find("Page1_Audio").GetComponent<AudioSource>();
                    pageOneMixer.enabled = false;
                    pageTwoMixer = GameObject.Find("Page2_Audio").GetComponent<AudioSource>();
                    pageTwoMixer.enabled = true;
                }
                Debug.Log(hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " 획득했습니다");
                Destroy(hitInfo.transform.gameObject);
                InfoDisappear();
                
                //-------------------------------------

            }
        }
    }

    private void CheckItem()
    {
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo, range, layerMask))
        {
            if(hitInfo.transform.tag == "Item")
            {
                ItemInfoAppear();
            }
            
        }
        else
            InfoDisappear();
    }

    private void ItemInfoAppear()
    {
        pickupActivated = true;
        actionText.gameObject.SetActive(true);
        actionText.text = hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " 획득 " + "(E)";
    }

    private void InfoDisappear()
    {
        pickupActivated = false;
        actionText.gameObject.SetActive(false);
    }
}
