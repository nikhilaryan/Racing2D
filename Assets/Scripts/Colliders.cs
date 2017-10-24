using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Colliders : MonoBehaviour {
    public Text gameover;
    public Text Lap;
    public int Laps = 0;
    public int i = 0;
    private IEnumerator coroutine;

    // Use this for initialization
    void Start()
    {

        // Update is called once per frame
    }
    IEnumerator OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player")
        {
            Laps++;
            Lap.text = "Lap:" + (Laps).ToString() + "/2";

        }

        if (Laps >1)
        {
            i++;
            if (i == 2)
            {

                if (collision.tag == "Enemy")
                {
                    gameover.text = "Game over";
                    yield return new WaitForSeconds(5.0f);

                    //StartCoroutine(wait(1000.0f));
                    
                    SceneManager.LoadScene(0);
                }
                else if (collision.tag == "Player")
                    gameover.text = "You won";
                yield return new WaitForSeconds(5.0f);
                SceneManager.LoadScene(0);
                // StartCoroutine(wait(1000.0f));


            }
        }
    }
   //private IEnumerator wait(float time) {
   //     yield return new WaitForSeconds(time);
   //     print("iam");
   //     SceneManager.LoadScene(0);
   // }
        

  
    public void Onclick() {
        SceneManager.LoadScene(1);
    }
   
}
