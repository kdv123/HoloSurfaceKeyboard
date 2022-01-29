using TMPro;
using UnityEngine;

public class preSceneTimers : MonoBehaviour
{
    public TextMeshPro timerNumberF;
    public TextMeshPro timerNumberQH;
    public TextMeshPro timerNumberQV;
    
    public GameObject horizontalBackplate;
    public GameObject verticalBackplate;
    public GameObject freeBackplate;
    
    public GameObject horizontalCube;
    public GameObject verticalCube;
    public GameObject freeCube;
    
    public GameObject twoMinPanelQRH;
    public GameObject twoMinPanelQRV;
    public GameObject twoMinPanelFree;

    public GameObject buttonQH;
    public GameObject buttonQV;
    public GameObject buttonFree;
    
    public sentenceScript ss;
    public handTracker ht;
    
    public AudioSource audioSource;

    private bool timerActive = false;
    private bool timerRepeat = false;
    private float timerForSound = 120f;
    private float timerForRepeatSound = 10f;
    
    public void StartUp()
    {
        PosRotSet();
        InvokeRepeating("Timer", 0f, 1f);
    }

    public void StartUpS()
    {
        PosRotSet();
        InvokeRepeating("TimerS", 0f, 1f);
    }

    public void Invoker()
    {
        timerNumberF.text = 11.ToString();
        timerNumberQH.text = 11.ToString();
        timerNumberQV.text = 11.ToString();
        
        verticalBackplate.SetActive(false);
        horizontalBackplate.SetActive(false);
        freeBackplate.SetActive(false);
        
        PosRotSet();
        TwoMinTimer();
        
        //InvokeRepeating("Timer", 0f, 1f);
    }

    public void Timer()
    {
        if (ss.pageNum == 0)
        {
            if (ss.odd_even_num % 6 == 0)
            {
                HorizontalSpawn1();
            }
            else if (ss.odd_even_num % 6 == 1)
            {
                HorizontalSpawn1();
            }
            else if (ss.odd_even_num % 6 == 2)
            {
                FreeSpawn1();
            }
            else if (ss.odd_even_num % 6 == 3)
            {
                FreeSpawn1();
            }
            else if (ss.odd_even_num % 6 == 4)
            {
                VerticalSpawn1();
            }
            else if (ss.odd_even_num % 6 == 5)
            {
                VerticalSpawn1();
            }
        }
        else if (ss.pageNum == 1)
        {
            if (ss.odd_even_num % 6 == 0)
            {
                VerticalSpawn2();
            }
            else if (ss.odd_even_num % 6 == 1)
            {
                FreeSpawn2();
            }
            else if (ss.odd_even_num % 6 == 2)
            {
                VerticalSpawn3();
            }
            else if (ss.odd_even_num % 6 == 3)
            {
                HorizontalSpawn2();
            }
            else if (ss.odd_even_num % 6 == 4)
            {
                FreeSpawn3();
            }
            else if (ss.odd_even_num % 6 == 5)
            {
                HorizontalSpawn3();
            }
        }
        else if (ss.pageNum == 2)
        {
            if (ss.odd_even_num % 6 == 0)
            {
                FreeSpawn3();
            }
            else if (ss.odd_even_num % 6 == 1)
            {
                VerticalSpawn3();
            }
            else if (ss.odd_even_num % 6 == 2)
            {
                HorizontalSpawn3();
            }
            else if (ss.odd_even_num % 6 == 3)
            {
                VerticalSpawn2();
            }
            else if (ss.odd_even_num % 6 == 4)
            {
                HorizontalSpawn2();
            }
            else if (ss.odd_even_num % 6 == 5)
            {
                FreeSpawn2();
            }
        }
    }

    public void TimerS()
    {
        if (ht.horizontalSwitch.activeSelf == true)
        {
            HorizontalSpawn1();
        }
        
        if (ht.verticalSwitch.activeSelf == true)
        {
            VerticalSpawn1();
        }
        
        if (ht.freeSwitch.activeSelf == true)
        {
            FreeSpawn1();
        }
    }

