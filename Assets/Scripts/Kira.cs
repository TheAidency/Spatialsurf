using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kira : MonoBehaviour
{
    public float speed =10f;
    public GameObject ScoreMan;

    private void Start()
    {
        ScoreMan = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Finish")
        {
            ScoreMan.GetComponent<GameManager>().score++;
            Destroy(this.gameObject);
        }

        if (other.tag == "Player")
        {
            ScoreMan.GetComponent<GameManager>().Endgame();
        }
    }

    private void Update()
    {
        this.GetComponent<Rigidbody>().velocity = new Vector3(0,0,speed);
    }
}
