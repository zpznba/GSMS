using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showLable : MonoBehaviour {
    public Image[] imgs;
    public Text[] texts;

    // Use this for initialization
    void Start () {
        sho = true;
    }
    public bool sho = true;
    // Update is called once per frame
    void Update () {
        if (!sho)
        {
            foreach (var item in imgs)
            {
                Color co = item.color;
                co.a -= Time.deltaTime;
                co.a = Mathf.Clamp(co.a, 0, 1);
                item.color = co;
            }
            foreach (var item in texts)
            {
                Color co = item.color;
                co.a -= Time.deltaTime;
                co.a = Mathf.Clamp(co.a, 0, 1);
                item.color = co;
            }
        }
	}

    public void dis()
    {
        //sho = false;
    }
}
