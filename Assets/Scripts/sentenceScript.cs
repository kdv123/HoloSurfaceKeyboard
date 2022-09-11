using System;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit;
using MRTKExtensions.QRCodes;
using TMPro;
using UnityEngine;
using Random = System.Random;

/**
 * Author      : Joshua Reynolds
 * Email       : joshuare@mtu.edu
 * Description : This class houses the function calls for all the main functionality of the app. This is the switching
 *             : of the the keyboards, the switching between error menus and the calculations of the values we are
 *             : studying.
 */
public class sentenceScript : MonoBehaviour
{
    // Initialization of variables
    public TextMeshPro textF;
    public TextMeshPro textQ;
    public TextMeshPro textTypeF;
    public TextMeshPro textTypeQ;
    public TextMeshPro cerF;
    public TextMeshPro cerQ;
    public TextMeshPro cerAF;
    public TextMeshPro cerAQ;
    public TextMeshPro wpmF;
    public TextMeshPro wpmQ;
    public TextMeshPro wpmAF;
    public TextMeshPro wpmAQ;
    public TextMeshPro sentenceNumF;
    public TextMeshPro sentenceNumQ;
    public TextMeshPro sentenceNumFE;
    public TextMeshPro sentenceNumQE;
    public TextMeshPro textFE;
    public TextMeshPro textTypeFE;
    public TextMeshPro textQE;
    public TextMeshPro textTypeQE;

    public TextMeshProUGUI particpantNumText;
    public TextMeshProUGUI particpantNumTextS;

    public GameObject startButtonF;
    public GameObject startButtonQ;
    public GameObject nextButtonF;
    public GameObject nextButtonQ;
    public GameObject nextScenarioButtonF;
    public GameObject nextScenarioButtonQ;
    public GameObject finishButtonF;
    public GameObject finishButtonQ;
    public GameObject nextButtonFE;
    public GameObject nextButtonQE;
    public GameObject errorRateMenuF;
    public GameObject errorRateMenuQ;
    public GameObject keyboardF;
    public GameObject keyboardQ;
    public GameObject menuScene;
    public GameObject freeScene;
    public GameObject qrScene;
    public GameObject freePreScene;
    public GameObject qrPreScene;
    public GameObject camera;
    public GameObject whatToDoObjectQ;
    public GameObject whatToDoObjectF;
    public GameObject qrHolder;
    public GameObject freeHolder;
    public GameObject allDoneObjectQ;
    public GameObject allDoneObjectF;
    
    public handTracker ht;
    public preSceneTimers pst;
    public ButtonScript bsF;
    public ButtonScript bsQ;
    public QRTrackerController qrtc;
    public qrRaiseLower qrrl;
    public SpatialGraphCoordinateSystemSetter sgcss;
    public FPSTracker fps;
    
    private DateTime timeStart;
    private DateTime timeEnd;
    public TimeSpan finalTime;

    public int odd_even_num = -1;
    public int odd_even_num_S = -1;
    public int pageNum = 0;
    
    private int globalCounter = 0;
    private int counter = -2;
    private int wpmCounter = 0;
    private int backspaceOutputCounter = 0;

    private double maxCER = Int32.MinValue;
    private double minCER = Int32.MaxValue;
    private double maxWPM = Int32.MinValue;
    private double minWPM = Int32.MaxValue;
    private double maxBC = Int32.MinValue;
    private double minBC = Int32.MaxValue;
    private double averageErrorRate = 0;
    private double averageWordsPerMinute = 0;
    private double averageBackspaceOutput = 0;

    private Boolean check = true;

    private Vector3 cameraPos;

    // arraylist with many random sentences
    private List<String> rawSentenceList = new List<string>
                                        {
                                            "Are you going to join us for lunch?",
                                            "Is she done yet?",
                                            "Thanks for the quick turnaround.",
                                            "How are you?",
                                            "Yes, I am playing.",
                                            "Please call tomorrow if possible.",
                                            "We are all fragile.",
                                            "I would like to attend if so.",
                                            "I can return earlier.",
                                            "I am trying again.",
                                            "I will bring John Brindle.",
                                            "He would love anything about rocks.",
                                            "What do you hear?",
                                            "Hope your trip to Florida was good.",
                                            "What's his problem?",
                                            "She called and wants to come over this AM.",
                                            "There is now a meeting at 8PM as well.",
                                            "See you soon!",
                                            "It reads like she is in.",
                                            "Has Dynegy made a specific request?",
                                            "I am walking in now.",
                                            "They have capacity now.",
                                            "A gift isn't necessary.",
                                            "Tell her to get my expense report done.",
                                            "I am out of town on business tonight.",
                                            "I'm waiting until she comes home.",
                                            "Not even close.",
                                            "Chris Foster is in!",
                                            "They are more efficiently pooled.",
                                            "Could you try ringing her?",
                                            "Do you need it today?",
                                            "Keep me posted!",
                                            "John this message concerns me.",
                                            "Call me to give me a heads up.",
                                            "And leave my school alone.",
                                            "What is in the plan?",
                                            "Where do you want to meet to walk over there?",
                                            "I am almost speechless.",
                                            "Ava, please put me on the list.",
                                            "Suggest you get facts before judging anyone.",
                                            "Have I mentioned how much I love Houston traffic?",
                                            "Take what you can get.",
                                            "Should systems manage the migration?",
                                            "I think that is the right answer.",
                                            "I'm glad you liked it.",
                                            "This looks fine.",
                                            "I've never worked with her.",
                                            "Get with Mary for format.",
                                            "I hope you are feeling better.",
                                            "I'm glad she likes her tree.",
                                            "Are you getting all the information you need?",
                                            "Have a great trip.",
                                            "Did you talk to Ava this morning?",
                                            "Can you help?",
                                            "It's not looking too good is it?",
                                            "Has anyone else heard anything?",
                                            "Is it over?",
                                            "I'll get you one.",
                                            "OK with me.",
                                            "What's going on?",
                                            "You can talk to Becky!",
                                            "I talked to Duran.",
                                            "I agreed terms with Greg.",
                                            "I am at the lake.",
                                            "I told you silly.",
                                            "Wednesday is definitely a hot chocolate day.",
                                            "Thanks for your concern.",
                                            "Thursday works better for me.",
                                            "What is the mood?",
                                            "I am on my way.",
                                            "Do we need to discuss?",
                                            "Just playing with you!",
                                            "What's your phone number?",
                                            "Thanks for checking with me.",
                                            "This is very sensitive.",
                                            "Can we have them until we move?",
                                            "On the plane, doors closing.",
                                            "I'll catch up with you tomorrow.",
                                            "Are you in today?",
                                            "Let it rip.",
                                            "We just need a sitter.",
                                            "We must be consistent.",
                                            "She has absolutely everything.",
                                            "I'm not planning on doing anything this week.",
                                            "His is good I think.",
                                            "We can have wine and catch up.",
                                            "Don't they have some conflicts here?",
                                            "Money wise that is.",
                                            "What is wrong?",
                                            "Where are you?",
                                            "Thanks good job.",
                                            "Hopefully this can wait until Monday.",
                                            "No employment claims for gas or power.",
                                            "Why do you ask?",
                                            "Mike, are you aware of this?",
                                            "I agree since I am at the bank right now.",
                                            "I was planning to attend.",
                                            "That would be great.",
                                            "Thank you for your prompt reply.",
                                            "Can you help me here?",
                                            "I changed that in one prior draft.",
                                            "What is the cost issue?",
                                            "Please send me an email.",
                                            "What a jerk.",
                                            "Don't make me pull tapes on whether you understood our fee.",
                                            "I wanted to go drinking with you.",
                                            "No material impact.",
                                            "We don't seem to have any positive income there.",
                                            "I will be back Friday.",
                                            "If not can I call you?",
                                            "Do you still need me to sign something?",
                                            "What's your proposal?",
                                            "Can we meet at 3:30?",
                                            "Both of us are still here.",
                                            "Not even in yet.",
                                            "Disney was great and I've been to eight baseball games.",
                                            "How soon do you need it?",
                                            "What number should he call you on?",
                                            "Ava, do we need to worry about this?",
                                            "Are you feeling better?",
                                            "You have a nice holiday too.",
                                            "We need to talk about this month.",
                                            "What about Jay?",
                                            "We are waiting on the cold front.",
                                            "Ken agreed yesterday.",
                                            "Neil has been asking around.",
                                            "Are you available?",
                                            "That would likely be an expensive option.",
                                            "Good for you.",
                                            "We will keep you posted.",
                                            "Do we have anyone in Portland?",
                                            "No surprise there.",
                                            "Hope you guys are doing fine.",
                                            "Are you going to call?",
                                            "Did that happen?",
                                            "I would be glad to participate.",
                                            "I worked on the grade level promotion.",
                                            "I have a request.",
                                            "You're the greatest.",
                                            "What is this?",
                                            "Travis is in charge.",
                                            "Can you handle?",
                                            "Their key decision maker did not show which is not a good sign.",
                                            "Can you help get this cleared up?",
                                            "I have a high level in my office.",
                                            "Thanks I will.",
                                            "If we don't get it, could be trouble.",
                                            "Are you being a baby?",
                                            "Did you get this?",
                                            "I'm on a plane.",
                                            "Florida is great.",
                                            "I sent it to her.",
                                            "I will call.",
                                            "Please let me know if you learn anything at the floor meeting.",
                                            "Please revise accordingly.",
                                            "I don't have the distraction of taking care of Mimi.",
                                            "Could you see where this stands?",
                                            "I'm going to class.",
                                            "See you on the third.",
                                            "Did we get ours back?",
                                            "What is up with ENE?",
                                            "I'll call you in the morning.",
                                            "Are you sure?",
                                            "Sorry about that!",
                                            "Is that OK?",
                                            "Jan has a lot of detail.",
                                            "Need to watch closely.",
                                            "What do you think?",
                                            "I should have more info by our meeting this afternoon.",
                                            "Can you bring these to 49C1?",
                                            "Are you there?",
                                            "I can review afterwards and get back to you tonight.",
                                            "I hope he is having a fantastic time.",
                                            "Can you resend me the Doyle email from last week?",
                                            "If so what was it?",
                                            "I'm in Stan's office.",
                                            "Hey TK, how are you doing?",
                                            "Don't forget the wood.",
                                            "This seems fine to me.",
                                            "What a pain.",
                                            "Pressure to finish my review!",
                                            "I like it.",
                                            "I have 30 minutes then.",
                                            "Will it be delivered?",
                                            "Was wondering if you and Natalie connected?",
                                            "Not at this time.",
                                            "I'm still here.",
                                            "We will get you a copy.",
                                            "I will follow up with him as soon as the dust settles.",
                                            "We're on the way.",
                                            "Or are you going to be tied up with dinner?",
                                            "Is this the only time available?",
                                            "No there will be plenty of others.",
                                            "What is the purpose of this?",
                                            "No can do.",
                                            "Nice weather for it.",
                                            "I think those are the right dates.",
                                            "Thai sounds good.",
                                            "Do you want to fax it to my hotel?",
                                            "Did you differ from me?"
                                        };

