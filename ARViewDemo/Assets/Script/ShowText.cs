using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowText : MonoBehaviour {
    public GameObject baseObj;
    public Image[] images;
    public Text[] texts;
    // Use this for initialization
    void Start () {
        baseObj.SetActive(false);
        baseObj.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 100, 0);
        foreach (var item in texts)
        {
            Color co = item.color;
            co.a += Time.deltaTime;
            item.color = co;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (startshow)
        {
            baseObj.GetComponent<RectTransform>().anchoredPosition3D = Vector3.Lerp(baseObj.GetComponent<RectTransform>().anchoredPosition3D, Vector3.zero,Time.deltaTime*5);
            foreach (var item in images)
            {
                Color co = item.color;
                co.a += Time.deltaTime;
                item.color = co;
            }
            foreach (var item in texts)
            {
                Color co = item.color;
                co.a += Time.deltaTime;
                item.color = co;
            }
        }
	}

    bool startshow = false;
    public void startShow()
    {
        startshow = true;
        baseObj.SetActive(true);
    }
}
