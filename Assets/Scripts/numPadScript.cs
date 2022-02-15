using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class numPadScript : MonoBehaviour
{
    
    private int counter = 0;
    
    Stack textStack = new Stack();
    
    public TextMeshPro textM;
    public TextMeshPro textS;
    
    public GameObject uiButton;
    public GameObject uiButtonS;

    public sentenceScript ss;
    
    public void one_key()
    {
        textStack.Push("1");

        textM.text = textM.text + textStack.Peek();
        textS.text = textS.text + textStack.Peek();
        counter++;
    }
    
    public void two_key()
    {
        textStack.Push("2");

        textM.text = textM.text + textStack.Peek();
        textS.text = textS.text + textStack.Peek();
        counter++;
    }
    
    public void three_key()
    {
        textStack.Push("3");

        textM.text = textM.text + textStack.Peek();
        textS.text = textS.text + textStack.Peek();
        counter++;
    }
    
    public void four_key()
    {
        textStack.Push("4");
 
        textM.text = textM.text + textStack.Peek();
        textS.text = textS.text + textStack.Peek();
        counter++;
    }
    
    public void five_key()
    {
        textStack.Push("5");
 
        textM.text = textM.text + textStack.Peek();
        textS.text = textS.text + textStack.Peek();
        counter++;
    }
    
    public void six_key()
    {
        textStack.Push("6");
 
        textM.text = textM.text + textStack.Peek();
        textS.text = textS.text + textStack.Peek();
        counter++;
    }
    
    public void seven_key()
    {
        textStack.Push("7");
 
        textM.text = textM.text + textStack.Peek();
        textS.text = textS.text + textStack.Peek();
        counter++;
    }
    
    public void eight_key()
    {
        textStack.Push("8");
 
        textM.text = textM.text + textStack.Peek();
        textS.text = textS.text + textStack.Peek();
        counter++;
    }
    
    public void nine_key()
    {
        textStack.Push("9");
 
        textM.text = textM.text + textStack.Peek();
        textS.text = textS.text + textStack.Peek();
        counter++;
    }
    
    public void zero_key()
    {
        textStack.Push("0");
 
        textM.text = textM.text + textStack.Peek();
        textS.text = textS.text + textStack.Peek();
        counter++;
    }
    
    public void cancel_key()
    {
        while (counter != 0)
        {
            textStack.Pop();
            counter--;
        }

        textM.text = "";
        textS.text = "";
        
        textM.color = Color.white;
        textS.color = Color.white;
        
        var checkRender = uiButton.GetComponent<Renderer>();
        checkRender.material.SetColor("_Color", Color.white);
        
        var checkRenderS = uiButtonS.GetComponent<Renderer>();
        checkRenderS.material.SetColor("_Color", Color.white);
    }
    
    public void check_key()
    {
        var checkRender = uiButton.GetComponent<Renderer>();
        
        if (textM.text == "")
        {
            checkRender.material.SetColor("_Color", Color.red);
        }
        else
        {
            checkRender.material.SetColor("_Color", Color.green);
            textM.color = Color.green;

            ss.odd_even_num = int.Parse(textM.text);
        }
        
        var checkRenderS = uiButtonS.GetComponent<Renderer>();
        
        if (textS.text == "")
        {
            checkRenderS.material.SetColor("_Color", Color.red);
        }
        else
        {
            checkRenderS.material.SetColor("_Color", Color.green);
            textS.color = Color.green;

            ss.odd_even_num_S = int.Parse(textS.text);
        }
    }
}
