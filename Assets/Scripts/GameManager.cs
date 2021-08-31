using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    //게이지 시스템
    public Image guage;
    public bool gaugestart = false;
    public float guageRedcutionRate = 0.0005f; 
    

    //하트 시스템
    public int health;
    public int numofHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    //코인 
    public static float jellyHp;
    public static int discount;

    //서브 메뉴
    public GameObject subMenu;
    bool IsPause;

    //게임 오버
    public GameObject gameoverMenu;
    public static bool gameoverkey = false;



    void GaugeReduce()
    {

        if (gaugestart && IsPause == false)
        {
            guage.fillAmount = guage.fillAmount + jellyHp  - guageRedcutionRate;

            if (guage.fillAmount > 1)
            {
                guage.fillAmount = 1;
            }
            if (jellyHp >= 0)
            {
                jellyHp = 0;
            }
        }
        Invoke("GaugeReduce", 0.01f);
    }

    void Start()
    {
        
        IsPause = false;
        
    }

    void Awake()
    {
        GaugeReduce();

    }

    // Update is called once per frame
    void Update()
    {
        
        health2();
        healths();
      
        
        //sub menu
        if (Input.GetButtonDown("Cancel"))
        {
            Time.timeScale = 0;
            IsPause = true;
            if (subMenu.activeSelf)
            {
                subMenu.SetActive(false);
              
            }
            else
            {
                subMenu.SetActive(true);  
            }
        }

        if (gameoverkey) 
        {

            gameoverkey = false;

            if (gameoverMenu.activeSelf)
            {
                gameoverMenu.SetActive(false);
            }
            else
            {
                gameoverMenu.SetActive(true);
            }

        }
            


    }


    void health2() // 하트 이미지 
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (health > numofHearts)
            {
                health = numofHearts;

            }

            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numofHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }


    void healths() //게이지 줄어들면 
    {
        if (discount == -1) 
        {
            health = health + discount;
            discount = 0;
            guage.fillAmount = 1; 
        }


        if (guage.fillAmount == 0)
        {
            if (health >= 1)
            {
                guage.fillAmount = 1;
            }

            health = health - 1;

        }
        /*
        if (health == -1)
        {
            health = health - 1;
            Debug.Log("health 0 보다 작다");
            JumpKing.deathEvent = true;
        }
        */
    }

    public void GameExit() 
    {
        Application.Quit();
    }

    public void Cotinue() 
    {
        Time.timeScale = 1;
        IsPause = false;
    }

    public void GoMenu() 
    {
        SceneManager.LoadScene("Meun");

    }

    public void GameStart() 
    {

        SceneManager.LoadScene("Main");
    }
    public void Restart() 
    {

        SceneManager.LoadScene("Main");
        Time.timeScale = 1;
    }
    public void PauseKey() 
    {
        Time.timeScale = 0;
        IsPause = true;
        if (subMenu.activeSelf)
        {
            subMenu.SetActive(false);

        }
        else
        {
            subMenu.SetActive(true);
        }

    }



}


 
