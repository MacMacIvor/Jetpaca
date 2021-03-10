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

public class tryAgain : MonoBehaviour
{
    public TMP_Text message1;
    public GameObject image;
    public GameObject image2;
    public Canvas canvas;

    public static tryAgain singleton;

    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
            return;
        }
        Destroy(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void bringUIDown()
    {
        message1.gameObject.transform.position = new Vector3(message1.gameObject.transform.position.x, (canvas.GetComponent<RectTransform>().rect.height * canvas.GetComponent<RectTransform>().localScale.y) / 2 + 3, 0);
        message1.text = "Your score is " + points.singleton.getPoints().ToString() + "\nTry again?";
        image.gameObject.transform.position = new Vector3( image.gameObject.transform.position.x, (canvas.GetComponent<RectTransform>().rect.height * canvas.GetComponent<RectTransform>().localScale.y) / 4, 0);
        image2.gameObject.transform.position = new Vector3(image2.gameObject.transform.position.x, (canvas.GetComponent<RectTransform>().rect.height * canvas.GetComponent<RectTransform>().localScale.y) / 6, 0);
    }
}
