using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public LevelPiece[] levelPieces;
    public Transform _camera;
    public int drawDistance;
    // Start is called before the first frame update
    public float pieceLength;
    public float startingLength;

    
    void Start()
    {
        // Spawn starting level LevelPiece
        for (int i = 0; i < drawDistance; i ++){
          GameObject newLevelPiece = Instantiate(levelPieces[0].prefab, new Vector3(startingLength + (pieceLength * i), 0f, 0f), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

[System.Serializable]
public class LevelPiece {
  public string name;
  public GameObject prefab;
  public int probability = 1;
}
