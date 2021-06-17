using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class ActionController : MonoBehaviour
{
    [SerializeField]
    private float range; // 습득 가능한 최대 거리.
    private bool pickupActivated = false; // 습득 가능할 시 true.
    private RaycastHit hitInfo; // 총돌체 정보 저장.
    private Quest_Text questtext;

    // 아이템 레이어에만 반응하도록 레이어 마스크를 설정.
    [SerializeField]
    private LayerMask layerMask;

    // 필요한 컴포넌트.
    [SerializeField]
    private Text actionText;
    [SerializeField]
    private Text activeText;
    // -----------------------------------------

    //------------------------------------------
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
                
                //-------------------------------------

                if(questtext.Quest_item_count >= Items.MaxCnt)
                {
                    Debug.Log(hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " 활성화 성공!");
                    SceneManager.LoadScene(3);
                }
                else
                {
                    questtext.Quest_item_count++;
                    Debug.Log(hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " 획득했습니다");
                    Destroy(hitInfo.transform.gameObject);
                }

                
                if (questtext.Quest_item_count >= 1 && questtext.Quest_item_count <= 2)
                {
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

                InfoDisappear();
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
            else if(hitInfo.transform.tag == "Active")
            {
                ActiveInfoAppear();
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

    private void ActiveInfoAppear()
    {
        if (questtext.Quest_item_count <= Items.MaxCnt)
        {
            pickupActivated = true;
            activeText.gameObject.SetActive(true);
            activeText.text = hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " 활성화 " + "(E)";
        }
        else
        {
            pickupActivated = false;
            activeText.gameObject.SetActive(true);
            activeText.text = hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " 활성화 불가능";
        }
    }

    private void InfoDisappear()
    {
        pickupActivated = false;
        actionText.gameObject.SetActive(false);
        activeText.gameObject.SetActive(false);
    }
}
