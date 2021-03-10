using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class points : MonoBehaviour
{
    public static timer singleton;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (singleton == null)
        {
            singleton = this;
            return;
        }
        Destroy(this);
    }

    private float timePassed = 0;
    public TMP_Text timerString;
    public TMP_Text timerShowString;
    bool stillCredits = false;
    // Start is called before the first frame update
    void Start()
    {

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

                using (var line = new StreamReader(Application.dataPath + "/timeSaved/bestTime.txt"))
                    while ((objectsData = line.ReadLine()) != null) //Set up this way in case in the future we want to add times for each individual level
                    {

                        timerShowString.text = line.ReadLine();

                    }
            }
        }
        else
        {
            timePassed += Time.deltaTime;
            timerString.text = "Time: " + timePassed.ToString();
        }
    }
    public void saveTime()
    {
        string objectsData;
        float savedTime = 9999999999999999999;

        using (var line = new StreamReader(Application.dataPath + "/timeSaved/bestTime.txt"))
            while ((objectsData = line.ReadLine()) != null) //Set up this way in case in the future we want to add times for each individual level
            {
                savedTime = float.Parse(objectsData);

            }
        if (savedTime > timePassed)
        {
            using (StreamWriter outputFile = new StreamWriter(Application.dataPath + "/timeSaved/bestTime.txt"))
            {
                outputFile.Write(timePassed);
            }
        }
    }
    public void resetTime()
    {
        timePassed = 0;
    }
}
