using System;
using System.Collections;
using TMPro;
using UnityEngine;


/**
 * Author      : Joshua Reynolds
 * Email       : joshuare@mtu.edu
 * Description : This class houses the function calls for all key presses on the keyboard. This class also takes care
 *             : of the the cursor blinking effect in the "type bar".
 */
public class ButtonScript : MonoBehaviour
{
    // Initialization of variables
    public TextMeshPro textM;
    public TextMeshPro leftShiftText;
    public TextMeshPro rightShiftText;
    public TextMeshPro capsText;
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
    
    public bool isShiftOn = false;
    public bool isCapsOn = false;
    
    private int counter = 0;
    public int backspaceCounter = 0;
    
    public string key = "";

    public handTracker ht;
    public sentenceScript ss;
    public GameObject keyboard;
    

    Stack textStack = new Stack();

    /**
     * Description : This method starts the cursor blink effect. Blink on starts immediately and blink off starts half
     *             : a second later to interleave the cursor.
     */
    public void Start()
    {
        // Check if keyboard is active
        if (keyboard.activeSelf == true)
        {
            InvokeRepeating("CursorBlinkOn", 0f, 1.0f);
            InvokeRepeating("CursorBlinkOff", 0.5f, 1.0f);
        }
    }

    /**
     * Description : This method fires every frame and updates the text of the key if it is active. This effect is
     *             : only on the shift key and the caps lock key.
     */
    public void Update()
    {
        // Check if keyboard is active
        if (keyboard.activeSelf == true)
        {
            // Check if we're on the keyboard screen
            if (ss.errorRateMenuF.activeSelf == false || ss.errorRateMenuQ.activeSelf == false)
            {
                // Check which key is active
                if (isShiftOn && !isCapsOn)
                {
                    leftShiftText.color = Color.red;
                    rightShiftText.color = Color.red;

                    capsText.color = Color.white;
                    
                    KeysOnUppercase(); // change keys to uppercase variant
                }
                else if (isShiftOn && isCapsOn)
                {
                    leftShiftText.color = Color.red;
                    rightShiftText.color = Color.red;

                    capsText.color = Color.red;
                    
                    KeysOnUppercase(); // change keys to uppercase variant
                }
                else if (!isShiftOn && !isCapsOn)
                {
                    leftShiftText.color = Color.white;
                    rightShiftText.color = Color.white;

                    capsText.color = Color.white;
                    
                    KeysOnLowercase(); // change keys to lowercase variant
                }
                else if (!isShiftOn && isCapsOn)
                {
                    leftShiftText.color = Color.white;
                    rightShiftText.color = Color.white;

                    capsText.color = Color.red;
                    
                    KeysOnUppercase(); // change keys to uppercase variant
                }
            }
        }
    }

    /**
     * Description           : This method pushes the text into the textStack stack, increments the length of the text,
     *                       : and displays it in the "typed section".
     * 
     * Parameter - upperKey  : The uppercased variant of the key
     * Parameter - lowerKey  : The lowercased variant of the key
     * Parameter - upperChar : The uppercased variant of the character
     * Parameter - lowerChar : The lowercased variant of the character
     * Parameter - special   : The toggle denoting special keys (like numbers and characters)
     */
    private void KeyPressMainDriver(string upperKey, string lowerKey, object upperChar, object lowerChar, bool special)
    {
        // Momentarily remove cursor
        if (textM.text[textM.text.Length - 1] == '_')
            textM.text = textM.text.Remove(textM.text.Length - 1);

        // Write key to file and push key into textStack
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
        
        // Add key to displayed text and increment length
        textM.text = textM.text + textStack.Peek();
        counter++;
        
        // Put cursor back into string
        textM.text = textM.text + '_';
    }
    
    /**
     * Description : The uppercased variants of the string value of key.
     */
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

    /**
     * Description : The lowercased variants of the string value of key.
     */
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
    
    /**
     * Description : Handle left shift key button push functionality.
     */
    public void left_shift_key()
    {
        // Toggle shift key appropriately
        if (isShiftOn)
            isShiftOn = false;
        else
            isShiftOn = true;

        // Write key to file
        key = "LSHIFT   ";
        ht.writeKey(key);
    }
    
