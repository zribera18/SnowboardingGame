using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
  public Transform target;
  public float damping;
  public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate () {
  		float currentAngle = transform.eulerAngles.y;
  		float desiredAngle = target.transform.eulerAngles.y;
  		float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * damping);

  		Quaternion rotation = Quaternion.Euler(0, angle, 0);
  		transform.position = target.transform.position - offset;

  		transform.LookAt(target.transform);
  	}
}
