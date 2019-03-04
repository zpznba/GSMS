using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTarget : MonoBehaviour {
    public GameObject normalParent;
    public GameObject AimParent;

    Vector3 normalPos;
    Vector3 aimPos;
    // Use this for initialization
    void Start () {
        normalPos = new Vector3(-81,77, 3601);
        aimPos = new Vector3(-94.4f, 115.6f, -32);
        this.gameObject.transform.SetParent(normalParent.transform);
        this.gameObject.transform.GetComponent<RectTransform>().anchoredPosition3D = normalPos;
        this.gameObject.transform.GetComponent<RectTransform>().localEulerAngles = Vector3.zero;
    }
	
	// Update is called once per frame
	void Update () {

        if (changed)
        {
            this.gameObject.transform.SetParent(AimParent.transform);
            this.gameObject.transform.GetComponent<RectTransform>().anchoredPosition3D = Vector3.Lerp(this.gameObject.transform.GetComponent<RectTransform>().anchoredPosition3D, aimPos, Time.deltaTime*3);
            //this.gameObject.transform.GetComponent<RectTransform>().localEulerAngles = Vector3.Lerp(this.gameObject.transform.GetComponent<RectTransform>().localEulerAngles, Vector3.zero, Time.deltaTime * 5);
        }
    }
    bool changed;
    public void beginChange()
    {
        changed = true;
    }
}