    private List<String> newSentenceList = new List<string>();

    public static Random r = new Random();
    
    /**
     * Description : This method is called at the start of the scene. It trims the whole sentence list to sentences with
     *             : 30 characters or less (that way they fit on the keyboard). It also spawns in a keyboard in front of
     *             : the participants eyes.
     */
    public void Start()
    {
        // Grab only sentences that fit within 30 characters
        for (int i = 0; i < rawSentenceList.Count; i++)
        {
            if (rawSentenceList[i].ToString().Length <= 30)
            {
                newSentenceList.Add(rawSentenceList[i]);
            }
        }
        
        // Spawn in menu at head level
        menuScene.transform.eulerAngles = new Vector3(0, camera.transform.eulerAngles.y, 0);
        menuScene.transform.position = camera.transform.position + (camera.transform.forward * 0f) + (camera.transform.right * 0.0255f) + (camera.transform.up * -0.4f);
        
        Invoke("SpatialAwareness", 1f);
    }
    
    /**
     * Description : This method turns off spatial awareness wireframe
     */
    public void SpatialAwareness()
    {
        var spatialAwarenessSystem = CoreServices.SpatialAwarenessSystem;
        if (spatialAwarenessSystem != null)
        {
            spatialAwarenessSystem.SuspendObservers();
            spatialAwarenessSystem.ClearObservations();
            // spatialAwarenessSystem.ResumeObservers();
        }
    }

    /**
     * Description      : This method randomly shuffles the list of sentences
     *
     * Parameter - List : The list to be shuffled
     */
    void shuffle<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            var temp = list[i];

