using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Gameplay")]
    public GameObject PlayerShip;
    public GameObject RNGSpawner;
    public GameObject UIH;
    public bool GameplayActive = false;
    public bool LeftSide = true;
    public float speed;
    public float spawnFrequency = 1f;
    public int score;
    public int hscore;

    [Header("Transforms")]
    public Transform Left;
    public Transform Center;
    public Transform Right;

    [Header("Spawns")]
    public Transform LeftSpawn;
    public Transform RightSpawn;

    // Update is called once per frame
    void Update()
    {
        if (GameplayActive)
        {
            #region Side Switching and Movement
            if (Input.GetMouseButtonDown(0))
            {
                if (LeftSide)
                    LeftSide = false;
                else LeftSide = true;
            }

            if (LeftSide)
            {
                PlayerShip.transform.position = Vector3.Lerp(PlayerShip.transform.position, Left.position, speed * Time.deltaTime);
            }
            else
            {
                PlayerShip.transform.position = Vector3.Lerp(PlayerShip.transform.position, Right.position, speed * Time.deltaTime);
            }
            #endregion
            if (score > hscore)
            {
                hscore = score;
            }

        }
        else
        {
            PlayerShip.transform.position = Vector3.Lerp(PlayerShip.transform.position, Center.position, speed * Time.deltaTime);
        }

        
    }


    //Enum that calls itself every x seconds
    int rngCounter = 0;
    int prevFlag = 0;
    public IEnumerator SpawnLoop()
    {
        if (GameplayActive)
        {
            int LRFlag = Random.Range(0, 2);
            //Debug.Log("Before: " + LRFlag);
            if (LRFlag == prevFlag)
            {
                rngCounter++;
            }
            if (rngCounter > 2)
            {
                if (LRFlag == 0)
                {
                    LRFlag = 1;
                }
                else LRFlag = 0;
                rngCounter = 0;
            }
            prevFlag = LRFlag;
            if (LRFlag == 0)
            {
                GameObject.Instantiate(RNGSpawner, LeftSpawn.position, LeftSpawn.rotation);
            }
            else GameObject.Instantiate(RNGSpawner, RightSpawn.position, RightSpawn.rotation);

            yield return new WaitForSeconds(spawnFrequency);
            StartCoroutine(SpawnLoop());
        }
    }

    public void Endgame()
    {
        UIH.GetComponent<UIHandler>().gameOver();
    }



}

