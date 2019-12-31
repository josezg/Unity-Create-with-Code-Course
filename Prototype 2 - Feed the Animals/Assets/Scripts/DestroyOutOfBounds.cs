using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float _topBound = 30.0f;//Position limit for projectiles
    private float _lowerBound = -10.0f;//Position limit for animals
    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > _topBound)//Condition for destroy projectiles that passed the top bound
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < _lowerBound)//Condition for destroy animals that passed the bottom bound
        {
            Destroy(gameObject);
            Debug.Log("Game Over!");
        }
    }
}
