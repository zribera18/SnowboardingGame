using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAtScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
  	public Vector3 offset;


  	// Use this for initialization
  	void Start () {

  	}

  	// Update is called once per frame
  	void Update () {
  		transform.position = target.position + offset;
  		transform.LookAt(target.transform);
  	}
}
