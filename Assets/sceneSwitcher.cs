using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class sceneSwitcher : MonoBehaviour
{
    [Range(0, 4)]
    public int typeOfUI = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if ((Input.GetMouseButtonDown(0)) && Input.mousePosition.x > transform.position.x - GetComponent<RectTransform>().rect.width && Input.mousePosition.x < transform.position.x + GetComponent<RectTransform>().rect.width && Input.mousePosition.y < transform.position.y + GetComponent<RectTransform>().rect.height && Input.mousePosition.y > transform.position.y - GetComponent<RectTransform>().rect.height)
        {

            switch (typeOfUI)
            {
                case 0:
                    SceneManager.LoadScene("SampleScene");
                    break;
                case 1:
                    SceneManager.LoadScene("Controls");
                    break;
                case 2:
                    SceneManager.LoadScene("Credits");
                    break;
                case 3:
                    Application.Quit();
                    break;
                case 4:
                    SceneManager.LoadScene("TitleScreen");
                    break;
            }

        }
    }
}
