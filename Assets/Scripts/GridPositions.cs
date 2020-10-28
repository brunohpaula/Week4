using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPositions : MonoBehaviour
{
    public Transform leftPole;
    public Transform rightPole;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3[] GenerateLanes(int numberOfLanes)
    {
        //creates an array of vector3 where all available positions will be set
        Vector3[] runningLanes = new Vector3[numberOfLanes];

        //using the two poles (see objects above) calculates the available distance and divides it by the number of lanes you want
        //plus one, so we have a safe distance from the initial (left) pole
        float safeDistance = (Mathf.Abs(leftPole.position.z) + Mathf.Abs(rightPole.position.z))/ (numberOfLanes + 1);
        
        //initial pos is where the grid will be set - we start from the left pole plus one measure calculated earlier (hence the division by numberoflanes +1)
        float initialPos = leftPole.position.z + safeDistance;

        //just iterates through all positions calculating safe margins for runners according to the # of the iteration
        //saves that in a Vector3 array
        for (int i = 0; i < numberOfLanes; i++)
        {
            runningLanes[i] = new Vector3(leftPole.position.x, leftPole.position.y, initialPos + (safeDistance * i));
        
        }

        //gives that Vector3 array back
        return runningLanes;
    }

}