    /**
     * Description : Handle right shift key button push functionality.
     */
    public void right_shift_key()
    {
        // Toggle shift key appropriately
        if (isShiftOn)
            isShiftOn = false;
        else
            isShiftOn = true;

        // Write key to file
        key = "RSHIFT   ";
        ht.writeKey(key);
    }
    
    /**
     * Description : Handle caps lock key button push functionality.
     */
    public void caps_key()
    {
        // Toggle caps lock key appropriately
        if (isCapsOn)
            isCapsOn = false;
        else
            isCapsOn = true;

        // Write key to file
        key = "CAPS     ";
        ht.writeKey(key);
    }
    
    /**
     * Description : Handle 'a' key button push functionality.
     */
    public void a_key()
    {
        KeyPressMainDriver("A        ", "a        ", "A", "a", true);
    }
    
    /**
     * Description : Handle 'b' key button push functionality.
     */
    public void b_key()
    {
        KeyPressMainDriver("B        ", "b        ", "B", "b", true);
    }
    
    /**
     * Description : Handle 'c' key button push functionality.
     */
    public void c_key()
    {
        KeyPressMainDriver("C        ", "c        ", "C", "c", true);
    }
    
    /**
     * Description : Handle 'd' key button push functionality.
     */
    public void d_key()
    {
        KeyPressMainDriver("D        ", "d        ", "D", "d", true);
    }
    
    /**
     * Description : Handle 'e' key button push functionality.
     */
    public void e_key()
    {
        KeyPressMainDriver("E        ", "e        ", "E", "e", true);
    }
    
    /**
     * Description : Handle 'f' key button push functionality.
     */
    public void f_key()
    {
        KeyPressMainDriver("F        ", "f        ", "F", "f", true);
    }
    
    /**
     * Description : Handle 'g' key button push functionality.
     */
    public void g_key()
    {
        KeyPressMainDriver("G        ", "g        ", "G", "g", true);
    }
    
    /**
     * Description : Handle 'h' key button push functionality.
     */
    public void h_key()
    {
        KeyPressMainDriver("H        ", "h        ", "H", "h", true);
    }
    
    /**
     * Description : Handle 'i' key button push functionality.
     */
    public void i_key()
    {
        KeyPressMainDriver("I        ", "i        ", "I", "i", true);
    }
    
    /**
     * Description : Handle 'j' key button push functionality.
     */
    public void j_key()
    {
        KeyPressMainDriver("J        ", "j        ", "J", "j", true);
    }
    
    /**
     * Description : Handle 'k' key button push functionality.
     */
    public void k_key()
    {
        KeyPressMainDriver("K        ", "k        ", "K", "k", true);
    }
    
    /**
     * Description : Handle 'l' key button push functionality.
     */
    public void l_key()
    {
        KeyPressMainDriver("L        ", "l        ", "L", "l", true);
    }
    
    /**
     * Description : Handle 'm' key button push functionality.
     */
    public void m_key()
    {
        KeyPressMainDriver("M        ", "m        ", "M", "m", true);
    }
    
    /**
     * Description : Handle 'n' key button push functionality.
     */
    public void n_key()
    {
        KeyPressMainDriver("N        ", "n        ", "N", "n", true);
    }
    
    /**
     * Description : Handle 'o' key button push functionality.
     */
    public void o_key()
    {
        KeyPressMainDriver("O        ", "o        ", "O", "o", true);
    }
    
    /**
     * Description : Handle 'p' key button push functionality.
     */
    public void p_key()
    {
        KeyPressMainDriver("P        ", "p        ", "P", "p", true);
    }
    
    /**
     * Description : Handle 'q' key button push functionality.
     */
    public void q_key()
    {
        KeyPressMainDriver("Q        ", "q        ", "Q", "q", true);
    }
    
    /**
     * Description : Handle 'r' key button push functionality.
     */
    public void r_key()
    {
        KeyPressMainDriver("R        ", "r        ", "R", "r", true);
    }
    
    /**
     * Description : Handle 's' key button push functionality.
     */
    public void s_key()
    {
        KeyPressMainDriver("S        ", "s        ", "S", "s", true);
    }
    
    /**
     * Description : Handle 't' key button push functionality.
     */
    public void t_key()
    {
        KeyPressMainDriver("T        ", "t        ", "T", "t", true);
    }
    
    /**
     * Description : Handle 'u' key button push functionality.
     */
    public void u_key()
    {
        KeyPressMainDriver("U        ", "u        ", "U", "u", true);
    }
    
