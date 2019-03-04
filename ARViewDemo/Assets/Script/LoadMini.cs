using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoadMini : MonoBehaviour {
    public Image topTrigine;
    public Image sideImg;
    public Image centerTrigine;
    public Image slider;

    public Color startBlue;

    // Use this for initialization
    void Start () {
        

    }
    Vector3 pos;
    public Vector3 TopPos;
    public Vector3 DownPos;
    public Vector3 LoadPos;
    bool down;
    // Update is called once per frame

    float num = 0.01f;
    bool flag = false;
    float timer = 1;
    void Update () {
        if (end)
        {
            Color c1 = topTrigine.color;
            c1.a -= Time.deltaTime*3;
            topTrigine.color = c1;
            Color c2 = sideImg.color;
            c2.a -= Time.deltaTime * 3;
            sideImg.color = c2;
            Color c3 = centerTrigine.color;
            c3.a -= Time.deltaTime * 3;
            centerTrigine.color = c3;
            Color c4 = slider.color;
            c4.a -= Time.deltaTime * 3;
            slider.color = c4;
        }

        if (begin&!beginSyn)
        {
            if (flag)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    flag = false;
                }
            }
            else
            {
                timer += Time.deltaTime;
                if (timer >= 1)
                {
                    flag = true;
                }
            }
            topTrigine.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0,45 + timer*5, -6.6f);
        }

        if (beginSyn)
        {
            topTrigine.GetComponent<RectTransform>().anchoredPosition3D = Vector3.Lerp(topTrigine.GetComponent<RectTransform>().anchoredPosition3D, LoadPos, Time.deltaTime);
        }

	}
    bool begin;
    public void showMini()
    {
        topTrigine.enabled = true;
        sideImg.enabled = true;
        centerTrigine.enabled = true;
        slider.enabled = true;
        begin = true;
    }

    public void disShowMini()
    {
        topTrigine.enabled = false;
        sideImg.enabled = false;
        centerTrigine.enabled = false;
        slider.enabled = false;
    }
    bool beginSyn;
    public void beginSync()
    {
        sideImg.color = startBlue;
        beginSyn = true;
    }

    public void desSync()
    {
        sideImg.color = Color.white;
        beginSyn = false;
    }

    bool end = false;
    public void endSync()
    {
        end = true;
    }
}