    public void PosRotSet()
    {
        float cameraAngleY = ss.camera.transform.eulerAngles.y;

        Vector3 cameraPosition = ss.camera.transform.position;
        Vector3 cameraPositionForward = ss.camera.transform.forward;

        Vector3 horizontalCubePosition = horizontalCube.transform.position;
        horizontalCube.transform.eulerAngles = new Vector3(0, cameraAngleY, 0);
        horizontalCubePosition = cameraPosition + (cameraPositionForward * 0.65f);
        horizontalCube.transform.position = new Vector3(horizontalCubePosition.x, cameraPosition.y, horizontalCubePosition.z);

        Vector3 verticalCubePosition = verticalCube.transform.position;
        verticalCube.transform.eulerAngles = new Vector3(0, cameraAngleY, 0);
        verticalCubePosition = cameraPosition + (cameraPositionForward * 0.65f);
        verticalCube.transform.position = new Vector3(verticalCubePosition.x, cameraPosition.y, verticalCubePosition.z);

        Vector3 freeCubePosition = freeCube.transform.position;
        freeCube.transform.eulerAngles = new Vector3(0, cameraAngleY, 0);
        freeCubePosition = cameraPosition + (cameraPositionForward * 0.65f);
        freeCube.transform.position = new Vector3(freeCubePosition.x, cameraPosition.y, freeCubePosition.z);

        Vector3 freeScenePosition = ss.freeScene.transform.position;
        ss.freeScene.transform.eulerAngles = new Vector3(0, cameraAngleY, 0);
        freeScenePosition = cameraPosition + (cameraPositionForward * 0.65f);
        ss.freeScene.transform.position = new Vector3(freeScenePosition.x, cameraPosition.y, freeScenePosition.z);


        Vector3 qrScenePosition = ss.qrScene.transform.position;
        ss.qrScene.transform.eulerAngles = new Vector3(0, cameraAngleY, 0);
        qrScenePosition = cameraPosition + (cameraPositionForward * 0.65f);
        ss.qrScene.transform.position = new Vector3(qrScenePosition.x, cameraPosition.y, qrScenePosition.z);
    }

