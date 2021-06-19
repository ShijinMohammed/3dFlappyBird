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
        FCScript = GetComponent<FlappyControlScript>();

        SpawnRandomPipe(5);
    }
    private void OnTriggerExit(Collider other) 
    {
        if(other.transform.tag == "Checkpoint")
        {
            if(FCScript.score%5 == 0)
                SpawnRandomPipe(5);
            
            FCScript.score++;
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.transform.tag == "Pipe")
        {
            FCScript.GameOver();
        }
    }

    void SpawnRandomPipe(int times)
    {
        int offset = 20;

        if(initialSpawn){
            offset = 0;
            initialSpawn = false;
        }
        
        for(int i = 1; i<=times;i++)
        {
            int x = Random.Range(0,ObstacleList.Length);
            Instantiate(ObstacleList[x],new Vector3(transform.position.x+(5*i)+offset,Random.Range(-2f,2.5f),transform.position.z),Quaternion.identity);
        }
    }
}
