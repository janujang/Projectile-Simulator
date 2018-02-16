using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumPadController : MonoBehaviour {

    public static Text txt;
    public static Button btn;
    public GameObject menuUI;

	// Use this for initialization

    public static void UseNumPad(Text current, Button button)
    {
        txt = current;
        txt.text = "";
        btn = button;
        btn.image.color = Color.cyan;
    }

    public void add0()
    {
        if(txt)
            txt.text += "0";
    }
    public void add1()
    {
        if (txt)
            txt.text += "1";
    }
    public void add2()
    {
        if (txt)
            txt.text += "2";
    }
    public void add3()
    {
        if (txt)
            txt.text += "3";
    }
    public void add4()
    {
        if (txt)
            txt.text += "4";
    }
    public void add5()
    {
        if (txt)
            txt.text += "5";
    }
    public void add6()
    {
        if (txt)
            txt.text += "6";
    }
    public void add7()
    {
        if (txt)
            txt.text += "7";
    }
    public void add8()
    {
        if (txt)
            txt.text += "8";
    }
    public void add9()
    {
        if (txt)
            txt.text += "9";
    }
    public void addDot()
    {
        if (txt)
            txt.text += ".";
    }
    public void done()
    {
        if (txt)
        {
            btn.image.color = Color.white;
            txt = null;
            btn = null;
        }
    }
}