    /**
     * Description : Handle 'v' key button push functionality.
     */
    public void v_key()
    {
        KeyPressMainDriver("V        ", "v        ", "V", "v", true);
    }
    
    /**
     * Description : Handle 'w' key button push functionality.
     */
    public void w_key()
    {
        KeyPressMainDriver("W        ", "w        ", "W", "w", true);
    }
    
    /**
     * Description : Handle 'x' key button push functionality.
     */
    public void x_key()
    {
        KeyPressMainDriver("X        ", "x        ", "X", "x", true);
    }
    
    /**
     * Description : Handle 'y' key button push functionality.
     */
    public void y_key()
    {
        KeyPressMainDriver("Y        ", "y        ", "Y", "y", true);
    }
    
    /**
     * Description : Handle 'z' key button push functionality.
     */
    public void z_key()
    {
        KeyPressMainDriver("Z        ", "z        ", "Z", "z", true);
    }
    
    /**
     * Description : Handle '~' key button push functionality.
     */
    public void tilda_key()
    {
        KeyPressMainDriver("~        ", "`        ", "~", "`", false);
    }
    
    /**
     * Description : Handle '1' key button push functionality.
     */
    public void one_key()
    {
        KeyPressMainDriver("!        ", "1        ", "!", "1", false);
    }
    
    /**
     * Description : Handle '2' key button push functionality.
     */
    public void two_key()
    {
        KeyPressMainDriver("@        ", "2        ", "@", "2", false);
    }
    
    /**
     * Description : Handle '3' key button push functionality.
     */
    public void three_key()
    {
        KeyPressMainDriver("#        ", "3        ", "#", "3", false);
    }
    
    /**
     * Description : Handle '4' key button push functionality.
     */
    public void four_key()
    {
        KeyPressMainDriver("$        ", "4        ", "$", "4", false);
    }
    
    /**
     * Description : Handle '5' key button push functionality.
     */
    public void five_key()
    {
        KeyPressMainDriver("%        ", "5        ", "%", "5", false);
    }
    
    /**
     * Description : Handle '6' key button push functionality.
     */
    public void six_key()
    {
        KeyPressMainDriver("^        ", "6        ", "^", "6", false);
    }
    
    /**
     * Description : Handle '7' key button push functionality.
     */
    public void seven_key()
    {
        KeyPressMainDriver("&        ", "7        ", "&", "7", false);
    }
    
    /**
     * Description : Handle '8' key button push functionality.
     */
    public void eight_key()
    {
        KeyPressMainDriver("*        ", "8        ", "*", "8", false);
    }
    
    /**
     * Description : Handle '9' key button push functionality.
     */
    public void nine_key()
    {
        KeyPressMainDriver("(        ", "9        ", "(", "9", false);
    }
    
    /**
     * Description : Handle '0' key button push functionality.
     */
    public void zero_key()
    {
        KeyPressMainDriver(")        ", "0        ", ")", "0", false);
    }
    
    /**
     * Description : Handle '-' key button push functionality.
     */
    public void minus_key()
    {
        KeyPressMainDriver("_        ", "-        ", "_", "-", false);
    }
    
    /**
     * Description : Handle '=' key button push functionality.
     */
    public void equal_key()
    {
        KeyPressMainDriver("+        ", "=        ", "+", "=", false);
    }
    
    /**
     * Description : Handle '[' key button push functionality.
     */
    public void sqBracketLeft_key()
    {
        KeyPressMainDriver("{        ", "[        ", "{", "[", false);
    }
    
    /**
     * Description : Handle ']' key button push functionality.
     */
    public void sqBracketRight_key()
    {
        KeyPressMainDriver("}        ", "]        ", "}", "]", false);
    }
    
    /**
     * Description : Handle '\' key button push functionality.
     */
    public void backSlash_key()
    {
        KeyPressMainDriver("|        ", "\\        ", "|", "\\", false);
    }
    
    /**
     * Description : Handle ':' key button push functionality.
     */
    public void colon_key()
    {
        KeyPressMainDriver(":        ", ";        ", ":", ";", false);
    }
    
    /**
     * Description : Handle '"' key button push functionality.
     */
    public void quote_key()
    {
        KeyPressMainDriver("\"        ", "'        ", "\"", "'", false);
    }
    
