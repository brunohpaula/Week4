using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject myPrefab;

    //This array holds all lane positions for runners - if you want to understand how it works, look at 
    //GridPositions.cs - not needed to be understood for this task
    private Vector3[] runningLanes;


    private GameObject[] allRunners;

    //T1 - Expose the variable numberOfRunners below, so you can set it in UnityEditor
    int numberOfRunners;

    //T2, T3 - Declare a new variable to be "your" position


    

    // Start is called before the first frame update
    void Start()
    {        

        //Declares a new array with the size of NumberOfRunners
        allRunners = new GameObject[numberOfRunners];

        //Creates running lanes according to the number of runners
        //please notice this is not an Unity function - this is all detailed in GridPositions.cs
        runningLanes = GetComponent<GridPositions>().GenerateLanes(numberOfRunners);


        //This now generates only one "runner"
        //you must make a loop, calling "CreateRunner()" multiple times according to the variable "numberOfRunners"      
        //T1 - Create a loop here
        {
            //T1 - substitute the HARDCODED values below...
            allRunners[0] = CreateRunner();
            //Position Runner in the correct running lane            
            allRunners[0].transform.position = runningLanes[0];
        }
        

    }


    // Update is called once per frame
    private void Update()
    {
        
    }
    

    /// <summary>
    /// in the regular task there's nothing to be altered here...
    /// 
    /// this just Instantiates and give you a runner using the prefab linked to the variable myPrefab
    /// </summary>
    /// <returns></returns>
    private GameObject CreateRunner()
    {        

        //creates an object selecting a random prefab from your collection
        GameObject tempClone = Instantiate(myPrefab);

        //positions it at the startPosition - this should be set at the Editor        

        return tempClone;
    }
   

    public void AllSmall()
    {
        //TASK 1
        //Create a loop that makes you ALL RUNNERS smaller

        //you will need
        //1 - a loop
        //2 - to reduce the object's size using localScale
        //________.transform.localScale *= 0.5f; (for example)
    }




    public void IncreaseSlowerRunners()
    {
        //TASK 2
        //Create a loop that makes you and all runners after your position bigger

        //you will need
        //1 - a loop
        //2 - to reduce the object's size using localScale
        //________.transform.localScale *= 2f; (for example)
    }

    public void ReduceFasterRunners()
    {
        //TASK 3
        //Create a loop that makes all runners before your position smaller

        //you will need
        //1 - a loop
        //2 - to reduce the object's size using localScale
        //________.transform.localScale *= 0.5f; (for example)
    }

    public void FullThunderbolt()
    {
        //EXTRA TASK

        //Do both things at the same time (before smaller, you and after bigger)
    }

}
