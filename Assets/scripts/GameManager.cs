using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject menu_panel,  score_panel , setting_panel, music_panel, tips_panel,  tip_image1, tip_image2;
    public Text high_score;
    private void Start()
    {
        menu_panel.SetActive(true);
        score_panel.SetActive(false);
        music_panel.SetActive(false);
        setting_panel.SetActive(false);
        tips_panel.SetActive(false);
        tip_image1.SetActive(false);
        tip_image2.SetActive(false);
    }
    private void Update()
    {
        high_score.text = PlayerPrefs.GetInt("high_score").ToString();
    }
    public void change_ToPlay_mode()
    {
        menu_panel.SetActive(false);
        SceneManager.LoadScene("game");
    }
  
    public void change_To_setting_mode()
    {
        setting_panel.SetActive(true);
        menu_panel.SetActive(false);
    }
    public void back_To_menu_mode_from_setting()
    {
        setting_panel.SetActive(false);
        menu_panel.SetActive(true);
    }
    public void go_to_score()
    {
        score_panel.SetActive(true);
        setting_panel.SetActive(false);
    } public void go_to_music()
    {
        music_panel.SetActive(true);
        setting_panel.SetActive(false);
    } public void go_to_tips()
    {
        tips_panel.SetActive(true);
        setting_panel.SetActive(false);
    }
    public void back_To_setting_mode_from_score()
    {
        setting_panel.SetActive(true);
        score_panel.SetActive(false);
    }
    public void back_To_setting_mode_from_music()
    {
        setting_panel.SetActive(true);
        music_panel.SetActive(false);
    }
    public void back_To_setting_mode_from_tips()
    {
        setting_panel.SetActive(true);
        tips_panel.SetActive(false);
    }
    public void next_To_image1_from_tips()
    {
        tip_image1.SetActive(true);
        tips_panel.SetActive(false);
    }
    public void back_To_tips_from_image1()
    {
        tip_image1.SetActive(false);
        tips_panel.SetActive(true);
    } public void next_To_image2_from_image1()
    {
        tip_image2.SetActive(true);
        tip_image1.SetActive(false);
    }
    public void back_To_image1_from_image2()
    {
        tip_image2.SetActive(false);
        tip_image1.SetActive(true);
    }public void Exit()
    {
        Application.Quit();
    }
}
