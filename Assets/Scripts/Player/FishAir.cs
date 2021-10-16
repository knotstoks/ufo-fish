using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FishAir : MonoBehaviour
{
    
    public float maximumAir;
    public float damageTime;
    public Text airText;
    public Image image;
    private float air;
    private float timer;
    private float airDecrement;
    private bool inWater = true;
    private bool inHazard = false;

    void Start()
    {
        air = maximumAir;

    }

    // Update is called once per frame
    void Update()
    {
        if (!inWater)
        {
            air -= Time.deltaTime;
        } else
        {
            if(air < maximumAir)
            {
                air += 0.1f;
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
            SceneManager.LoadScene(1);
        }

        airText.text = "Air Left: " + (int) air;
        image.fillAmount = air / 100;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Water")
        {
            inWater = true;
        }

        if (collision.tag == "Hazard")
        {
            airDecrement = collision.gameObject.GetComponent<Hazard>().damage;
            inHazard = true;
            timer = damageTime;
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