    private void HorizontalSpawn1()
    {
        horizontalBackplate.SetActive(true);
        TextMeshPro textMeshPro = ss.whatToDoObjectQ.GetComponentInChildren<TextMeshPro>();
        textMeshPro.text = "Look at table QR Code";

        if (int.Parse(timerNumberQH.text) > 0)
            timerNumberQH.text = (int.Parse(timerNumberQH.text) - 1).ToString();
        else if (int.Parse(timerNumberQH.text) == 0)
        {
            PosRotSet();
            CancelInvoke();
            ss.qrScene.SetActive(true);
            ss.qrPreScene.SetActive(false);
            horizontalBackplate.SetActive(false);
            ht.horizontalSwitch.gameObject.SetActive(true);
        }
    }
    private void HorizontalSpawn2()
    {
        horizontalBackplate.SetActive(true);
        TextMeshPro textMeshPro = ss.whatToDoObjectQ.GetComponentInChildren<TextMeshPro>();
        textMeshPro.text = "Look at table QR Code";

        if (int.Parse(timerNumberQH.text) > 0)
            timerNumberQH.text = (int.Parse(timerNumberQH.text) - 1).ToString();
        else if (int.Parse(timerNumberQH.text) == 0)
        {
            PosRotSet();
            CancelInvoke();
            ss.qrScene.SetActive(true);
            ss.qrPreScene.SetActive(false);
            horizontalBackplate.SetActive(false);
            ht.freeSwitch.gameObject.SetActive(false);
            ht.horizontalSwitch.gameObject.SetActive(true);
        }
    }
    private void HorizontalSpawn3()
    {
        horizontalBackplate.SetActive(true);
        TextMeshPro textMeshPro = ss.whatToDoObjectQ.GetComponentInChildren<TextMeshPro>();
        textMeshPro.text = "Look at table QR Code";
                
        if (int.Parse(timerNumberQH.text) > 0)
            timerNumberQH.text = (int.Parse(timerNumberQH.text) - 1).ToString();
        else if (int.Parse(timerNumberQH.text) == 0)
        {
            PosRotSet();
            CancelInvoke();
            ss.qrScene.SetActive(true);
            ss.qrPreScene.SetActive(false);
            horizontalBackplate.SetActive(false);
            ht.verticalSwitch.gameObject.SetActive(false);
            ht.horizontalSwitch.gameObject.SetActive(true);
        }
    }

    
    private void VerticalSpawn1()
    {
        verticalBackplate.SetActive(true);
        TextMeshPro textMeshPro = ss.whatToDoObjectQ.GetComponentInChildren<TextMeshPro>();
        textMeshPro.text = "Look at wall QR Code";

        if (int.Parse(timerNumberQV.text) > 0)
            timerNumberQV.text = (int.Parse(timerNumberQV.text) - 1).ToString();
        else if (int.Parse(timerNumberQV.text) == 0)
        {
            PosRotSet();
            CancelInvoke();
            ss.qrScene.SetActive(true);
            ss.qrPreScene.SetActive(false);
            verticalBackplate.SetActive(false);
            ht.verticalSwitch.gameObject.SetActive(true);
        }
    }
    private void VerticalSpawn2()
    {
        verticalBackplate.SetActive(true);
        TextMeshPro textMeshPro = ss.whatToDoObjectQ.GetComponentInChildren<TextMeshPro>();
        textMeshPro.text = "Look at wall QR Code";

        if (int.Parse(timerNumberQV.text) > 0)
            timerNumberQV.text = (int.Parse(timerNumberQV.text) - 1).ToString();
        else if (int.Parse(timerNumberQV.text) == 0)
        {
            PosRotSet();
            CancelInvoke();
            ss.qrScene.SetActive(true);
            ss.qrPreScene.SetActive(false);
            verticalBackplate.SetActive(false);
            ht.horizontalSwitch.gameObject.SetActive(false);
            ht.verticalSwitch.gameObject.SetActive(true);
        }
    }
    private void VerticalSpawn3()
    {
        verticalBackplate.SetActive(true);
        TextMeshPro textMeshPro = ss.whatToDoObjectQ.GetComponentInChildren<TextMeshPro>();
        textMeshPro.text = "Look at wall QR Code";

        if (int.Parse(timerNumberQV.text) > 0)
            timerNumberQV.text = (int.Parse(timerNumberQV.text) - 1).ToString();
        else if (int.Parse(timerNumberQV.text) == 0)
        {
            PosRotSet();
            CancelInvoke();
            ss.qrScene.SetActive(true);
            ss.qrPreScene.SetActive(false);
            verticalBackplate.SetActive(false);
            ht.freeSwitch.gameObject.SetActive(false);
            ht.verticalSwitch.gameObject.SetActive(true);
        }
    }

    
    private void FreeSpawn1()
    {
        freeBackplate.SetActive(true);
        TextMeshPro textMeshPro = ss.whatToDoObjectF.GetComponentInChildren<TextMeshPro>();
        textMeshPro.text = "Look at table QR Code";
        
        if (int.Parse(timerNumberF.text) > 0)
            timerNumberF.text = (int.Parse(timerNumberF.text) - 1).ToString();
        else if (int.Parse(timerNumberF.text) == 0)
        {
            PosRotSet();
            CancelInvoke();
            ss.freeScene.SetActive(true);
            ss.freePreScene.SetActive(false);
            freeBackplate.SetActive(false);
            ht.freeSwitch.gameObject.SetActive(true);
        }
    }
    private void FreeSpawn2()
    {
        freeBackplate.SetActive(true);
        TextMeshPro textMeshPro = ss.whatToDoObjectF.GetComponentInChildren<TextMeshPro>();
        textMeshPro.text = "Look at table QR Code";
        
        if (int.Parse(timerNumberF.text) > 0)
            timerNumberF.text = (int.Parse(timerNumberF.text) - 1).ToString();
        else if (int.Parse(timerNumberF.text) == 0)
        {
            PosRotSet();
            CancelInvoke();
            ss.freeScene.SetActive(true);
            ss.freePreScene.SetActive(false);
            ht.horizontalSwitch.gameObject.SetActive(false);
            freeBackplate.SetActive(false);
            ht.freeSwitch.gameObject.SetActive(true);
        }
    }
    private void FreeSpawn3()
    {
        freeBackplate.SetActive(true);
        TextMeshPro textMeshPro = ss.whatToDoObjectF.GetComponentInChildren<TextMeshPro>();
        textMeshPro.text = "Look at table QR Code";
        
        if (int.Parse(timerNumberF.text) > 0)
            timerNumberF.text = (int.Parse(timerNumberF.text) - 1).ToString();
        else if (int.Parse(timerNumberF.text) == 0)
        {
            PosRotSet();
            CancelInvoke();
            ss.freeScene.SetActive(true);
            ss.freePreScene.SetActive(false);
            ht.verticalSwitch.gameObject.SetActive(false);
            freeBackplate.SetActive(false);
            ht.freeSwitch.gameObject.SetActive(true);
        }
    }

