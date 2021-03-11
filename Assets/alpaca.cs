using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alpaca : MonoBehaviour
{
    float speed = 10;

    public GameObject particles;
    
    public GameObject Alpaca;
    bool gotHit = false;

    // Start is called before the first frame update
    void Start()
    {
        soundManager.soundsSingleton.startBackgroundSong("Blazer Rail");
    }

    // Update is called once per frame
    void Update()
    {
        switch (gotHit)
        {
            case false:
                if (Input.GetKey(KeyCode.W))
                {
                    Alpaca.transform.position += Vector3.up * speed * Time.deltaTime;
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    Alpaca.transform.position += Vector3.down * speed * Time.deltaTime;
                }

                //Don't let the alpaca go off the screen
                Vector3 pos = Camera.main.WorldToViewportPoint(Alpaca.gameObject.transform.position);
                pos.y = Mathf.Clamp(pos.y, 0.05f, 0.95f);
                Alpaca.gameObject.transform.position = Camera.main.ViewportToWorldPoint(pos);
                break;
        }
       
    }
    public void playerDies()
    {
        if (gotHit != true)
        {
            //Play animation
            particles.GetComponent<ParticleSystem>().Play();
            //Now block the thing
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = false;
            points.singleton.stopTime();
            tryAgain.singleton.bringUIDown();
        }
        gotHit = true;
    }
}
