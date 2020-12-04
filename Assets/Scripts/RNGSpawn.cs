using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RNGSpawn : MonoBehaviour
{
    public GameObject Rock;
    public GameObject[] Pickups;
    // Start is called before the first frame update
    void Start()
    {
        int Spawn = Random.Range(0, 100);
        if (Spawn > 70)
        {
            /*( int i = Random.Range(0, Pickups.Length);
             {
                GameObject.Instantiate(Pickups[i], transform.position, transform.rotation);
             }*/
        }
        else
        {
            GameObject.Instantiate(Rock, transform.position, transform.rotation, this.gameObject.transform);
        }
    }
}
