using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FlappyControlScript : MonoBehaviour
{
    public int score;
    private Rigidbody myRigid;
    public Text scoreText;
    public GameObject GOPanel;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        myRigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //score display
        scoreText.text = score.ToString();
        
        // Sets the X axis velocity of the bird to 2
        myRigid.velocity = new Vector3(2,myRigid.velocity.y,myRigid.velocity.z);

        //Convert the velocity direction into rotation(Quaternion)
        Quaternion rot = Quaternion.LookRotation(myRigid.velocity.normalized, Vector3.up);

        //Rotate the flappy bird body smoothly to the rotation we obtained earlier
        transform.GetChild(0).rotation = Quaternion.Slerp(transform.GetChild(0).rotation,rot,0.05f);


        //If Space was pressed (True for only one frame where the key was pressed)
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // Set Y Axis velocity to 0
            myRigid.velocity = new Vector3(myRigid.velocity.x,0,myRigid.velocity.z);

            // Add an upward impulsive force
            myRigid.AddForce(Vector3.up*5,ForceMode.Impulse);
        }
    }
    public void GameOver()
    {
        // Pause the game
        Time.timeScale = 0;

        //Enable Game Over Panel
        GOPanel.SetActive(true);
    }

    public void Restart()
    {
        //Reload the scene
        SceneManager.LoadScene(0);
    }
}
