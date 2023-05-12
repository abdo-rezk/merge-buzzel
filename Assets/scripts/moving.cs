using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class moving : MonoBehaviour
{
    Vector3 mousePosOffset;
    public GameObject game_over_panel,game_panel;

    public generate_box obj;
    private Vector3 GetMouseWorldPos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {

        mousePosOffset = gameObject.transform.position - GetMouseWorldPos();
        
    }
    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos()+ mousePosOffset;
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("boxs"))
        {
            if (collision.transform.GetChild(0).GetComponent<Text>().text ==
               this.transform.GetChild(0).GetComponent<Text>().text)
            {
                int double_number = int.Parse(collision.transform.GetChild(0).GetComponent<Text>().text);
                Destroy(collision.gameObject);
                if (double_number * 2 < 1024)
                {
                    this.transform.GetChild(0).GetComponent<Text>().text = (double_number * 2).ToString();
                    this.gameObject.GetComponent<Image>().color = obj.list_drowing[(obj.mp[double_number * 2])%8];
                }
                if (PlayerPrefs.HasKey("Currunt_score"))
                {
                    int new_currunt_score = PlayerPrefs.GetInt("Currunt_score");
                    new_currunt_score += double_number * 2;
                    PlayerPrefs.SetInt("Currunt_score", new_currunt_score);
                }
                else
                {
                    PlayerPrefs.SetInt("Currunt_score", double_number * 2);
                }
            }
            
        }else if (collision.gameObject.CompareTag("boarder"))
        {
            game_over_panel.SetActive(true);
            game_panel.SetActive(false);
        }
    }

}
