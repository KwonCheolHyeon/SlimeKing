using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameStart : MonoBehaviour
{
    public GameObject subMenu;
    
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
       


    }

    public void GameStarts()
    {
       
        SceneManager.LoadScene("Main");
        Time.timeScale = 1;
        JumpKing.regam = true;
    }
    public void GameExit()
    {
        Application.Quit();
    }

}