    private void TwoMinTimer()
    {
        if (ss.pageNum == 0)
        {
            if (ss.odd_even_num % 6 == 0)
            {
                twoMinPanelQRH.SetActive(true);
            }
            else if (ss.odd_even_num % 6 == 1)
            {
                twoMinPanelQRH.SetActive(true);
            }
            else if (ss.odd_even_num % 6 == 2)
            {
                twoMinPanelFree.SetActive(true);
            }
            else if (ss.odd_even_num % 6 == 3)
            {
                twoMinPanelFree.SetActive(true);
            }
            else if (ss.odd_even_num % 6 == 4)
            {
                twoMinPanelQRV.SetActive(true);
            }
            else if (ss.odd_even_num % 6 == 5)
            {
                twoMinPanelQRV.SetActive(true);
            }
        }
        else if (ss.pageNum == 1)
        {
            if (ss.odd_even_num % 6 == 0)
            {
                twoMinPanelQRV.SetActive(true);
            }
            else if (ss.odd_even_num % 6 == 1)
            {
                twoMinPanelFree.SetActive(true);
            }
            else if (ss.odd_even_num % 6 == 2)
            {
                twoMinPanelQRV.SetActive(true);
            }
            else if (ss.odd_even_num % 6 == 3)
            {
                twoMinPanelQRH.SetActive(true);
            }
            else if (ss.odd_even_num % 6 == 4)
            {
                twoMinPanelFree.SetActive(true);
            }
            else if (ss.odd_even_num % 6 == 5)
            {
                twoMinPanelQRH.SetActive(true);
            }
        }
        else if (ss.pageNum == 2)
        {
            if (ss.odd_even_num % 6 == 0)
            {
                twoMinPanelFree.SetActive(true);
            }
            else if (ss.odd_even_num % 6 == 1)
            {
                twoMinPanelQRV.SetActive(true);
            }
            else if (ss.odd_even_num % 6 == 2)
            {
                twoMinPanelQRH.SetActive(true);
            }
            else if (ss.odd_even_num % 6 == 3)
            {
                twoMinPanelQRV.SetActive(true);
            }
            else if (ss.odd_even_num % 6 == 4)
            {
                twoMinPanelQRH.SetActive(true);
            }
            else if (ss.odd_even_num % 6 == 5)
            {
                twoMinPanelFree.SetActive(true);
            }
        } 
        
        timerActive = true;
    }

