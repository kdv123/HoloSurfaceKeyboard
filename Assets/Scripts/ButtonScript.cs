using System;
using System.Collections;
using TMPro;
using UnityEngine;


/**
 * Author : Joshua Reynolds
 * Description : Calls each key on keyboard
 */
public class ButtonScript : MonoBehaviour
{

    public TextMeshPro textM;
    public TextMeshPro leftShiftText;
    public TextMeshPro rightShiftText;
    public TextMeshPro capsText;
    
    public bool isShiftOn = false;
    public bool isCapsOn = false;
    
    private int counter = 0;
    public int backspaceCounter = 0;
    
    Stack textStack = new Stack();

    public handTracker ht;
    public string key = "";

    public sentenceScript ss;
    public GameObject keyboard;
    
    public TextMeshPro A_Text;
    public TextMeshPro B_Text;
    public TextMeshPro C_Text;
    public TextMeshPro D_Text;
    public TextMeshPro E_Text;
    public TextMeshPro F_Text;
    public TextMeshPro G_Text;
    public TextMeshPro H_Text;
    public TextMeshPro I_Text;
    public TextMeshPro J_Text;
    public TextMeshPro K_Text;
    public TextMeshPro L_Text;
    public TextMeshPro M_Text;
    public TextMeshPro N_Text;
    public TextMeshPro O_Text;
    public TextMeshPro P_Text;
    public TextMeshPro Q_Text;
    public TextMeshPro R_Text;
    public TextMeshPro S_Text;
    public TextMeshPro T_Text;
    public TextMeshPro U_Text;
    public TextMeshPro V_Text;
    public TextMeshPro W_Text;
    public TextMeshPro X_Text;
    public TextMeshPro Y_Text;
    public TextMeshPro Z_Text;
    

    public void Start()
    {
        if (keyboard.activeSelf == true)
        {
            InvokeRepeating("CursorBlinkOn", 0f, 1.0f);
            InvokeRepeating("CursorBlinkOff", 0.5f, 1.0f);
        }
    }

    public void Update()
    {
        if (keyboard.activeSelf == true)
        {
            if (ss.errorRateMenuF.activeSelf == false || ss.errorRateMenuQ.activeSelf == false)
            {
                if (isShiftOn && !isCapsOn)
                {
                    leftShiftText.color = Color.red;
                    rightShiftText.color = Color.red;

                    capsText.color = Color.white;
                    
                    KeysOnUppercase();
                }
                else if (isShiftOn && isCapsOn)
                {
                    leftShiftText.color = Color.red;
                    rightShiftText.color = Color.red;

                    capsText.color = Color.red;
                    
                    KeysOnUppercase();
                }
                else if (!isShiftOn && !isCapsOn)
                {
                    leftShiftText.color = Color.white;
                    rightShiftText.color = Color.white;

                    capsText.color = Color.white;
                    
                    KeysOnLowercase();
                }
                else if (!isShiftOn && isCapsOn)
                {
                    leftShiftText.color = Color.white;
                    rightShiftText.color = Color.white;

                    capsText.color = Color.red;
                    
                    KeysOnUppercase();
                }
            }
        }
    }

    private void KeyPressMainDriver(string upperKey, string lowerKey, object upperChar, object lowerChar, bool special)
    {
        if (textM.text[textM.text.Length - 1] == '_')
            textM.text = textM.text.Remove(textM.text.Length - 1);

        if (isShiftOn)
        {
            isShiftOn = false;
            textStack.Push(upperChar);
            
            key = upperKey;
            ht.writeKey(key);
        } 
        else if (isCapsOn && special)
        {
            textStack.Push(upperChar);
            
            key = upperKey;
            ht.writeKey(key);
        }
        else
        {
            textStack.Push(lowerChar);
            
            key = lowerKey;
            ht.writeKey(key);
        }
        
        textM.text = textM.text + textStack.Peek();
        counter++;
        
        textM.text = textM.text + '_';
    }
    
    private void KeysOnUppercase()
    {
        A_Text.text = "A";
        B_Text.text = "B";
        C_Text.text = "C";
        D_Text.text = "D";
        E_Text.text = "E";
        F_Text.text = "F";
        G_Text.text = "G";
        H_Text.text = "H";
        I_Text.text = "I";
        J_Text.text = "J";
        K_Text.text = "K";
        L_Text.text = "L";
        M_Text.text = "M";
        N_Text.text = "N";
        O_Text.text = "O";
        P_Text.text = "P";
        Q_Text.text = "Q";
        R_Text.text = "R";
        S_Text.text = "S";
        T_Text.text = "T";
        U_Text.text = "U";
        V_Text.text = "V";
        W_Text.text = "W";
        X_Text.text = "X";
        Y_Text.text = "Y";
        Z_Text.text = "Z";
    }

