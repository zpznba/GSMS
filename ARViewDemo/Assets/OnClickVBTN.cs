using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class OnClickVBTN : MonoBehaviour, IVirtualButtonEventHandler
{
    VirtualButtonBehaviour bh;
    public Text show;
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        show.enabled = !show.enabled;
    }



    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        
    }

    // Use this for initialization
    void Start () {
        bh.GetComponent<VirtualButtonBehaviour>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
