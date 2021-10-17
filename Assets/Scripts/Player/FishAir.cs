using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FishAir : MonoBehaviour
{
    
    public float maximumAir;
    public float damageTime;
    public GameMenu manager;
    private Image image;
    private float air;
    private float timer;
    private float airDecrement;
    public float airScaling;
    private bool inWater = true;
    private bool inHazard = false;

    void Start()
    {
        air = maximumAir;
        image = GameObject.FindGameObjectWithTag("AirMeter").GetComponent<Image>();
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!inWater)
        {
            air -= Time.deltaTime * airScaling;
        } else
        {
            if(air < maximumAir)
            {
                air += 0.3f;
            }
        }
        
        if (inHazard)
        {
            timer -= Time.deltaTime;
            if(timer < 0)
            {
                air -= airDecrement;
                timer += damageTime;
            }
        }

        if (air < 0)
        {
            manager.Defeat();
        }
        image.fillAmount = air / 100;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            inWater = true;
        } else if (collision.gameObject.CompareTag("Hazard"))
        {
            airDecrement = collision.gameObject.GetComponent<Hazard>().damage;
            inHazard = true;
            timer = damageTime;
        } else if (collision.gameObject.CompareTag("Machine"))
        {
            //Congratulations
            if (SceneManager.GetActiveScene().buildIndex < 6)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            } 
            //Thank you for playing!
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Water")
        {
            inWater = false;
        }

        if (collision.tag == "Hazard")
        {
            inHazard = false;
        }
    }




}
