using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class geceGunduz : MonoBehaviour
{
    // 19.00-06.00'da Gece

    public float hiz;
    public float hiz2 = 50f;
    public float saat;
    public float dakika;
    public float zaman;
    public float zaman2;
    public static bool isNight;
    public Text saatTxt;
    public GameObject dayPanel;
    public GameObject nightPanel;
    public GameObject enemySpawner;

    // Skybox
    public Material day;
    public Material night;
    

    // Start is called before the first frame update
    void Start()
    {
        zaman = (saat * 15f) + (dakika * 0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        zaman += hiz * Time.deltaTime;
        zaman2 = zaman / 0.25f;
        dakika = zaman2 % 60;
        saat = (zaman2 - dakika) / 60;
        if(zaman > 360)
        {
            zaman = 0;
        }
        transform.eulerAngles = new Vector3(zaman - 90, 0, 0);
        saatTxt.text = "" + saat.ToString("00") + ":" + dakika.ToString("00");
        if(saat <= 18 && saat >= 6)
        {
            Day();
        }
        else
        {
            Night();
        }
    }


    void Day()
    {
        isNight = false;
        RenderSettings.skybox = day;
        dayPanel.SetActive(true);
        nightPanel.SetActive(false);
        enemySpawner.SetActive(false);
        if(Input.GetKey(KeyCode.T))
        {
            if(!isNight)
            {
                hiz = hiz2;
            }
        }
        else
        {
            hiz = hiz2 / 5;
        }
    }

    void Night()
    {
        isNight = true;
        RenderSettings.skybox = night;
        dayPanel.SetActive(false);
        nightPanel.SetActive(true);
        enemySpawner.SetActive(true);
        hiz = hiz2 / 5;
    }
}
