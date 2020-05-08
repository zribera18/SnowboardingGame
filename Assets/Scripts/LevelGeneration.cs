using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] objects;

    void Start()
    {
        int rand = Random.Range(0, objects.Length);
        GameObject newnew =  Instantiate(objects[rand], transform.position, Quaternion.identity);
        newnew.transform.localScale = new Vector3(100,100,100);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
