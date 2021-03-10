using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class points : MonoBehaviour
{
    public static points singleton;
    int lastInterval = 0;
    private void Awake()
    {
        
        if (singleton == null)
        {
            singleton = this;
            return;
        }
        Destroy(this);
    }
    public Canvas canvas;
    private float timePassed = 0;
    public TMP_Text timerString;
    public TMP_Text timerShowString;
    bool stillCredits = false;
    private float timeMod = 1;
    // Start is called before the first frame update
    void Start()
    {
        timerString.transform.localPosition = new Vector3(-canvas.GetComponent<RectTransform>().rect.width / 2 + timerString.transform.localScale.x * 7, -canvas.GetComponent<RectTransform>().rect.height / 2 + timerString.transform.localScale.y / 2, 0);

    }

    // Update is called once per frame
    void Update()
    {

        if (SceneManager.GetActiveScene().name == "Credits")
        {
            if (stillCredits == false)
            {
                stillCredits = true;
                string objectsData;

                using (var line = new StreamReader(Application.dataPath + "/scoreSaved/bestScore.txt"))
                    while ((objectsData = line.ReadLine()) != null) //Set up this way in case in the future we want to add times for each individual level
                    {

                        timerShowString.text = line.ReadLine();

                    }
            }
        }
        else
        {
            timePassed += Time.deltaTime * timeMod;
            timerString.text = "Score: " + timePassed.ToString();
            float interval = Mathf.Floor(timePassed / 15);
            
            if (interval > lastInterval)
            {
                lastInterval = (int)(interval);
                wallManager.singleton.increaseSpeed(1.1f);
            }
        }
    }
    public void saveTime()
    {
        string objectsData;
        float savedTime = 0;

        using (var line = new StreamReader(Application.dataPath + "/scoreSaved/bestScore.txt"))
            while ((objectsData = line.ReadLine()) != null) //Set up this way in case in the future we want to add times for each individual level
            {
                savedTime = float.Parse(objectsData);

            }
        if (savedTime < timePassed)
        {
            using (StreamWriter outputFile = new StreamWriter(Application.dataPath + "/scoreSaved/bestScore.txt"))
            {
                outputFile.Write(timePassed);
            }
        }
    }
    public void resetTime()
    {
        timePassed = 0;
    }
    public void stopTime()
    {
        timeMod = 0;
    }
    public float getPoints()
    {
        return timePassed;
    }
}