    private void KeysOnLowercase()
    {
        A_Text.text = "a";
        B_Text.text = "b";
        C_Text.text = "c";
        D_Text.text = "d";
        E_Text.text = "e";
        F_Text.text = "f";
        G_Text.text = "g";
        H_Text.text = "h";
        I_Text.text = "i";
        J_Text.text = "j";
        K_Text.text = "k";
        L_Text.text = "l";
        M_Text.text = "m";
        N_Text.text = "n";
        O_Text.text = "o";
        P_Text.text = "p";
        Q_Text.text = "q";
        R_Text.text = "r";
        S_Text.text = "s";
        T_Text.text = "t";
        U_Text.text = "u";
        V_Text.text = "v";
        W_Text.text = "w";
        X_Text.text = "x";
        Y_Text.text = "y";
        Z_Text.text = "z";
    }
    
    public void left_shift_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
        }
        else
        {
            isShiftOn = true;
        }
        
        key = "LSHIFT   ";
        ht.writeKey(key);
    }
    
    public void right_shift_key()
    {
        if (isShiftOn)
        {
            isShiftOn = false;
        }
        else
        {
            isShiftOn = true;
        }
        
        key = "RSHIFT   ";
        ht.writeKey(key);
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
        
        key = "CAPS     ";
        ht.writeKey(key);
    }
    
    public void a_key()
    {
        KeyPressMainDriver("A        ", "a        ", "A", "a", true);
    }
    
    public void b_key()
    {
        KeyPressMainDriver("B        ", "b        ", "B", "b", true);
    }
    
    public void c_key()
    {
        KeyPressMainDriver("C        ", "c        ", "C", "c", true);
    }
    
    public void d_key()
    {
        KeyPressMainDriver("D        ", "d        ", "D", "d", true);
    }
    
    public void e_key()
    {
        KeyPressMainDriver("E        ", "e        ", "E", "e", true);
    }
    
    public void f_key()
    {
        KeyPressMainDriver("F        ", "f        ", "F", "f", true);
    }
    
    public void g_key()
    {
        KeyPressMainDriver("G        ", "g        ", "G", "g", true);
    }
    
    public void h_key()
    {
        KeyPressMainDriver("H        ", "h        ", "H", "h", true);
    }
    
    public void i_key()
    {
        KeyPressMainDriver("I        ", "i        ", "I", "i", true);
    }
    
    public void j_key()
    {
        KeyPressMainDriver("J        ", "j        ", "J", "j", true);
    }
    
    public void k_key()
    {
        KeyPressMainDriver("K        ", "k        ", "K", "k", true);
    }
    
    public void l_key()
    {
        KeyPressMainDriver("L        ", "l        ", "L", "l", true);
    }
    
    public void m_key()
    {
        KeyPressMainDriver("M        ", "m        ", "M", "m", true);
    }
    
    public void n_key()
    {
        KeyPressMainDriver("N        ", "n        ", "N", "n", true);
    }
    
    public void o_key()
    {
        KeyPressMainDriver("O        ", "o        ", "O", "o", true);
    }
    
    public void p_key()
    {
        KeyPressMainDriver("P        ", "p        ", "P", "p", true);
    }
    
    public void q_key()
    {
        KeyPressMainDriver("Q        ", "q        ", "Q", "q", true);
    }
    
    public void r_key()
    {
        KeyPressMainDriver("R        ", "r        ", "R", "r", true);
    }
    
    public void s_key()
    {
        KeyPressMainDriver("S        ", "s        ", "S", "s", true);
    }
    
    public void t_key()
    {
        KeyPressMainDriver("T        ", "t        ", "T", "t", true);
    }
    
    public void u_key()
    {
        KeyPressMainDriver("U        ", "u        ", "U", "u", true);
    }
    
    public void v_key()
    {
        KeyPressMainDriver("V        ", "v        ", "V", "v", true);
    }
    
    public void w_key()
    {
        KeyPressMainDriver("W        ", "w        ", "W", "w", true);
    }
    
    public void x_key()
    {
        KeyPressMainDriver("X        ", "x        ", "X", "x", true);
    }
    
    public void y_key()
    {
        KeyPressMainDriver("Y        ", "y        ", "Y", "y", true);
    }
    
    public void z_key()
    {
        KeyPressMainDriver("Z        ", "z        ", "Z", "z", true);
    }
    
    public void tilda_key()
    {
        KeyPressMainDriver("~        ", "`        ", "~", "`", false);
    }
    
    public void one_key()
    {
        KeyPressMainDriver("!        ", "1        ", "!", "1", false);
    }
    
    public void two_key()
    {
        KeyPressMainDriver("@        ", "2        ", "@", "2", false);
    }
    
    public void three_key()
    {
        KeyPressMainDriver("#        ", "3        ", "#", "3", false);
    }
    
    public void four_key()
    {
        KeyPressMainDriver("$        ", "4        ", "$", "4", false);
    }
    
    public void five_key()
    {
        KeyPressMainDriver("%        ", "5        ", "%", "5", false);
    }
    
    public void six_key()
    {
        KeyPressMainDriver("^        ", "6        ", "^", "6", false);
    }
    
    public void seven_key()
    {
        KeyPressMainDriver("&        ", "7        ", "&", "7", false);
    }
    
    public void eight_key()
    {
        KeyPressMainDriver("*        ", "8        ", "*", "8", false);
    }
    
    public void nine_key()
    {
        KeyPressMainDriver("(        ", "9        ", "(", "9", false);
    }
    
    public void zero_key()
    {
        KeyPressMainDriver(")        ", "0        ", ")", "0", false);
    }
    
    public void minus_key()
    {
        KeyPressMainDriver("_        ", "-        ", "_", "-", false);
    }
    
    public void equal_key()
    {
        KeyPressMainDriver("+        ", "=        ", "+", "=", false);
    }
    
    public void sqBracketLeft_key()
    {
        KeyPressMainDriver("{        ", "[        ", "{", "[", false);
    }
    
    public void sqBracketRight_key()
    {
        KeyPressMainDriver("}        ", "]        ", "}", "]", false);
    }
    
    public void backSlash_key()
    {
        KeyPressMainDriver("|        ", "\\        ", "|", "\\", false);
    }
    
    public void colon_key()
    {
        KeyPressMainDriver(":        ", ";        ", ":", ";", false);
    }
    
    public void quote_key()
    {
        KeyPressMainDriver("\"        ", "'        ", "\"", "'", false);
    }
    
    public void comma_key()
    {
        KeyPressMainDriver("<        ", ",        ", "<", ",", false);
    }
    
    public void period_key()
    {
        KeyPressMainDriver(">        ", ".        ", ">", ".", false);
    }
    
    public void slash_key()
    {
        KeyPressMainDriver("?        ", "/        ", "?", "/", false);
    }
    
    public void space_key()
    {
        isShiftOn = false;
        if (textM.text[textM.text.Length - 1] == '_')
            textM.text = textM.text.Remove(textM.text.Length - 1);
        
        textStack.Push(" ");
        textM.text = textM.text + textStack.Peek();
        counter++;
        
        key = "SPACE    ";
        ht.writeKey(key);
        
        textM.text = textM.text + '_';
    }
    
    public void tab_key()
    {
        isShiftOn = false;
        if (textM.text[textM.text.Length - 1] == '_')
            textM.text = textM.text.Remove(textM.text.Length - 1);
        
        textStack.Push("\t");
        textM.text = textM.text + textStack.Peek();
        counter++;
        
        key = "TAB      ";
        ht.writeKey(key);
        
        textM.text = textM.text + '_';
    }

    public void enter_key()
    {
        isShiftOn = false;
        if (textM.text[textM.text.Length - 1] == '_')
            textM.text = textM.text.Remove(textM.text.Length - 1);
        
        textStack.Push("\n");
        textM.text = textM.text + textStack.Peek();
        counter++;
        
        key = "ENTER    ";
        ht.writeKey(key);
        
        textM.text = textM.text + '_';
    }

    public void backspace_key()
    {
        isShiftOn = false;
        if (counter != 0)
        {
            backspaceCounter++;
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

            textM.text = tempText + '_';

            counter--;
        }
        
        key = "BACKSPACE";
        ht.writeKey(key);
    }

    public void clear()
    {
        while (counter != 0)
        {
            textStack.Pop();
            counter--;
        }
    }
    
    private void CursorBlinkOn()
    {
        Color32 white = new Color32(255, 255, 255, 255);
        
        int charIndex = textM.text.Length - 1;
        int meshIndex = textM.textInfo.characterInfo[charIndex].materialReferenceIndex;
        int vertexIndex = textM.textInfo.characterInfo[charIndex].vertexIndex;

        Color32[] vertexColors = textM.textInfo.meshInfo[meshIndex].colors32;
        vertexColors[vertexIndex + 0] = white;
        vertexColors[vertexIndex + 1] = white;
        vertexColors[vertexIndex + 2] = white;
        vertexColors[vertexIndex + 3] = white;

        textM.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
    }
    
    private void CursorBlinkOff()
    {
        Color32 TransparentWhite = new Color32(255, 255, 255, 0);
        
        int charIndex = textM.text.Length - 1;
        int meshIndex = textM.textInfo.characterInfo[charIndex].materialReferenceIndex;
        int vertexIndex = textM.textInfo.characterInfo[charIndex].vertexIndex;

        Color32[] vertexColors = textM.textInfo.meshInfo[meshIndex].colors32;
        vertexColors[vertexIndex + 0] = TransparentWhite;
        vertexColors[vertexIndex + 1] = TransparentWhite;
        vertexColors[vertexIndex + 2] = TransparentWhite;
        vertexColors[vertexIndex + 3] = TransparentWhite;

        textM.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
    }

}