    /**
     * Description : Handle ',' key button push functionality.
     */
    public void comma_key()
    {
        KeyPressMainDriver("<        ", ",        ", "<", ",", false);
    }
    
    /**
     * Description : Handle '.' key button push functionality.
     */
    public void period_key()
    {
        KeyPressMainDriver(">        ", ".        ", ">", ".", false);
    }
    
    /**
     * Description : Handle '/' key button push functionality.
     */
    public void slash_key()
    {
        KeyPressMainDriver("?        ", "/        ", "?", "/", false);
    }
    
    /**
     * Description : Handle space key button push functionality.
     */
    public void space_key()
    {
        isShiftOn = false;
        
        // Momentarily remove cursor
        if (textM.text[textM.text.Length - 1] == '_')
            textM.text = textM.text.Remove(textM.text.Length - 1);
        
        // Add key to displayed text and increment length 
        textStack.Push(" ");
        textM.text = textM.text + textStack.Peek();
        counter++;
        
        // Write key to file
        key = "SPACE    ";
        ht.writeKey(key);
        
        // Put cursor back into string
        textM.text = textM.text + '_';
    }
    
    /**
     * Description : Handle tab key button push functionality.
     */
    public void tab_key()
    {
        isShiftOn = false;
        
        // Momentarily remove cursor
        if (textM.text[textM.text.Length - 1] == '_')
            textM.text = textM.text.Remove(textM.text.Length - 1);
        
        // Add key to displayed text and increment length 
        textStack.Push("\t");
        textM.text = textM.text + textStack.Peek();
        counter++;
        
        // Write key to file
        key = "TAB      ";
        ht.writeKey(key);
        
        // Put cursor back into string
        textM.text = textM.text + '_';
    }

    /**
     * Description : Handle enter key button push functionality.
     */
    public void enter_key()
    {
        isShiftOn = false;
        
        // Momentarily remove cursor
        if (textM.text[textM.text.Length - 1] == '_')
            textM.text = textM.text.Remove(textM.text.Length - 1);
        
        // Add key to displayed text and increment length 
        textStack.Push("\n");
        textM.text = textM.text + textStack.Peek();
        counter++;
        
        // Write key to file
        key = "ENTER    ";
        ht.writeKey(key);
        
        // Put cursor back into string
        textM.text = textM.text + '_';
    }

    /**
     * Description : Handle backspace key button push functionality.
     */
    public void backspace_key()
    {
        isShiftOn = false;
        
        // If the string is longer than 0
        if (counter != 0)
        {
            backspaceCounter++; // Adjust counter for usage in backspaces used per character output
            String tempText = ""; // Initialize temporary empty string
            
            textStack.Pop(); // Remove cursor from text

            Stack tempStack = new Stack();

            // Empty textStack into tempStack 
            while (textStack.Count != 0)
            {
                tempStack.Push(textStack.Pop());
            }

            // Transfer tempStack back into textStack
            while (tempStack.Count != 0) 
            {
                tempText = tempText + tempStack.Peek(); 
                textStack.Push(tempStack.Pop());
            }
            
            // Put cursor back into string
            textM.text = tempText + '_';

            // Remove one character from string length
            counter--;
        }
        
        // Write key to file
        key = "BACKSPACE";
        ht.writeKey(key);
    }

    /**
     * Description : This method removes all characters from the textStack
     */
    public void Clear()
    {
        while (counter != 0)
        {
            textStack.Pop();
            counter--;
        }
    }
    
    /**
     * Description : This method makes the cursor blink on
     */
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
    
    /**
     * Description : This method makes the cursor blink off
     */
    private void CursorBlinkOff()
    {
        Color32 transparentWhite = new Color32(255, 255, 255, 0);
        
        int charIndex = textM.text.Length - 1;
        int meshIndex = textM.textInfo.characterInfo[charIndex].materialReferenceIndex;
        int vertexIndex = textM.textInfo.characterInfo[charIndex].vertexIndex;

        Color32[] vertexColors = textM.textInfo.meshInfo[meshIndex].colors32;
        vertexColors[vertexIndex + 0] = transparentWhite;
        vertexColors[vertexIndex + 1] = transparentWhite;
        vertexColors[vertexIndex + 2] = transparentWhite;
        vertexColors[vertexIndex + 3] = transparentWhite;

        textM.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
    }
}
