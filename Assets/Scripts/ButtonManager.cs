using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //unlock cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    //restart game
    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }
}
