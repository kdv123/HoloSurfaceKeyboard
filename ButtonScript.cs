using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using TMPro;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{

    public TextMeshPro textM;
    public TextMeshPro leftShiftText;
    public TextMeshPro rightShiftText;
    public TextMeshPro capsText;
    
    private bool isShiftOn = false;
    private bool isCapsOn = false;
    private int counter = 0;
    Stack textStack = new Stack();

    public void Update()
    {
        if (isShiftOn)
        {
            leftShiftText.color = Color.red;
            rightShiftText.color = Color.red;
        }
        else if (isShiftOn == false)
        {
            leftShiftText.color = Color.white;
            rightShiftText.color = Color.white;
        }

        if (isCapsOn)
        {
            capsText.color = Color.red;
        }
        else if (isCapsOn == false)
        {
            capsText.color = Color.white;
        }
    }

    public void shift_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
        }
        else
        {
            isShiftOn = true;   
        }
    }

    public void caps_key()
    {
        if (isCapsOn)
        {
            isCapsOn = false;
        }
        else
        {
            isCapsOn = true;
        }
    }
    
    public void a_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("A");
        } 
        else if (isCapsOn)
        {
            textStack.Push("A");
        }
        else
        {
            textStack.Push("a");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
        
        // HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out MixedRealityPose pose);
        //
        // Debug.Log("X position: " + pose.Position.x.ToString("F"));
        // Debug.Log("Y position: " + pose.Position.y.ToString("F"));
    }
    
    public void b_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("B");
        } 
        else if (isCapsOn)
        {
            textStack.Push("B");
        }
        else
        {
            textStack.Push("b");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void c_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("C");
        } 
        else if (isCapsOn)
        {
            textStack.Push("C");
        }
        else
        {
            textStack.Push("c");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void d_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("D");
        } 
        else if (isCapsOn)
        {
            textStack.Push("D");
        }
        else
        {
            textStack.Push("d");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void e_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("E");
        } 
        else if (isCapsOn)
        {
            textStack.Push("E");
        }
        else
        {
            textStack.Push("e");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void f_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("F");
        } 
        else if (isCapsOn)
        {
            textStack.Push("F");
        }
        else
        {
            textStack.Push("f");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void g_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("G");
        } 
        else if (isCapsOn)
        {
            textStack.Push("G");
        }
        else
        {
            textStack.Push("g");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void h_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("H");
        } 
        else if (isCapsOn)
        {
            textStack.Push("H");
        }
        else
        {
            textStack.Push("h");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void i_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("I");
        } 
        else if (isCapsOn)
        {
            textStack.Push("I");
        }
        else
        {
            textStack.Push("i");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void j_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("J");
        } 
        else if (isCapsOn)
        {
            textStack.Push("J");
        }
        else
        {
            textStack.Push("j");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void k_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("K");
        } 
        else if (isCapsOn)
        {
            textStack.Push("K");
        }
        else
        {
            textStack.Push("k");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void l_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("L");
        } 
        else if (isCapsOn)
        {
            textStack.Push("L");
        }
        else
        {
            textStack.Push("l");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void m_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("M");
        } 
        else if (isCapsOn)
        {
            textStack.Push("M");
        }
        else
        {
            textStack.Push("m");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void n_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("N");
        } 
        else if (isCapsOn)
        {
            textStack.Push("N");
        }
        else
        {
            textStack.Push("n");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void o_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("O");
        } 
        else if (isCapsOn)
        {
            textStack.Push("O");
        }
        else
        {
            textStack.Push("o");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void p_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("P");
        } 
        else if (isCapsOn)
        {
            textStack.Push("P");
        }
        else
        {
            textStack.Push("p");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void q_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("Q");
        } 
        else if (isCapsOn)
        {
            textStack.Push("Q");
        }
        else
        {
            textStack.Push("q");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void r_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("R");
        } 
        else if (isCapsOn)
        {
            textStack.Push("R");
        }
        else
        {
            textStack.Push("r");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void s_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("S");
        } 
        else if (isCapsOn)
        {
            textStack.Push("S");
        }
        else
        {
            textStack.Push("s");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void t_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("T");
        } 
        else if (isCapsOn)
        {
            textStack.Push("T");
        }
        else
        {
            textStack.Push("t");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void u_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("U");
        } 
        else if (isCapsOn)
        {
            textStack.Push("U");
        }
        else
        {
            textStack.Push("u");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void v_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("V");
        } 
        else if (isCapsOn)
        {
            textStack.Push("V");
        }
        else
        {
            textStack.Push("v");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void w_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("W");
        } 
        else if (isCapsOn)
        {
            textStack.Push("W");
        }
        else
        {
            textStack.Push("w");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void x_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("X");
        } 
        else if (isCapsOn)
        {
            textStack.Push("X");
        }
        else
        {
            textStack.Push("x");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void y_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("Y");
        } 
        else if (isCapsOn)
        {
            textStack.Push("Y");
        }
        else
        {
            textStack.Push("y");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void z_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("Z");
        } 
        else if (isCapsOn)
        {
            textStack.Push("Z");
        }
        else
        {
            textStack.Push("z");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void tilda_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("~");
        }
        else
        {
            textStack.Push("`");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
        
        // HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out MixedRealityPose pose);
        //
        // Debug.Log("X position: " + pose.Position.x.ToString("F"));
        // Debug.Log("Y position: " + pose.Position.y.ToString("F"));
    }
    
    public void one_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("!");
        }
        else
        {
            textStack.Push("1");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
        
        // HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out MixedRealityPose pose);
        //
        // Debug.Log("X position: " + pose.Position.x.ToString("F"));
        // Debug.Log("Y position: " + pose.Position.y.ToString("F"));
    }
    
    public void two_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("@");
        }
        else
        {
            textStack.Push("2");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
        
        // HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out MixedRealityPose pose);
        //
        // Debug.Log("X position: " + pose.Position.x.ToString("F"));
        // Debug.Log("Y position: " + pose.Position.y.ToString("F"));
    }
    
    public void three_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("#");
        }
        else
        {
            textStack.Push("3");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void four_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("$");
        }
        else
        {
            textStack.Push("4");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void five_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("%");
        }
        else
        {
            textStack.Push("5");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void six_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("^");
        }
        else
        {
            textStack.Push("6");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void seven_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("&");
        }
        else
        {
            textStack.Push("7");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void eight_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("*");
        }
        else
        {
            textStack.Push("8");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void nine_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("(");
        }
        else
        {
            textStack.Push("9");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void zero_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push(")");
        }
        else
        {
            textStack.Push("0");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void minus_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("_");
        }
        else
        {
            textStack.Push("-");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void equal_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("+");
        }
        else
        {
            textStack.Push("=");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void sqBracketLeft_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("{");
        }
        else
        {
            textStack.Push("[");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void sqBracketRight_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("}");
        }
        else
        {
            textStack.Push("]");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void backSlash_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("|");
        }
        else
        {
            textStack.Push("\\");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void colon_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push(":");
        }
        else
        {
            textStack.Push(";");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void quote_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("\"");
        }
        else
        {
            textStack.Push("'");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void comma_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("<");
        }
        else
        {
            textStack.Push(",");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void period_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push(">");
        }
        else
        {
            textStack.Push(".");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void slash_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push("?");
        }
        else
        {
            textStack.Push("/");
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void space_key()
    {
        textStack.Push(" ");
        textM.text = textM.text + textStack.Peek();
        counter++;
    }
    
    public void tab_key()
    {
        textStack.Push("\t");
        textM.text = textM.text + textStack.Peek();
        counter++;
    }

    public void enter_key()
    {
        textStack.Push("\n");
        textM.text = textM.text + textStack.Peek();
        counter++;
    }

    public void backspace_key()
    {
        if (counter != 0)
        {

            String tempText = "";

            textStack.Pop();

            Stack tempStack = new Stack();

            while (textStack.Count != 0)
            {
                tempStack.Push(textStack.Pop());
            }

            while (tempStack.Count != 0) 
            {
                tempText = tempText + tempStack.Peek(); 
                textStack.Push(tempStack.Pop());
            }

            textM.text = tempText;

            counter--;
        }
    }
    
}
