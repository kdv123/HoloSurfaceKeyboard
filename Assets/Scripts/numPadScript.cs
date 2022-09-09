using System.Collections;
using TMPro;
using UnityEngine;


/**
 * Author      : Joshua Reynolds
 * Email       : joshuare@mtu.edu
 * Description : This class houses the function for the number pad when selecting the participant number.
 */
public class numPadScript : MonoBehaviour
{
    // Initialize variables
    private int counter = 0;
    
    Stack textStack = new Stack();
    
    public TextMeshPro textM;
    public TextMeshPro textS;
    
    public GameObject uiButton;
    public GameObject uiButtonS;

    public sentenceScript ss;
    
    /**
     * Description : Handles the one key
     */
    public void one_key()
    {
        textStack.Push("1");

        textM.text = textM.text + textStack.Peek();
        textS.text = textS.text + textStack.Peek();
        counter++;
    }
    
    /**
     * Description : Handles the two key
     */
    public void two_key()
    {
        textStack.Push("2");

        textM.text = textM.text + textStack.Peek();
        textS.text = textS.text + textStack.Peek();
        counter++;
    }
    
    /**
     * Description : Handles the three key
     */
    public void three_key()
    {
        textStack.Push("3");

        textM.text = textM.text + textStack.Peek();
        textS.text = textS.text + textStack.Peek();
        counter++;
    }
    
    /**
     * Description : Handles the four key
     */
    public void four_key()
    {
        textStack.Push("4");
 
        textM.text = textM.text + textStack.Peek();
        textS.text = textS.text + textStack.Peek();
        counter++;
    }
    
    /**
     * Description : Handles the five key
     */
    public void five_key()
    {
        textStack.Push("5");
 
        textM.text = textM.text + textStack.Peek();
        textS.text = textS.text + textStack.Peek();
        counter++;
    }
    
    /**
     * Description : Handles the six key
     */
    public void six_key()
    {
        textStack.Push("6");
 
        textM.text = textM.text + textStack.Peek();
        textS.text = textS.text + textStack.Peek();
        counter++;
    }
    
    /**
     * Description : Handles the seven key
     */
    public void seven_key()
    {
        textStack.Push("7");
 
        textM.text = textM.text + textStack.Peek();
        textS.text = textS.text + textStack.Peek();
        counter++;
    }
    
    /**
     * Description : Handles the eight key
     */
    public void eight_key()
    {
        textStack.Push("8");
 
        textM.text = textM.text + textStack.Peek();
        textS.text = textS.text + textStack.Peek();
        counter++;
    }
    
    /**
     * Description : Handles the nine key
     */
    public void nine_key()
    {
        textStack.Push("9");
 
        textM.text = textM.text + textStack.Peek();
        textS.text = textS.text + textStack.Peek();
        counter++;
    }
    
    /**
     * Description : Handles the zero key
     */
    public void zero_key()
    {
        textStack.Push("0");
 
        textM.text = textM.text + textStack.Peek();
        textS.text = textS.text + textStack.Peek();
        counter++;
    }
    
    /**
     * Description : Handles the cancel key
     */
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
    
    
    /**
     * Description : Handles the check key
     */
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
