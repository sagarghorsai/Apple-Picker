using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{

    [Header("Inscribed")]
    public GameObject applePrefab;

    public GameObject goldenApplePrefab;

    public float speed = 1f;
    public float leftAndrightEdge = 10f;
    public float changeDirchance = 0.1f;
    public float appleDropDelay = 1f;


    [Header("Difficulty")]
    public List<float> speedLevels=new List<float>();
    public List<float> changeDirChanceLevels = new List<float>();
    public List<float> appleDropDelayLevels = new List<float>();

    [Header("Level")]
    public int startingDifficultyLevel;
    private int difficultyLevel;



    void Start()
    {
        difficultyLevel = startingDifficultyLevel;

        UpdatDifficulty();
        //Start dropping apples

        Invoke("DropApple", 2f);

    }

    void UpdatDifficulty()
    {
        speed = speedLevels[difficultyLevel];
        changeDirchance = changeDirChanceLevels[difficultyLevel];
        appleDropDelay = appleDropDelayLevels[difficultyLevel];
    }

    void DropApple()
    {
        if (Random.value < 0.05f)
        { // 5% chance
            GameObject Goldenapple = Instantiate<GameObject>(
                 goldenApplePrefab);
            Goldenapple.transform.position = transform.position;
        }
        else
        {
            GameObject apple = Instantiate<GameObject>(
                   applePrefab);
            apple.transform.position = transform.position;

        }




        Invoke("DropApple", appleDropDelay);
    }


    // Update is called once per frame
    void Update()
    {
        //Basic Movement

        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //Changing Direction

        if (pos.x < -leftAndrightEdge)
        {
            speed = Mathf.Abs(speed); // Move right
        }
        else if (pos.x > leftAndrightEdge)
        {
            speed = -Mathf.Abs(speed); // Move left
        }

    }

    void FixedUpdate()
    {
        if (Random.value < changeDirchance)
        {
            speed *= -1;
        }
    }

}

