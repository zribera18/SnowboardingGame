using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{

  public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 100f;

    }

    // Update is called once per frame
    void Update()
    {
      print(Input.GetAxis("Horizontal"));
      print(Input.GetAxis("Vertical"));
      transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, 0f);

      //

    }
}
