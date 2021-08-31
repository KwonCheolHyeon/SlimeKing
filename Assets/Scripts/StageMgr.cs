using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMgr : MonoBehaviour
{
    public static StageMgr Instance // singlton     
    {
        get
        {
            if ( instance == null )
            {
                instance = FindObjectOfType<StageMgr> ( );
                if ( instance == null )
                {
                    var instanceContainer = new GameObject ( "StageMgr" );
                    instance = instanceContainer.AddComponent<StageMgr> ( );
                }
            }
            return instance;
        }
    }


    private static StageMgr instance;

    public Camera theCamera;

    public GameObject Player;

    [System.Serializable]
    public class StartPositionArray
    {
        public List<Transform> StartPosition = new List<Transform> ( );
    }
    public StartPositionArray[] startPositionArrays;
    // 0 1 2
    //startPositionArrays[0] 1~10 Stage
    //startPositionArrays[1] 11~20 Stage
    //방 20개 만들어서 각 방의 시작위치를 입력한다.

    [System.Serializable]
    public class CameraPositionArray
    {
        public List<Transform> CameraPosition = new List<Transform>();
    }
    public CameraPositionArray[] cameraPositionArrays;
     

    public List<Transform> StartPositionAngel = new List<Transform> ( );
    public List<Transform> AngelCameraPosition = new List<Transform>();
    // 천사방 3개 

    // 보스 3개
    public Transform StartPositionLastBoss;
    public Transform LastBossCameraPosition;
    // 막보 하나

    public int currentStage = 0;  //현재 방위치
    int LastStage = 61; // 막보방

    // Start is called before the first frame update
    void Start ( )
    {
        Player = GameObject.FindGameObjectWithTag ( "Player" );
       
    }


    //위에 저장된 위치로 다음 장소 이동

    public void NextStage ( )
    {
        currentStage++;
        if(currentStage > LastStage)
        { 
            return; 
        }
        //currentStage % 5 != 0
        if ( currentStage >= 0 && currentStage != 30 && currentStage != 60 )  //Normal Stage
        {
            int arrayIndex = currentStage / 10;
            int randomIndex = Random.Range ( 0, startPositionArrays[arrayIndex].StartPosition.Count );

            Player.transform.position = startPositionArrays[arrayIndex].StartPosition[randomIndex].position;
            startPositionArrays[arrayIndex].StartPosition.RemoveAt(randomIndex);

            theCamera.transform.position = cameraPositionArrays[arrayIndex].CameraPosition[randomIndex].position;
            cameraPositionArrays[arrayIndex].CameraPosition.RemoveAt(randomIndex);
        }
        else    //BossRoom or Angel
        {
            
            if ( currentStage  == 30 )   // Angel
            {
                int randomIndex = Random.Range ( 0, StartPositionAngel.Count );
                Player.transform.position = StartPositionAngel[randomIndex].position;
                theCamera.transform.position = AngelCameraPosition[randomIndex].position;
               
            }
            else    //Boss
            {
                Player.transform.position = StartPositionLastBoss.position;
                theCamera.transform.position = LastBossCameraPosition.position;

                /*
                if ( currentStage == LastStage )  //LastBoss
                {
                    Player.transform.position = StartPositionLastBoss.position;
                }
                else    //Mid Boss
                {
                    int randomIndex = Random.Range ( 0, StartPositionBoss.Count );
                    Player.transform.position = StartPositionBoss[randomIndex].position;
                    StartPositionBoss.RemoveAt ( currentStage / 10 );
                }
                */
            }

        }

       
    }
}
