using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class generate_box : MonoBehaviour
{
    GameObject[] squares; 
    public GameObject prefapsquare;
    public GameObject feature_panel, Panel_game,game_over_panel,music_panel;
    public Text score;
    void Start()
    {      
        Panel_game.SetActive(true);
        feature_panel.SetActive(false);
        game_over_panel.SetActive(false);
        music_panel.SetActive(false);
        repet(2.1f, -4.1f);
        repet(1.1f, -4.1f);
        repet(-1.1f, -4.1f);
        repet(-2.1f, -4.1f);
        PlayerPrefs.SetInt("Currunt_score", 0);

    }

    public List<int> list_number = new List<int> { 2, 4, 8, 16, 32, 64 ,128,256,512};
    public Dictionary<int, int> mp = new Dictionary<int, int> { { 2, 0 }, { 4, 1 }, { 8, 2 }, { 16, 3 }, { 32, 4 }, { 64, 5 }, { 128, 6 }, { 256, 7 },{ 512, 8} };
    public List<Color> list_drowing = new List<Color> {Color.white,Color.green,Color.red, Color.blue, Color.cyan, Color.gray, Color.yellow,Color.magenta };
    public void repet(float f,float l)
    {
        int index = Random.Range(0,6);
        var position = new Vector3(f, l, 0);
        GameObject o=Instantiate(prefapsquare, position, Quaternion.identity ,GameObject.FindGameObjectWithTag("grid").transform)as GameObject;
        o.transform.GetChild(0).GetComponent<Text>().text= list_number[index].ToString();// text number 0 in component
        o.gameObject.GetComponent<Image>().color = list_drowing[index];
    }
    void Update()
    {
        squares = GameObject.FindGameObjectsWithTag("boxs");
        if (Input.GetButtonDown("Jump"))
        {
            for(int i=0;i< squares.Length; i++)
            {
                squares[i].transform.position = new Vector3(squares[i].transform.position.x, squares[i].transform.position.y+1, 0);
            }
            repet(2.1f, -4.1f);
            repet(1.1f, -4.1f);
            repet(-1.1f, -4.1f);
            repet(-2.1f, -4.1f);
        }

        score.text ="Score: "+ PlayerPrefs.GetInt("Currunt_score").ToString();
        if (PlayerPrefs.HasKey("high_score"))
        {
            int old_score = PlayerPrefs.GetInt("high_score");
            old_score = Mathf.Max(old_score, PlayerPrefs.GetInt("Currunt_score"));
            PlayerPrefs.SetInt("high_score", old_score);
        }
        else
        {
            PlayerPrefs.SetInt("high_score", PlayerPrefs.GetInt("Currunt_score"));
        }
    }
    public void change_feature_mode()
    {
        feature_panel.SetActive(true);
        Panel_game.SetActive(false);
    }
    public void Resume()
    {
        feature_panel.SetActive(false);
        Panel_game.SetActive(true);
    }
    public void change_ToMenu()
    {
        Panel_game.SetActive(false);
        SceneManager.LoadScene("main_menu");
    }
    public void go_to_music()
    {
        music_panel.SetActive(true);
        feature_panel.SetActive(false);
    }public void back_to_feature()
    {
        music_panel.SetActive(false);
        feature_panel.SetActive(true);
    }
}
