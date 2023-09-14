using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript_Cubes : MonoBehaviour
{

    float timeUntilNextTurn = 3f;

    void Update()
    {
        timeUntilNextTurn -= Time.deltaTime;
        if (timeUntilNextTurn < 0)
        {
            RotateCubes();
        }
    }

    public void RotateCubes()
    {
        
    }
}
