using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadProcess : MonoBehaviour {
    public Text message;
    public Image mainImage;
    public Image secImage;
    public Image thirdImage;
    public Image helpImage;
    bool hasLoaded=false;

    public Color startcolor;
    public Color midcolor;
    public Color endcolor;

    public ShowText showText;
    public LoadMini mini;

    // Use this for initialization
    void Start () {
		
	}

    public void initLoadProcess()
    {
        hasLoaded = false;
        beginLoaded = false;
        process = 0;
    }

    // Update is called once per frame
    float process;
	void Update () {
        if (beginLoaded)
        {
            process += Time.deltaTime*30;
            if (process >= 100)
            {
                process = 100;
                LoadSuccess();
            }
            else
            {
                mainImage.fillAmount = process*0.01f;
                secImage.fillAmount = process * 0.01f;
                thirdImage.fillAmount = (process % 20f) * 0.05f;
                helpImage.fillAmount = (process % 33.3f)*0.03f;
                if (process < 15)
                {
                    setColor(startcolor);
                    message.text = "连线中    " + process + "%";
                }
                else if (process < 25)
                {
                    message.text = "开始同步    "+process+"%";
                }
                else if (process < 55)
                {
                    setColor(midcolor);
                    message.text = "同步完成    " + process + "%";
                }
                else if (process < 60)
                {
                    message.text = "分析资料中    " + process + "%";
                }
                else if (process < 65)
                {
                    setColor(endcolor);
                }
                else if (process < 90)
                {
                    message.text = "资料分析完成    " + process + "%";
                }
                else if (process < 100)
                {
                    message.text = "资料分析完成    " + process + "%";
                }
            }
        }
	}

    bool beginLoaded=false;
    public showLable la;
   public  void beginLoad()
    {
        beginLoaded = true;
        mini.beginSync();
    }

    public void LoadSuccess()
    {
        beginLoaded = false;
        hasLoaded = true;
        la.dis();
        mainImage.fillAmount = 1;
        secImage.fillAmount = 1;
        helpImage.fillAmount = 1;
        thirdImage.fillAmount = 1;
        showText.startShow();
        message.text = "";
        mini.endSync();
    }

    public void loadFault()
    {
        if (!hasLoaded)
        {
            initLoadProcess();
            mainImage.fillAmount = 0;
            secImage.fillAmount = 0;
            helpImage.fillAmount = 0;
            thirdImage.fillAmount = 0;
            message.text = "";
            mini.desSync();
        }
    }

    void setColor(Color color)
    {
        message.color = color;
        Color co1 = color;
        co1.a = 0.8f;
        thirdImage.color = co1;
        Color co2 = color;
        co2.a = 0.7f;
        helpImage.color = co2;
        mainImage.color = color;
    }
}
