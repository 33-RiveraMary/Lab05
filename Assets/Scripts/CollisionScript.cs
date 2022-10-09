using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollisionScript : MonoBehaviour
{
    //score
    public int goal;
    public int score;
    public Text scoreTxt;

    //timer
    public bool timeRunning;
    public float time;
    public Text timeTxt;

    public GameObject partPrefab;


    // Start is called before the first frame update
    void Start()
    {
        goal = GameObject.FindGameObjectsWithTag("Coin").Length;
    }

    // Update is called once per frame
    void Update()
    {
        //timer
        if (timeRunning)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
                DisplayTime(time);

                if (score == goal * 10)
                {
                    SceneManager.LoadScene("GameWinScene");
                }
            }
            else
            {
                time = 0;
                DisplayTime(time);
                timeRunning = false;

                SceneManager.LoadScene("GameLoseScene");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            score += 10;
            scoreTxt.text = "Score: " + score;

            Destroy(other.gameObject);
            Instantiate(partPrefab, other.gameObject.transform.position, Quaternion.identity);
        }

        if (other.gameObject.tag == "Water")
        {
            SceneManager.LoadScene("GameLoseScene");
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float secs = Mathf.FloorToInt(timeToDisplay % 60);
        timeTxt.text = "Time Left: " + secs;
    }
}
