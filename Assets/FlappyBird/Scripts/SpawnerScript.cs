using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject[] ObstacleList;
    private FlappyControlScript FCScript;
    bool initialSpawn = true;

    // Start is called before the first frame update
    void Start()
    {
        // Assign the FlappyControlScript assigned to this gameobject to the FCScript variable
        FCScript = GetComponent<FlappyControlScript>();

        //Spawn 5 random pipes when the game starts
        SpawnRandomPipe(5);
    }
    private void OnTriggerExit(Collider other) 
    {
        //If the tag of the gameobject we triggered with was "Checkpoint"
        if(other.transform.tag == "Checkpoint")
        {
            //If the number pf the pipe we are passing through is a multiple of 5
            if(FCScript.score%5 == 0)
                //Spawn another 5 pipes
                SpawnRandomPipe(5);
            
            //Increment the score of the flappybird by 1
            FCScript.score++;
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        //If the tag of the gameobject we collided with was "Pipe"
        if(other.transform.tag == "Pipe")
        {
            // Call GameOver function
            FCScript.GameOver();
        }
    }

    void SpawnRandomPipe(int times)
    {
        // Offset value is added to the X axis of the bird and then pipe is spawned there
        int offset = 20;

        // If this function was called in the first frame
        if(initialSpawn){
            offset = 0;
            initialSpawn = false;
        }
        
        for(int i = 1; i<=times;i++)
        {
            //Find a random index value from the range 0 - Length of the Obstacle array
            int x = Random.Range(0,ObstacleList.Length);
            //Spawn a random obstacle at a location offsetted from the flappybird in X direction
            Instantiate(ObstacleList[x],new Vector3(transform.position.x+(5*i)+offset,Random.Range(-2f,2.5f),transform.position.z),Quaternion.identity);
        }
    }
}
