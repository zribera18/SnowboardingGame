using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
  public float moveSpeed;
  public float centerSpeed;

  public float rotationY = 0f;
  public float startingRotation = 90f;
  public float brakingRoation = 0f;


    // Start is called before the first frame update
    void Start()
    {
      moveSpeed = 50f;
      centerSpeed = 2f;
      transform.localEulerAngles = new Vector3(0, startingRotation, -0);
    }

    // Update is called once per frame
    void Update()
    {
      Debug.Log("horizontal axis: " + Input.GetAxis("Horizontal"));

      // Braking
      if (Input.GetAxis("Vertical") < 0){
        transform.localEulerAngles = new Vector3(0,brakingRoation, 0f );
      }
      // Turning
      else if (Input.GetAxis("Horizontal") != 0){
        rotationY = (transform.localEulerAngles.y) + moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        float clampedRotation = Mathf.Clamp(rotationY, 0, 180);
        transform.localEulerAngles = new Vector3(0, clampedRotation, -0);
      }
      // Return to center on no input
      else if(transform.localEulerAngles.y <= 89.5 || transform.localEulerAngles.y >= 90.5) {
        float return_center = Mathf.Sign(transform.localEulerAngles.y - 90) * centerSpeed;
        float rotation = transform.localEulerAngles.y - return_center;
        transform.localEulerAngles = new Vector3(0, rotation, 0);
      }
    }
}
