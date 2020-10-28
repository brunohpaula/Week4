using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject myPrefab;
    private GameObject[] allRunners;    
    public int numberOfRunners;    
    private Vector3[] runningLanes;

    private int myPos = 2;   

    // Start is called before the first frame update
    void Start()
    {        
        allRunners = new GameObject[numberOfRunners];

        //Creates running lanes according to the number of runners
        //please notice this is not an Unity function - this is all detailed in GridPositions.cs
        runningLanes = GetComponent<GridPositions>().GenerateLanes(numberOfRunners);


        //This now generates only one "runner"
        //you must make a loop, calling "CreateRunner()" multiple times
        for (int counter = 0; counter < numberOfRunners; counter++)
        {
            allRunners[counter] = CreateRunner();


            //Position Runner in the correct running lane            
            allRunners[counter].transform.position = runningLanes[counter];
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
        foreach (GameObject g in allRunners)
        {
            g.transform.localScale *= 0.5f;
        }
    }


    public void FullThunderbolt()
    {
        for (int i = 0; i < allRunners.Length; i++)
        {
            if (i < myPos)
            {
                allRunners[i].transform.localScale *= 0.5f;
            }
            else
            {
                allRunners[i].transform.localScale *= 2f;
            }
        }
    }
    
    public void IncreaseSlowerRunners()
    {
        for (int i = myPos; i < allRunners.Length; i++)
        {
            allRunners[i].transform.localScale *= 2f;
        }
    }

    public void ReduceFasterRunners()
    {
        for (int i = 0; i < myPos; i++)
        {
            allRunners[i].transform.localScale *= 0.5f;
        }
    }

}
