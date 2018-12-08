using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Vuforia;


public class DiamondGuyButton : MonoBehaviour, IVirtualButtonEventHandler {
    public GameObject virtualButtonObject;
    public GameObject modelGraphic;
    public Texture m_MainTexture;
    public Texture t_MainTexture;
    private bool onoff = true;
    Renderer m_Renderer;
	// Use this for initialization
	void Start () {
        //GameObject virtualButtonObject = GameObject.Find ("DiamondButton");
        virtualButtonObject.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        m_Renderer = modelGraphic.GetComponent<Renderer>();
            
		
	}
	
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        //modelGraphic.transform.Rotate(new Vector3(0, Time.deltaTime  * 2000 ,0));
        
        Debug.Log("1");
    }
    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        if (onoff){
             m_Renderer.material.SetTexture("_MainTex", m_MainTexture);
         } else {
             m_Renderer.material.SetTexture("_MainTex", t_MainTexture);
         }
         
         onoff = !onoff;
     
        Debug.Log("2");
    }
}
