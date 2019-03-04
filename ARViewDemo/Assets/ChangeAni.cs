using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeAni : MonoBehaviour {
    public Animator animator;
    public Button btnMotion;
    public Button btnPose;
    public Button btnMode;
    public GameObject[] modes;
    // Use this for initialization
    int curpose=1;
    int curmotion=1;
    int curmode = 0;
    void Start () {
        btnPose.onClick.AddListener(() => {
            curpose += 1;
            curpose %= 19;
            if (curpose == 0)
                curpose = 1;
            animator.SetInteger("animation", curpose);
        });

        btnMotion.onClick.AddListener(() => {
            curmotion += 1;
            curmotion %= 10;
            if (curmotion == 0)
                curmotion = 1;
            animator.SetTrigger("emo"+ curmotion);
        });

        btnMode.onClick.AddListener(() => {
            curmode += 1;
            curmode %= modes.Length;
            for (int i = 0; i < modes.Length; i++)
            {
                modes[i].SetActive(i == curmode ? true : false);
                if (i == curmode)
                {
                    animator = modes[i].GetComponent<Animator>();
                    curpose = 1;
                    curmotion = 1;
                }
            }
        });
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
