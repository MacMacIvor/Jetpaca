using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
public class sceneSwitcher : MonoBehaviour
{
    [Range(0, 4)]
    public int typeOfUI = 0;

    GraphicRaycaster rayCaster;
    PointerEventData eventData;
    EventSystem eventSystem;

    // Start is called before the first frame update
    void Start()
    {
        rayCaster = GetComponent<GraphicRaycaster>();
        eventSystem = GetComponent<EventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            eventData = new PointerEventData(eventSystem);
            eventData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();

            rayCaster.Raycast(eventData, results);

            foreach (RaycastResult result in results)
            {
                if (result.gameObject == gameObject)
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

    }
}
