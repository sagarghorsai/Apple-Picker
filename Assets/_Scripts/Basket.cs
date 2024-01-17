using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGo = GameObject.Find("ScoreCounter");
        
        scoreCounter = scoreGo.GetComponent<ScoreCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(
mousePos2D);

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collideWith = collision.gameObject;

        if (collideWith.CompareTag("Apple"))
        {
            Destroy(collideWith);
            scoreCounter.score +=100;
            HighScore.TRY_SET_SCORE(scoreCounter.score);
        }
        if (collideWith.CompareTag("GoldenApple"))
        {
            Destroy(collideWith);
            scoreCounter.score += 500;
            HighScore.TRY_SET_SCORE(scoreCounter.score);
        }
    }
}