            int randomIndex = r.Next(list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    /**
     * Description : This method starts the midair keyboard from the special menu behind the users head.
     */
    public void shortcutStartUpFREE()
    {
        // Shuffle sentence list at start of experiment
        shuffle(newSentenceList);
        
        // Verify participant number is valid
        if (odd_even_num_S == -1)
        {
            particpantNumTextS.color = Color.red;
        }
        else
        {
            // Go into midair keyboard and do start up sequence
            MenuToFree();
            pst.StartUpS();
        }
        
        // Create the midair keyboard logging file
        if (globalCounter == 0)
        {
            StartOutWordsF();
            ht.createF();
            
            globalCounter++;
        }
        
        // Toggle midair keyboard indicator
        ht.freeSwitch.gameObject.SetActive(true);

        // Turn timer off
        check = false;

        // Save special menu participant number to normal participant number
        odd_even_num = odd_even_num_S;
        
        // Put page on final page
        pageNum = 2;
    }
    
    /**
     * Description : This method starts the horizontal keyboard from the special menu behind the users head.
     */
    public void shortcutStartUpQRH()
    {
        // Shuffle sentence list at start of experiment
        shuffle(newSentenceList);

        // Verify participant number is valid
        if (odd_even_num_S == -1)
        {
            particpantNumTextS.color = Color.red;
        }
        else
        {
            // Go into qr keyboard and do start up sequence
            MenuToQR();
            pst.StartUpS();
        }
        
        // Create the qr keyboard logging file
        if (globalCounter == 0)
        {
            StartOutWordsQH();
            ht.createQH();
            
            globalCounter++;
        }
        
        // Toggle horizontal keyboard indicator
        ht.horizontalSwitch.gameObject.SetActive(true);

        // Turn timer off
        check = false;

        // Save special menu participant number to normal participant number
        odd_even_num = odd_even_num_S;
        
        // Put page on final page
        pageNum = 2;
    }
    
    /**
     * Description : This method starts the vertical keyboard from the special menu behind the users head.
     */
    public void shortcutStartUpQRV()
    {
        // Shuffle sentence list at start of experiment
        shuffle(newSentenceList);

        // Verify participant number is valid
        if (odd_even_num_S == -1)
        {
            particpantNumTextS.color = Color.red;
        }
        else
        {
            // Go into qr keyboard and do start up sequence
            MenuToQR();
            pst.StartUpS();
        }
        
        // Create the qr keyboard logging file
        if (globalCounter == 0)
        {
            StartOutWordsQV();
            ht.createQV();
            
            globalCounter++;
        }
        
        // Toggle vertical keyboard indicator
        ht.verticalSwitch.gameObject.SetActive(true);

        // Turn timer off
        check = false;

        // Save special menu participant number to normal participant number
        odd_even_num = odd_even_num_S;
        
        // Put page on final page
        pageNum = 2;
    }
    
    /**
     * Description : This method starts the experiment
     */
    public void startExperiment()
    {
        // Shuffle sentence list at start of experiment
        shuffle(newSentenceList);

        // Load the correct scene
        if (odd_even_num % 6 == 0)
        {
            MenuToQR();
            pst.StartUp();
        }
        else if (odd_even_num % 6 == 1)
        {
            MenuToQR();
            pst.StartUp();
        }
        else if (odd_even_num % 6 == 2)
        {
            MenuToFree();
            pst.StartUp();
        }
        else if (odd_even_num % 6 == 3)
        {
            MenuToFree();
            pst.StartUp();
        }
        else if (odd_even_num % 6 == 4)
        {
            MenuToQR();
            pst.StartUp();
        }
        else if (odd_even_num % 6 == 5)
        {
            MenuToQR();
            pst.StartUp();
        }
        else
        {
            particpantNumText.color = Color.red;
        }

        // Start the collection of data
        if (globalCounter == 0)
        {
            StartOutWordsF();
            StartOutWordsQH();
            StartOutWordsQV();
            
            ht.create();

            globalCounter++;
        }

        check = false;
    }
    
    /**
     * Description : This method progresses to the next sentence
     */
    public void nextSentence()
    {
        // nextButtonFE.SetActive(false);
        // nextButtonQE.SetActive(false);
        // nextButtonF.SetActive(false);
        // nextButtonQ.SetActive(false);
        
        // If its a practice sentence - dont do anything
        if (counter == -2)
        {
            textTypeF.text = '_'.ToString();
            textTypeQ.text = '_'.ToString();
        }
        
        // If its not a practice sentence
        if (counter < 12)
        {
            // If midair scene
            if (freeScene.activeSelf == true)
            {
                // Hide next button
                // Create start text
                // Track statistics
                // Print key text
                // Spawn next button
                
                nextButtonFE.SetActive(false);
                
                if (counter == -2)
                {
                    ht.sbF.Append(Time() + ",Button Pushed,START," + fps.FPS_Text() +"\n\n");
                }

                if (counter != -2)
                {
                    keyboardF.SetActive(true);
                    errorRateMenuF.SetActive(false);
                    
                    cerF.text = "Error Rate: ";
                    wpmF.text = "Words Per Minute: ";
                    finalTime = TimeSpan.Zero;
                    bsF.backspaceCounter = 0;
                }
                
                startButtonF.SetActive(false);

                textF.text = newSentenceList[counter + 2];
                
                if (counter < 0)
                    ht.sbF.Append(Time() + ",Sentence to type (Practice)," + newSentenceList[counter + 2] + "," + fps.FPS_Text() + "\n");
                else
                    ht.sbF.Append(Time() + ",Sentence to type (" + (counter + 1) + "/12)," + newSentenceList[counter + 2] + "," + fps.FPS_Text() + "\n");

                if (counter < 0)
                    sentenceNumF.text = ("Practice");
                else
                    sentenceNumF.text = ((counter + 1) + "/12");

                counter = counter + 1;
                
                bsF.Clear();
                Invoke("buttonSpawn", 0f); // was 2f
            }
            else // If qr scene
            {
                // Hide next button
                // Create start text
                // Track statistics
                // Print key text
                // Spawn next button
                
                nextButtonQE.SetActive(false);

                if (counter == 0)
                {
                    qrrl.globalCounter = 0;
                }

                // if (counter >= -2 && counter <= -1)
                // {
                //     if (ht.horizontalSwitch.activeSelf == true)
                //         ht.outWordsQH += Time() + ",Current Depth (Start height)," + qrHolder.transform.localPosition.y + "," + fps.FPS_Text() + "\n";
                //     
                //     if (ht.verticalSwitch.activeSelf == true)
                //         ht.outWordsQV += Time() + ",Current Depth (Start height)," + qrHolder.transform.localPosition.y + "," + fps.FPS_Text() + "\n";
                // }
                // else if (counter >= 0 && counter <= 3)
                // {
                //     if (ht.horizontalSwitch.activeSelf == true)
                //         ht.outWordsQH += Time() + ",Current Depth," + qrHolder.transform.localPosition.y + "," + fps.FPS_Text() + "\n";
                //     
                //     if (ht.verticalSwitch.activeSelf == true)
                //         ht.outWordsQV += Time() + ",Current Depth," + qrHolder.transform.localPosition.y + "," + fps.FPS_Text() + "\n";
                // }
                // else if (counter >= 4 && counter <= 7)
                // {
                //     if (ht.horizontalSwitch.activeSelf == true)
                //         ht.outWordsQH += Time() + ",Current Depth," + qrHolder.transform.localPosition.y + "," + fps.FPS_Text() + "\n";
                //     
                //     if (ht.verticalSwitch.activeSelf == true)
                //         ht.outWordsQV += Time() + ",Current Depth," + qrHolder.transform.localPosition.y + "," + fps.FPS_Text() + "\n";
                // }
                // else if (counter >= 8 && counter <= 12)
                // {
                //     if (ht.horizontalSwitch.activeSelf == true)
                //         ht.outWordsQH += Time() + ",Current Depth," + qrHolder.transform.localPosition.y + "," + fps.FPS_Text() + "\n";
                //                 
                //     if (ht.verticalSwitch.activeSelf == true)
                //         ht.outWordsQV += Time() + ",Current Depth," + qrHolder.transform.localPosition.y + "," + fps.FPS_Text() + "\n";
                // }
                
                if (counter == -2)
                {
                    if (ht.horizontalSwitch.activeSelf == true)
                        ht.sbQH.Append(Time() + ",Button Pushed,START," + fps.FPS_Text() + "\n\n");
                    if (ht.verticalSwitch.activeSelf == true)
                        ht.sbQV.Append(Time() + ",Button Pushed,START," + fps.FPS_Text() + "\n\n");
                }
                if (counter != -2)
                {
                    keyboardQ.SetActive(true);
                    errorRateMenuQ.SetActive(false);
                    
                    cerQ.text = "Error Rate: ";
                    wpmQ.text = "Words Per Minute: ";
                    finalTime = TimeSpan.Zero;
                    bsQ.backspaceCounter = 0;
                }

                startButtonQ.SetActive(false);

                textQ.text = newSentenceList[counter + 2];

                if (counter < 0)
                {
                    if (ht.horizontalSwitch.activeSelf == true)
                        ht.sbQH.Append(Time() + ",Sentence to type (Practice)," + newSentenceList[counter + 2] + "," + fps.FPS_Text() + "\n");

                    if (ht.verticalSwitch.activeSelf == true)
                        ht.sbQV.Append(Time() + ",Sentence to type (Practice)," + newSentenceList[counter + 2] + "," + fps.FPS_Text() + "\n");
                    
                }
                else
                {
                    if (ht.horizontalSwitch.activeSelf == true)
                        ht.sbQH.Append(Time() + ",Sentence to type (" + (counter + 1) + "/12)," + newSentenceList[counter + 2] + "," + fps.FPS_Text() + "\n");

                    if (ht.verticalSwitch.activeSelf == true)
                        ht.sbQV.Append(Time() + ",Sentence to type (" + (counter + 1) + "/12)," + newSentenceList[counter + 2] + "," + fps.FPS_Text() + "\n");
                }

                if (counter < 0)
                    sentenceNumQ.text = ("Practice");
                else
                    sentenceNumQ.text = ((counter + 1) + "/12");
                
                counter = counter + 1;
                
                bsQ.Clear();
                Invoke("buttonSpawn", 0f); // was 2f
            }
        }
    }

    /**
     * Description : This method progresses from error menu to the sentence menu
     */
    public void errorRateNext()
    {
        // Calculate the statistics for both midair and qr keyboards
        
        bsF.Clear();
        bsF.isShiftOn = false;
        bsF.isCapsOn = false;
        
        bsQ.Clear();
        bsQ.isShiftOn = false;
        bsQ.isCapsOn = false;
        
        // nextButtonF.gameObject.SetActive(true);
        // nextButtonQ.gameObject.SetActive(false);
        // nextButtonFE.gameObject.SetActive(false);
        // nextButtonQE.gameObject.SetActive(false);

        if (freeScene.activeSelf == true && counter <= 12)
        {
            nextButtonF.SetActive(false);
            
            if (counter <= 0)
                sentenceNumFE.text = ("Practice");
            else
                sentenceNumFE.text = ((counter) + "/12");
            
            ht.sbF.Append(Time() + ",Sentence typed," + textTypeF.text.Substring(0, textTypeF.text.Length-1) + "," + fps.FPS_Text()+  "\n");
            
            if (check == true)
            {
                Debug.Log("TIMER END");
                timeEnd = DateTime.UtcNow;
                finalTime = timeEnd - timeStart;
                ht.sbF.Append(Time() + ",Time in Milliseconds," + ((long) finalTime.TotalMilliseconds) + "," + fps.FPS_Text() + "\n");
                check = false;
            }

            textFE.text = textF.text;
            textTypeFE.text = textTypeF.text;
            
            textTypeFE.text = textTypeFE.text.Remove(textTypeFE.text.Length - 1);

            double charErrorRate = computeCER(textF.text, textTypeF.text.Substring(0, textTypeF.text.Length-1));
            double wordsPerMin = 0.0;
            double backspaceOutput = -1;

            if (finalTime.TotalMilliseconds != 0 && textTypeFE.text != "")
            {
                wordsPerMin = computeWordsPerMinute(finalTime.TotalSeconds, textTypeF.text.Substring(0, textTypeF.text.Length-1));
                backspaceOutput = ((double) bsF.backspaceCounter / (double) textTypeFE.text.Length);
            }

            textTypeF.text = '_'.ToString();

            cerF.text = cerF.text + charErrorRate.ToString("F1") + "%";
            wpmF.text = wpmF.text + wordsPerMin.ToString("F1");
            
            if (counter > 0)
            {
                if (charErrorRate > maxCER)
                    maxCER = charErrorRate;
                if (charErrorRate < minCER)
                    minCER = charErrorRate;

                if (wordsPerMin > maxWPM)
                    maxWPM = wordsPerMin;
                if (wordsPerMin < minWPM)
                    minWPM = wordsPerMin;

                if (backspaceOutput != -1)
                {
                    if (backspaceOutput > maxBC)
                        maxBC = backspaceOutput;
                    if (backspaceOutput < minBC)
                        minBC = backspaceOutput;
                }


                averageErrorRate = averageErrorRate + charErrorRate;
                if (wordsPerMin > 0)
                {
                    averageWordsPerMinute = averageWordsPerMinute + wordsPerMin;
                    wpmCounter++;
                }

                if (backspaceOutput > -1)
                {
                    averageBackspaceOutput = averageBackspaceOutput + backspaceOutput;
                    backspaceOutputCounter++;
                }
            }

            ht.sbF.Append(Time() + ",Character Error Rate," + charErrorRate.ToString("F2") + "%," + fps.FPS_Text() + "\n");
            
            if (wordsPerMin > 0)
                ht.sbF.Append(Time() + ",Words Per Minute," + wordsPerMin.ToString("F2") + "," + fps.FPS_Text() + "\n");
            else
                ht.sbF.Append(Time() + ",Words Per Minute,ERROR WPM IS ZERO," + fps.FPS_Text() + "\n");

            if (textTypeFE.text != "")
                ht.sbF.Append(Time() + ",Backspace Per Output Character," + (backspaceOutput).ToString("F4") + "," + fps.FPS_Text() + "\n");
            else
                ht.sbF.Append(Time() + ",Backspace Per Output Character,ERROR NO SENTENCE TYPED," + fps.FPS_Text() + "\n");
            
            
            ht.sbF.Append(Time() + ",Button Pushed,NEXT," + fps.FPS_Text() + "\n\n");

            keyboardF.SetActive(false);
            errorRateMenuF.SetActive(true);

            Invoke("buttonSpawn", 2f); // was 1f
        }
        else if (qrScene.activeSelf == true && counter <= 12)
        {
            nextButtonQ.SetActive(false);

            if (counter <= 0)
                sentenceNumQE.text = ("Practice");
            else
                sentenceNumQE.text = ((counter) + "/12");
            
            if (ht.horizontalSwitch.activeSelf == true)
                ht.sbQH.Append(Time() + ",Sentence typed," + textTypeQ.text.Substring(0, textTypeQ.text.Length-1) + "," + fps.FPS_Text() + "\n");
            
            if (ht.verticalSwitch.activeSelf == true)
                ht.sbQV.Append(Time() + ",Sentence typed," + textTypeQ.text.Substring(0, textTypeQ.text.Length-1) + "," + fps.FPS_Text() + "\n");

            if (check == true)
            {
                Debug.Log("TIMER END");
                timeEnd = DateTime.UtcNow;
                finalTime = timeEnd - timeStart;
                
                if (ht.horizontalSwitch.activeSelf == true)
                    ht.sbQH.Append(Time() + ",Time in Milliseconds," + ((long) finalTime.TotalMilliseconds) + "," + fps.FPS_Text() + "\n");
                
                if (ht.verticalSwitch.activeSelf == true)
                    ht.sbQV.Append(Time() + ",Time in Milliseconds," + ((long) finalTime.TotalMilliseconds) + "," + fps.FPS_Text() + "\n");

                check = false;
            }

            textQE.text = textQ.text;
            textTypeQE.text = textTypeQ.text;
            
            textTypeQE.text = textTypeQE.text.Remove(textTypeQE.text.Length - 1);


            double charErrorRate = computeCER(textQ.text, textTypeQ.text.Substring(0, textTypeQ.text.Length-1));
            double wordsPerMin = 0.0;
            double backspaceOutput = -1;

            if (finalTime.TotalMilliseconds != 0 && textTypeQE.text != "")
            {
                wordsPerMin = computeWordsPerMinute(finalTime.TotalSeconds, textTypeQ.text.Substring(0, textTypeQ.text.Length-1));
                backspaceOutput = ((double) bsQ.backspaceCounter / (double) textTypeQE.text.Length);
            }

            textTypeQ.text = '_'.ToString();

            cerQ.text = cerQ.text + charErrorRate.ToString("F1") + "%";
            wpmQ.text = wpmQ.text + wordsPerMin.ToString("F1");

            if (counter > 0)
            {
                if (charErrorRate > maxCER)
                    maxCER = charErrorRate;
                if (charErrorRate < minCER)
                    minCER = charErrorRate;

                if (wordsPerMin > maxWPM)
                    maxWPM = wordsPerMin;
                if (wordsPerMin < minWPM)
                    minWPM = wordsPerMin;

                if (backspaceOutput != -1)
                {
                    if (backspaceOutput > maxBC)
                        maxBC = backspaceOutput;
                    if (backspaceOutput < minBC)
                        minBC = backspaceOutput;
                }


                averageErrorRate = averageErrorRate + charErrorRate;
                if (wordsPerMin > 0)
                {
                    averageWordsPerMinute = averageWordsPerMinute + wordsPerMin;
                    wpmCounter++;
                }
                if (backspaceOutput > -1)
                {
                    averageBackspaceOutput = averageBackspaceOutput + backspaceOutput;
                    backspaceOutputCounter++;
                }
            }

            if (ht.horizontalSwitch.activeSelf == true)
                ht.sbQH.Append(Time() + ",Character Error Rate," + charErrorRate.ToString("F2") + "%," + fps.FPS_Text() + "\n");
            
            if (ht.verticalSwitch.activeSelf == true)
                ht.sbQV.Append(Time() + ",Character Error Rate," + charErrorRate.ToString("F2") + "%," + fps.FPS_Text() + "\n");

            if (wordsPerMin > 0)
            {
                if (ht.horizontalSwitch.activeSelf == true)
                    ht.sbQH.Append(Time() + ",Words Per Minute," + wordsPerMin.ToString("F2") + "," + fps.FPS_Text() + "\n");
                
                if (ht.verticalSwitch.activeSelf == true)
                    ht.sbQV.Append(Time() + ",Words Per Minute," + wordsPerMin.ToString("F2") + "," + fps.FPS_Text() + "\n");
            }
            else
            {
                if (ht.horizontalSwitch.activeSelf == true)
                    ht.sbQH.Append(Time() + ",Words Per Minute,ERROR WPM IS ZERO," + fps.FPS_Text() + "\n");
                
                if (ht.verticalSwitch.activeSelf == true)
                    ht.sbQV.Append(Time() + ",Words Per Minute,ERROR WPM IS ZERO," + fps.FPS_Text() + "\n");
            }

            if (textTypeQE.text != "")
            {
                if (ht.horizontalSwitch.activeSelf == true)
                    ht.sbQH.Append(Time() + ",Backspace Per Output Character," + (backspaceOutput).ToString("F4") + "," + fps.FPS_Text() + "\n");
                
                if (ht.verticalSwitch.activeSelf == true)
                    ht.sbQV.Append(Time() + ",Backspace Per Output Character," + (backspaceOutput).ToString("F4") + "," + fps.FPS_Text() + "\n");
            }
            else
            {
                if (ht.horizontalSwitch.activeSelf == true)
                    ht.sbQH.Append(Time() + ",Backspace Per Output Character,ERROR NO SENTENCE TYPED," + fps.FPS_Text() + "\n");
                
                if (ht.verticalSwitch.activeSelf == true)
                    ht.sbQV.Append(Time() + ",Backspace Per Output Character,ERROR NO SENTENCE TYPED," + fps.FPS_Text() + "\n");
            }

            if (ht.horizontalSwitch.activeSelf == true)
                ht.sbQH.Append(Time() + ",Button Pushed,NEXT," + fps.FPS_Text() + "\n\n");

            if (ht.verticalSwitch.activeSelf == true)
                ht.sbQV.Append(Time() + ",Button Pushed,NEXT," + fps.FPS_Text() + "\n\n");

            keyboardQ.SetActive(false);
            errorRateMenuQ.SetActive(true);
            Invoke("buttonSpawn", 0f); // was 2f
        }
        
        // On final sentence print out average statistics
        if (counter == 12)
        {
            if (freeScene.activeSelf == true)
            {
                CancelInvoke("buttonSpawn");
                if (pageNum == 2)
                {
                    nextButtonFE.SetActive(false);
                    finishButtonF.SetActive(true);
                    
                    cerAF.gameObject.SetActive(true);
                    cerAF.text = cerAF.text + (averageErrorRate / counter).ToString("F1") + "%";
                    ht.sbF.Append(Time() + ",Average Character Error Rate," + (averageErrorRate / counter).ToString("F2") + "%," + fps.FPS_Text() + "\n");
                    ht.sbF.Append(Time() + ",Maximum Character Error Rate," + (maxCER).ToString("F2") + "%," + fps.FPS_Text() + "\n");
                    ht.sbF.Append(Time() + ",Minimum Character Error Rate," + (minCER).ToString("F2") + "%," + fps.FPS_Text() + "\n\n)");

                    wpmAF.gameObject.SetActive(true);
                    wpmAF.text = wpmAF.text + (averageWordsPerMinute / wpmCounter).ToString("F1");
                    ht.sbF.Append(Time() + ",Average Words Per Minute," + (averageWordsPerMinute / wpmCounter).ToString("F2") + "," + fps.FPS_Text() + "\n");
                    ht.sbF.Append(Time() + ",Maximum Words Per Minute," + (maxWPM).ToString("F2") + "," + fps.FPS_Text() + "\n");
                    ht.sbF.Append(Time() + ",Minimum Words Per Minute," + (minWPM).ToString("F2") + "," + fps.FPS_Text() + "\n\n");

                    ht.sbF.Append(Time() + ",Average Backspace Per Output Character," + ((averageBackspaceOutput / backspaceOutputCounter)).ToString("F4") + "," + fps.FPS_Text() + "\n");
                    ht.sbF.Append(Time() + ",Maximum Backspace Per Output Character," + (maxBC).ToString("F4") + "," + fps.FPS_Text() + "\n");
                    ht.sbF.Append(Time() + ",Minimum Backspace Per Output Character," + (minBC).ToString("F4") + "," + fps.FPS_Text() + "\n\n");
                }
                else
                {
                    nextButtonFE.SetActive(false);
                    nextScenarioButtonF.SetActive(true);

                    cerAF.gameObject.SetActive(true);
                    cerAF.text = cerAF.text + (averageErrorRate / counter).ToString("F1") + "%";
                    ht.sbF.Append(Time() + ",Average Character Error Rate," + (averageErrorRate / counter).ToString("F2") + "%," + fps.FPS_Text() + "\n");
                    ht.sbF.Append(Time() + ",Maximum Character Error Rate," + (maxCER).ToString("F2") + "%," + fps.FPS_Text() + "\n");
                    ht.sbF.Append(Time() + ",Minimum Character Error Rate," + (minCER).ToString("F2") + "%," + fps.FPS_Text() + "\n\n");
                    
                    wpmAF.gameObject.SetActive(true);
                    wpmAF.text = wpmAF.text + (averageWordsPerMinute / wpmCounter).ToString("F1");
                    ht.sbF.Append(Time() + ",Average Words Per Minute," + (averageWordsPerMinute / wpmCounter).ToString("F2") + "," + fps.FPS_Text() + "\n");
                    ht.sbF.Append(Time() + ",Maximum Words Per Minute," + (maxWPM).ToString("F2") + "," + fps.FPS_Text() + "\n");
                    ht.sbF.Append(Time() + ",Minimum Words Per Minute," + (minWPM).ToString("F2") + "," + fps.FPS_Text() + "\n\n");
                    
                    ht.sbF.Append(Time() + ",Average Backspace Per Output Character," + ((averageBackspaceOutput / backspaceOutputCounter)).ToString("F4") + "," + fps.FPS_Text() + "\n");
                    ht.sbF.Append(Time() + ",Maximum Backspace Per Output Character," + (maxBC).ToString("F4") + "," + fps.FPS_Text() + "\n");
                    ht.sbF.Append(Time() + ",Minimum Backspace Per Output Character," + (minBC).ToString("F4") + "," + fps.FPS_Text() + "\n\n");
                }
            }
            else
            {
                CancelInvoke("buttonSpawn");
                if (pageNum == 2)
                {
                    nextButtonQE.SetActive(false);
                    finishButtonQ.SetActive(true);
                    
                    cerAQ.gameObject.SetActive(true);
                    cerAQ.text = cerAQ.text + (averageErrorRate / counter).ToString("F1") + "%";

                    if (ht.horizontalSwitch.activeSelf == true)
                    {
                        ht.sbQH.Append(Time() + ",Average Character Error Rate," + (averageErrorRate / counter).ToString("F2") + "%," + fps.FPS_Text() + "\n");
                        ht.sbQH.Append(Time() + ",Maximum Character Error Rate," + (maxCER).ToString("F2") + "%," + fps.FPS_Text() + "\n");
                        ht.sbQH.Append(Time() + ",Minimum Character Error Rate," + (minCER).ToString("F2") + "%," + fps.FPS_Text() + "\n\n");
                    }
                    
                    if (ht.verticalSwitch.activeSelf == true)
                    {
                        ht.sbQV.Append(Time() + ",Average Character Error Rate," + (averageErrorRate / counter).ToString("F2") + "%," + fps.FPS_Text() + "\n");
                        ht.sbQV.Append(Time() + ",Maximum Character Error Rate," + (maxCER).ToString("F2") + "%," + fps.FPS_Text() + "\n");
                        ht.sbQV.Append(Time() + ",Minimum Character Error Rate," + (minCER).ToString("F2") + "%," + fps.FPS_Text() + "\n\n");
                    }

                    wpmAQ.gameObject.SetActive(true);
                    wpmAQ.text = wpmAQ.text + (averageWordsPerMinute / wpmCounter).ToString("F1");

                    if (ht.horizontalSwitch.activeSelf == true)
                    {
                        ht.sbQH.Append(Time() + ",Average Words Per Minute," + (averageWordsPerMinute / wpmCounter).ToString("F2") + "," + fps.FPS_Text() + "\n");
                        ht.sbQH.Append(Time() + ",Maximum Words Per Minute," + (maxWPM).ToString("F2") + "," + fps.FPS_Text() + "\n");
                        ht.sbQH.Append(Time() + ",Minimum Words Per Minute," + (minWPM).ToString("F2") + "," + fps.FPS_Text() + "\n\n");

                        ht.sbQH.Append(Time() + ",Average Backspace Per Output Character," + ((averageBackspaceOutput / backspaceOutputCounter)).ToString("F4") + "," + fps.FPS_Text() + "\n");
                        ht.sbQH.Append(Time() + ",Maximum Backspace Per Output Character," + (maxBC).ToString("F4") + "," + fps.FPS_Text() + "\n");
                        ht.sbQH.Append(Time() + ",Minimum Backspace Per Output Character," + (minBC).ToString("F4") + "," + fps.FPS_Text() + "\n\n");
                    }
                    
                    if (ht.verticalSwitch.activeSelf == true)
                    {
                        ht.sbQV.Append(Time() + ",Average Words Per Minute," + (averageWordsPerMinute / wpmCounter).ToString("F2") + "," + fps.FPS_Text() + "\n");
                        ht.sbQV.Append(Time() + ",Maximum Words Per Minute," + (maxWPM).ToString("F2") + "," + fps.FPS_Text() + "\n");
                        ht.sbQV.Append(Time() + ",Minimum Words Per Minute," + (minWPM).ToString("F2") + "," + fps.FPS_Text() + "\n\n");

                        ht.sbQV.Append(Time() + ",Average Backspace Per Output Character," + ((averageBackspaceOutput / backspaceOutputCounter)).ToString("F4") + "," + fps.FPS_Text() + "\n");
                        ht.sbQV.Append(Time() + ",Maximum Backspace Per Output Character," + (maxBC).ToString("F4") + "," + fps.FPS_Text() + "\n");
                        ht.sbQV.Append(Time() + ",Minimum Backspace Per Output Character," + (minBC).ToString("F4") + "," + fps.FPS_Text() + "\n\n");
                    }
                }
                else
                {
                    nextButtonQE.SetActive(false);
                    nextScenarioButtonQ.SetActive(true);
                    
                    cerAQ.gameObject.SetActive(true);
                    cerAQ.text = cerAQ.text + (averageErrorRate / counter).ToString("F1") + "%";

                    if (ht.horizontalSwitch.activeSelf == true)
                    {
                        ht.sbQH.Append(Time() + ",Average Character Error Rate," + (averageErrorRate / counter).ToString("F2") + "%," + fps.FPS_Text() + "\n");
                        ht.sbQH.Append(Time() + ",Maximum Character Error Rate," + (maxCER).ToString("F2") + "%," + fps.FPS_Text() + "\n");
                        ht.sbQH.Append(Time() + ",Minimum Character Error Rate," + (minCER).ToString("F2") + "%," + fps.FPS_Text() + "\n\n");
                    }
                    
                    if (ht.verticalSwitch.activeSelf == true)
                    {
                        ht.sbQV.Append(Time() + ",Average Character Error Rate," + (averageErrorRate / counter).ToString("F2") + "%," + fps.FPS_Text() + "\n");
                        ht.sbQV.Append(Time() + ",Maximum Character Error Rate," + (maxCER).ToString("F2") + "%," + fps.FPS_Text() + "\n");
                        ht.sbQV.Append(Time() + ",Minimum Character Error Rate," + (minCER).ToString("F2") + "%," + fps.FPS_Text() + "\n\n");
                    }

                    wpmAQ.gameObject.SetActive(true);
                    wpmAQ.text = wpmAQ.text + (averageWordsPerMinute / wpmCounter).ToString("F1");

                    if (ht.horizontalSwitch.activeSelf == true)
                    {
                        ht.sbQH.Append(Time() + ",Average Words Per Minute," + (averageWordsPerMinute / wpmCounter).ToString("F2") + "," + fps.FPS_Text() + "\n");
                        ht.sbQH.Append(Time() + ",Maximum Words Per Minute," + (maxWPM).ToString("F2") + "," + fps.FPS_Text() + "\n");
                        ht.sbQH.Append(Time() + ",Minimum Words Per Minute," + (minWPM).ToString("F2") + "," + fps.FPS_Text() + "\n\n");

                        ht.sbQH.Append(Time() + ",Average Backspace Per Output Character," + ((averageBackspaceOutput / backspaceOutputCounter)).ToString("F4") + "," + fps.FPS_Text() + "\n");
                        ht.sbQH.Append(Time() + ",Maximum Backspace Per Output Character," + (maxBC).ToString("F4") + "," + fps.FPS_Text() + "\n");
                        ht.sbQH.Append(Time() + ",Minimum Backspace Per Output Character," + (minBC).ToString("F4") + "," + fps.FPS_Text() + "\n\n");
                    }
                    
                    if (ht.verticalSwitch.activeSelf == true)
                    {
                        ht.sbQV.Append(Time() + ",Average Words Per Minute," + (averageWordsPerMinute / wpmCounter).ToString("F2") + "," + fps.FPS_Text() + "\n");
                        ht.sbQV.Append(Time() + ",Maximum Words Per Minute," + (maxWPM).ToString("F2") + "," + fps.FPS_Text() + "\n");
                        ht.sbQV.Append(Time() + ",Minimum Words Per Minute," + (minWPM).ToString("F2") + "," + fps.FPS_Text() + "\n\n");

                        ht.sbQV.Append(Time() + ",Average Backspace Per Output Character," + ((averageBackspaceOutput / backspaceOutputCounter)).ToString("F4") + "," + fps.FPS_Text() + "\n");
                        ht.sbQV.Append(Time() + ",Maximum Backspace Per Output Character," + (maxBC).ToString("F4") + "," + fps.FPS_Text() + "\n");
                        ht.sbQV.Append(Time() + ",Minimum Backspace Per Output Character," + (minBC).ToString("F4") + "," + fps.FPS_Text() + "\n\n");
                    }
                }
            }
            pageNum++;
        }
    }
    
    /**
     * Description : This method moves from one condition to the other
     */
    public void nextScenario()
    {
        // Reset averages to zero
        averageErrorRate = 0;
        averageWordsPerMinute = 0;
        averageBackspaceOutput = 0;
        
        // Set mins and maxs to the highest and lowest values
        maxCER = Int32.MinValue;
        minCER = Int32.MaxValue;
        maxWPM = Int32.MinValue;
        minWPM = Int32.MaxValue;
        maxBC = Int32.MinValue;
        minBC = Int32.MaxValue;
        
        cerAF.gameObject.SetActive(false);
        cerAQ.gameObject.SetActive(false);
        wpmAF.gameObject.SetActive(false);
        wpmAQ.gameObject.SetActive(false);
        
        // Enable and disable some scenes 
        if (odd_even_num % 6 == 0)
        {
            WriteWords();

            qrScene.SetActive(false);
            freeScene.SetActive(false);
            if (pageNum == 1)
                qrPreScene.SetActive(true);
            else if (pageNum == 2)
                freePreScene.SetActive(true);
            pst.Invoker();
            
            nextScenarioButtonQ.SetActive(false);
            errorRateMenuQ.SetActive(false);
            startButtonQ.SetActive(true);
            
            ResetQText();

            // shuffle(newSentenceList);
            for (int i = 0; i < 15; i++)
                newSentenceList.RemoveAt(i);
            
            counter = -2;
            backspaceOutputCounter = 0;
            
            bsF.Clear();
        }
        else if (odd_even_num % 6 == 1)
        {
            WriteWords();
            
            qrScene.SetActive(false);
            freeScene.SetActive(false);
            if (pageNum == 1)
                freePreScene.SetActive(true);
            else if (pageNum == 2)
                qrPreScene.SetActive(true);
            pst.Invoker();
            
            nextScenarioButtonQ.SetActive(false);
            errorRateMenuQ.SetActive(false);
            startButtonQ.SetActive(true);
            
            ResetQText();
            
            shuffle(newSentenceList);
            
            counter = -2;
            backspaceOutputCounter = 0;

            bsQ.Clear();
        }
        else if (odd_even_num % 6 == 2)
        {
            WriteWords();
            
            qrScene.SetActive(false);
            freeScene.SetActive(false);
            if (pageNum == 1)
                qrPreScene.SetActive(true);
            else if (pageNum == 2)
                qrPreScene.SetActive(true);
            pst.Invoker();
            
            nextScenarioButtonQ.SetActive(false);
            errorRateMenuQ.SetActive(false);
            startButtonQ.SetActive(true);
            
            ResetQText();
            
            shuffle(newSentenceList);
            
            counter = -2;
            backspaceOutputCounter = 0;

            bsQ.Clear();
        }
        else if (odd_even_num % 6 == 3)
        {
            WriteWords();
            
            qrScene.SetActive(false);
            freeScene.SetActive(false);
            if (pageNum == 1)
                qrPreScene.SetActive(true);
            else if (pageNum == 2)
                qrPreScene.SetActive(true);
            pst.Invoker();
            
            nextScenarioButtonQ.SetActive(false);
            errorRateMenuQ.SetActive(false);
            startButtonQ.SetActive(true);
            
            ResetQText();
            
            shuffle(newSentenceList);
            
            counter = -2;
            backspaceOutputCounter = 0;

            bsQ.Clear();
        }
        else if (odd_even_num % 6 == 4)
        {
            WriteWords();
            
            qrScene.SetActive(false);
            freeScene.SetActive(false);
            if (pageNum == 1)
                freePreScene.SetActive(true);
            else if (pageNum == 2)
                qrPreScene.SetActive(true);
            pst.Invoker();
            
            nextScenarioButtonQ.SetActive(false);
            errorRateMenuQ.SetActive(false);
            startButtonQ.SetActive(true);
            
            ResetQText();
            
            shuffle(newSentenceList);
            
            counter = -2;
            backspaceOutputCounter = 0;

            bsQ.Clear();
        }
        else if (odd_even_num % 6 == 5)
        {
            WriteWords();
            
            qrScene.SetActive(false);
            freeScene.SetActive(false);
            if (pageNum == 1)
                qrPreScene.SetActive(true);
            else if (pageNum == 2)
                freePreScene.SetActive(true);
            pst.Invoker();
            
            nextScenarioButtonQ.SetActive(false);
            errorRateMenuQ.SetActive(false);
            startButtonQ.SetActive(true);

            ResetQText();
            
            shuffle(newSentenceList);
            
            counter = -2;
            backspaceOutputCounter = 0;

            bsQ.Clear();
        }

        qrtc.ResetTracking();
        qrrl.resetQRPosition();
    }

    /**
     * Description : This method finishes and wraps up the scene
     */
    public void finish()
    {
        // Reset averages to zero
        averageErrorRate = 0;
        averageWordsPerMinute = 0;
        averageBackspaceOutput = 0;
        
        // Set mins and maxs to the highest and lowest values
        maxCER = Int32.MinValue;
        minCER = Int32.MaxValue;
        maxWPM = Int32.MinValue;
        minWPM = Int32.MaxValue;
        maxBC = Int32.MinValue;
        minBC = Int32.MaxValue;
        
        cerAF.gameObject.SetActive(false);
        cerAQ.gameObject.SetActive(false);
        wpmAF.gameObject.SetActive(false);
        wpmAQ.gameObject.SetActive(false);
        
        // Finish scene
        if (freeScene.activeSelf == true) 
        {
            ht.sbF.Append(Time() + ",Button Pushed,FINISH," + fps.FPS_Text() + "\n\n");
            
            ht.writeOut();
            bsF.Clear();
            
            freeHolder.SetActive(false);
            whatToDoObjectF.SetActive(false);
            allDoneObjectF.SetActive(true);
        }
        else
        {
            if (ht.horizontalSwitch.activeSelf == true)
                ht.sbQH.Append(Time() + ",Button Pushed,FINISH," + fps.FPS_Text() + "\n\n");
            
            if (ht.verticalSwitch.activeSelf == true)
                ht.sbQV.Append(Time() + ",Button Pushed,FINISH," + fps.FPS_Text() + "\n\n");

            ht.writeOut();
            bsQ.Clear();
            
            qrHolder.SetActive(false);
            whatToDoObjectQ.SetActive(false);
            allDoneObjectQ.SetActive(true);
        }
        
        // qrScene.SetActive(false);
        // freeScene.SetActive(false);
        menuScene.SetActive(false);
        
        counter = -2;
        backspaceOutputCounter = 0;
        pageNum = 0;
        
        Invoke("applicationQuit", 5f);
    }

    /**
     * Description : This method starts the timer for recording the length of the sentence to be typed
     */
    public void Update()
    {
        if (check == false && (startButtonF.activeSelf == false || startButtonQ.activeSelf == false))
        {
            if (freeScene.activeSelf == true && errorRateMenuF.activeSelf == false)
            {
                string sen;
                if (counter == -2)
                    sen = newSentenceList[counter + 2];
                else
                    sen = newSentenceList[counter + 1];
                
                char letter = sen[0];
                if (bsF.key == "LSHIFT   " || bsF.key == "RSHIFT   " || bsF.key == "CAPS     " || bsF.key == ((char) (letter+32) + "        ") || bsF.key == ((char) (letter) + "        "))
                {
                    Debug.Log("TIMER START");
                    timeStart = DateTime.UtcNow;
                    check = true;
                }
            }
            else if (qrScene.activeSelf == true && errorRateMenuQ.activeSelf == false)
            {
                string sen;
                if (counter == -2)
                    sen = newSentenceList[counter + 2];
                else
                    sen = newSentenceList[counter + 1];
                
                char letter = sen[0];
                if (bsQ.key == "LSHIFT   " || bsQ.key == "RSHIFT   " || bsQ.key == "CAPS     " || bsQ.key == ((char) (letter+32) + "        ") || bsQ.key == ((char) (letter) + "        "))
                {
                    Debug.Log("TIMER START");
                    timeStart = DateTime.UtcNow;
                    check = true;
                }
            }
        }

        // if (freeScene.activeSelf == true && keyboardF.activeSelf == true)
        // {
        //     if (textTypeF.text.Length-1 == textF.text.Length && textTypeF.text[textTypeF.text.Length - 2] == textF.text[textF.text.Length - 1])
        //     {
        //         Invoke("buttonSpawn", 2f);
        //     }
        // }
        //
        // if (qrScene.activeSelf == true && keyboardQ.activeSelf == true)
        // {
        //     if (textTypeQ.text.Length-1 == textQ.text.Length && textTypeQ.text[textTypeQ.text.Length - 2] == textQ.text[textQ.text.Length - 1])
        //     {
        //         Invoke("buttonSpawn", 2f);
        //     }
        // }
    }

    /**
     * Description : This method quits the application
     */
    public void applicationQuit()
    {
        Application.Quit();
        Debug.Log("Application is quitting!");
    }
    
    /**
     * Description : This method spawns the next sentence button in 
     */
    public void buttonSpawn()
    {
        if (freeScene.activeSelf == true)
        {
            if (errorRateMenuF.activeSelf == true)
                nextButtonFE.SetActive(true);
            else if (keyboardF.activeSelf == true)
                nextButtonF.SetActive(true);
        }
        else if (qrScene.activeSelf == true)
        {
            if (errorRateMenuQ.activeSelf == true)
                nextButtonQE.SetActive(true);
            else if (keyboardQ.activeSelf == true)
                nextButtonQ.SetActive(true);
        }
    }

    /**
     * Description : This method starts the beginning sentences for the midair keyboard
     */
    private void StartOutWordsF()
    {
        ht.sbF.Append(Time() + ",Condition,MID-AIR FIXED," + fps.FPS_Text() + "\n");
        ht.sbF.Append(Time() + ",Participant ID," + odd_even_num + "," + fps.FPS_Text() + "\n");
        ht.sbF.Append(Time() + ",Date," + DateTime.Now.ToString("d") + "," + fps.FPS_Text() + "\n");
        ht.sbF.Append(Time() + ",Time," + DateTime.Now.ToString("t") + "," + fps.FPS_Text() + "\n\n");
        ht.sbF.Append(Time() + ",Button Pushed,BEGIN," + fps.FPS_Text() + "\n");
    }
    
    /**
     * Description : This method starts the beginning sentences for the horizontal keyboard
     */
    private void StartOutWordsQH()
    {
        ht.sbQH.Append(Time() + ",Condition,HORIZONTAL QR," + fps.FPS_Text() + "\n");
        ht.sbQH.Append(Time() + ",Participant ID," + odd_even_num + "," + fps.FPS_Text() + "\n");
        ht.sbQH.Append(Time() + ",Date," + DateTime.Now.ToString("d") + "," + fps.FPS_Text() + "\n");
        ht.sbQH.Append(Time() + ",Time," + DateTime.Now.ToString("t") + "," + fps.FPS_Text() + "\n\n");
        ht.sbQH.Append(Time() + ",Button Pushed,BEGIN," + fps.FPS_Text() + "\n");
    }
    
    /**
     * Description : This method starts the beginning sentences for the vertical keyboard
     */
    private void StartOutWordsQV()
    {
        ht.sbQV.Append(Time() + ",Condition,VERTICAL QR," + fps.FPS_Text() + "\n");
        ht.sbQV.Append(Time() + ",Participant ID," + odd_even_num + "," + fps.FPS_Text() + "\n");
        ht.sbQV.Append(Time() + ",Date," + DateTime.Now.ToString("d") + "," + fps.FPS_Text() + "\n");
        ht.sbQV.Append(Time() + ",Time," + DateTime.Now.ToString("t") + "," + fps.FPS_Text() + "\n\n");
        ht.sbQV.Append(Time() + ",Button Pushed,BEGIN," + fps.FPS_Text() + "\n");
    }
    
    /**
     * Description : This method resets the qr related texts
     */
    private void ResetQText()
    {
        textQ.text = "Push START to begin!";
        sentenceNumQ.text = "/12";
        cerQ.text = "Error Rate: ";
        wpmQ.text = "Error Rate: ";
        cerAQ.text = "Average Error Rate: ";
        wpmAQ.text = "Average Words Per Minute: ";

        ht.horizontalSwitch.SetActive(false);
        ht.verticalSwitch.SetActive(false);
    }

    /**
     * Description : This method writes out the next scenario words
     */
    private void WriteWords()
    {
        if (ht.freeSwitch.activeSelf == true)
        {
            ht.sbF.Append(Time() + ",Button Pushed,NEXT SCENARIO," + fps.FPS_Text() + "\n\n");
            ht.writeOut();
        }
        if (ht.horizontalSwitch.activeSelf == true)
        {
            ht.sbQH.Append(Time() + ",Button Pushed,NEXT SCENARIO," + fps.FPS_Text() + "\n\n");
            ht.writeOut();
        }
        if (ht.verticalSwitch.activeSelf == true)
        {
            ht.sbQV.Append(Time() + ",Button Pushed,NEXT SCENARIO," + fps.FPS_Text() + "\n\n");
            ht.writeOut();
        }
    }
    
    /**
     * Description : This method goes from the menu to qr scene
     */
    private void MenuToQR()
    {
        menuScene.SetActive(false);
        qrPreScene.SetActive(true);
    }
    
    /**
     * Description : This method goes from the menu to midair scene
     */
    private void MenuToFree()
    {
        menuScene.SetActive(false);
        freePreScene.SetActive(true);
    }
    
    /**
     * Description : This prints back the time
     */
    public double Time()
    {
        return TimeSpan.FromMilliseconds(DateTimeOffset.Now.ToUnixTimeMilliseconds()).TotalSeconds;
    }
    
    
    /**
     * Description             : This method computes the character error rate
     *
     * Parameter - reference   : This is the reference string
     * Parameter - recognition : This is the recognition string
     */
    public static double computeCER(String reference, String recognition)
    {
        if (recognition.EndsWith(" ") == true)
            recognition = recognition.Remove(recognition.Length - 1, 1);
        
        int distance = computeEditDistance(reference, recognition);
        return (distance / (double) reference.Length) * 100.0;
    }

    /**
     * Description : This method computes how many letters are off between the two texts
     */
    public static int computeEditDistance(String str1, String str2)
    {
        int[,] distance = new int[str1.Length + 1, str2.Length + 1]; // might not need +1
        for (int i = 0; i <= str1.Length; i++)
            distance[i, 0] = i;
        for (int j = 1; j <= str2.Length; j++)
            distance[0, j] = j;
        
        for (int i = 1; i <= str1.Length; i++)
            for (int j = 1; j <= str2.Length; j++)
                distance[i, j] = minimum(
                    distance[i - 1, j] + 1,
                    distance[i, j - 1] + 1,
                    distance[i - 1, j - 1]
                    + ((str1[i - 1] == str2[j - 1]) ? 0 : 1));

        return distance[str1.Length, str2.Length];
    }

    /**
     * Description : This method finds the smallest difference in text
     */
    public static int minimum(int a, int b, int c)
    {
        return Math.Min(Math.Min(a, b), c);
    }
    
    /**
     * Description : This method computes the words per minute
     */
    public static double computeWordsPerMinute(double timeInSeconds, String text)
    {
        double words = (text.Length - 1) / 5.0;
        double minutes = timeInSeconds / 60.0;
        return words / minutes;
    }
}
