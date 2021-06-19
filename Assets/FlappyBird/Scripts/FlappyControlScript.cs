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
        scoreText.text = score.ToString();
        
        myRigid.velocity = new Vector3(2,myRigid.velocity.y,myRigid.velocity.z);

        Quaternion rot = Quaternion.LookRotation(myRigid.velocity.normalized, Vector3.up);


        transform.GetChild(0).rotation = Quaternion.Slerp(transform.GetChild(0).rotation,rot,0.05f);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            myRigid.velocity = new Vector3(myRigid.velocity.x,0,myRigid.velocity.z);
            myRigid.AddForce(Vector3.up*5,ForceMode.Impulse);
        }
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        GOPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
