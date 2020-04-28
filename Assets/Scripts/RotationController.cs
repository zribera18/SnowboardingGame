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

  public float currentSpeed;
  public Rigidbody rb;
  public float last_input;


    // Start is called before the first frame update
    void Start()
    {
      moveSpeed = 50f;
      currentSpeed = moveSpeed;
      centerSpeed = 2f;
      transform.localEulerAngles = new Vector3(0, startingRotation, -0);

      rb = GetComponent<Rigidbody>();
    }

    // TODO: Make turn rotation factor of speed
    // TODO: Fix gittering while trying to find absolute forward angle
    // TODO: Get procedural level gen, possible in both x and y axis

    // Update is called once per frame
    void Update()
    {
      // Debug.Log("horizontal axis: " + Input.GetAxis("Horizontal"));
      Debug.Log("rb velocity: " + rb.velocity);

      // Braking
      if (Input.GetAxis("Vertical") < 0){
        if (last_input > 0){
        transform.localEulerAngles = new Vector3(0,180f, 0f );
      } else {
        transform.localEulerAngles = new Vector3(0, brakingRoation, 0);
      }
        rb.velocity = new Vector3((float)rb.velocity.x * 0.1f, 0f, 0f);
        rb.angularVelocity = new Vector3((float)rb.angularVelocity.x * 0.1f, 0f, 0f);
      }else {
      // Turning
      if (Input.GetAxis("Horizontal") != 0){
        last_input = Mathf.Sign(Input.GetAxis("Horizontal"));
        rotationY = (transform.localEulerAngles.y) + currentSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        float clampedRotation = Mathf.Clamp(rotationY, 0, 180);
        transform.localEulerAngles = new Vector3(0, clampedRotation, (clampedRotation / 5) * Input.GetAxis("Horizontal") * -1);
      }
      // Return to center on no input
      else if(transform.localEulerAngles.y <= 89.5 || transform.localEulerAngles.y >= 90.5) {
        float return_center = Mathf.Sign(transform.localEulerAngles.y - 90) * centerSpeed;
        float rotation = transform.localEulerAngles.y - return_center;
        transform.localEulerAngles = new Vector3(0, rotation, 0);
      }

      rb.velocity = transform.forward * currentSpeed;
    }

    currentSpeed += Time.deltaTime * 10f;
    }
}