    private void Update()
    {
        if (timerActive == true)
        {
            if (timerForSound > 0)
            {
                timerForSound = timerForSound - Time.deltaTime;
            }
            else
            {
                audioSource.Play();
                timerActive = false;
                timerRepeat = true;
                timerForSound = 120f;
                // InvokeRepeating("Timer", 0f, 1f);
                
                if (ss.pageNum == 0)
                {
                    if (ss.odd_even_num % 6 == 0)
                    {
                        buttonQH.SetActive(true);
                    }
                    else if (ss.odd_even_num % 6 == 1)
                    {
                        buttonQH.SetActive(true);
                    }
                    else if (ss.odd_even_num % 6 == 2)
                    {
                        buttonFree.SetActive(true);
                    }
                    else if (ss.odd_even_num % 6 == 3)
                    {
                        buttonFree.SetActive(true);
                    }
                    else if (ss.odd_even_num % 6 == 4)
                    {
                        buttonQV.SetActive(true);
                    }
                    else if (ss.odd_even_num % 6 == 5)
                    {
                        buttonQV.SetActive(true);
                    }
                }
                else if (ss.pageNum == 1)
                {
                    if (ss.odd_even_num % 6 == 0)
                    {
                        buttonQV.SetActive(true);
                    }
                    else if (ss.odd_even_num % 6 == 1)
                    {
                        buttonFree.SetActive(true);
                    }
                    else if (ss.odd_even_num % 6 == 2)
                    {
                        buttonQV.SetActive(true);
                    }
                    else if (ss.odd_even_num % 6 == 3)
                    {
                        buttonQH.SetActive(true);
                    }
                    else if (ss.odd_even_num % 6 == 4)
                    {
                        buttonFree.SetActive(true);
                    }
                    else if (ss.odd_even_num % 6 == 5)
                    {
                        buttonQH.SetActive(true);
                    }
                }
                else if (ss.pageNum == 2)
                {
                    if (ss.odd_even_num % 6 == 0)
                    {
                        buttonFree.SetActive(true);
                    }
                    else if (ss.odd_even_num % 6 == 1)
                    {
                        buttonQV.SetActive(true);
                    }
                    else if (ss.odd_even_num % 6 == 2)
                    {
                        buttonQH.SetActive(true);
                    }
                    else if (ss.odd_even_num % 6 == 3)
                    {
                        buttonQV.SetActive(true);
                    }
                    else if (ss.odd_even_num % 6 == 4)
                    {
                        buttonQH.SetActive(true);
                    }
                    else if (ss.odd_even_num % 6 == 5)
                    {
                        buttonFree.SetActive(true);
                    }
                } 
            }
        }

        if (timerRepeat == true)
        {
            if (timerForRepeatSound > 0)
            {
                timerForRepeatSound = timerForRepeatSound - Time.deltaTime;
            }
            else
            {
                audioSource.Play();
                timerForRepeatSound = 10f;
            }
        }
    }
    
    public void onButtonAfterTimer()
    {
        if (ss.pageNum == 0)
        {
            if (ss.odd_even_num % 6 == 0)
            {
                twoMinPanelQRH.SetActive(false);
            }
            else if (ss.odd_even_num % 6 == 1)
            {
                twoMinPanelQRH.SetActive(false);
            }
            else if (ss.odd_even_num % 6 == 2)
            {
                twoMinPanelFree.SetActive(false);
            }
            else if (ss.odd_even_num % 6 == 3)
            {
                twoMinPanelFree.SetActive(false);
            }
            else if (ss.odd_even_num % 6 == 4)
            {
                twoMinPanelQRV.SetActive(false);
            }
            else if (ss.odd_even_num % 6 == 5)
            {
                twoMinPanelQRV.SetActive(false);
            }
        }
        else if (ss.pageNum == 1)
        {
            if (ss.odd_even_num % 6 == 0)
            {
                twoMinPanelQRV.SetActive(false);
            }
            else if (ss.odd_even_num % 6 == 1)
            {
                twoMinPanelFree.SetActive(false);
            }
            else if (ss.odd_even_num % 6 == 2)
            {
                twoMinPanelQRV.SetActive(false);
            }
            else if (ss.odd_even_num % 6 == 3)
            {
                twoMinPanelQRH.SetActive(false);
            }
            else if (ss.odd_even_num % 6 == 4)
            {
                twoMinPanelFree.SetActive(false);
            }
            else if (ss.odd_even_num % 6 == 5)
            {
                twoMinPanelQRH.SetActive(false);
            }
        }
        else if (ss.pageNum == 2)
        {
            if (ss.odd_even_num % 6 == 0)
            {
                twoMinPanelFree.SetActive(false);
            }
            else if (ss.odd_even_num % 6 == 1)
            {
                twoMinPanelQRV.SetActive(false);
            }
            else if (ss.odd_even_num % 6 == 2)
            {
                twoMinPanelQRH.SetActive(false);
            }
            else if (ss.odd_even_num % 6 == 3)
            {
                twoMinPanelQRV.SetActive(false);
            }
            else if (ss.odd_even_num % 6 == 4)
            {
                twoMinPanelQRH.SetActive(false);
            }
            else if (ss.odd_even_num % 6 == 5)
            {
                twoMinPanelFree.SetActive(false);
            }
        }

        timerForRepeatSound = 10f;
        timerRepeat = false;
        
        InvokeRepeating("Timer", 0f, 1f);
    }
}
