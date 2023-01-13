using UnityEngine;

public class GUITest : MonoBehaviour {
            
    void OnGUI ()
    {
        // Make a background box
        GUI.Box(new Rect(10,10,100,90), "Loader Menu");
    
        // Make the first button.
        if (GUI.Button(new Rect(20,40,80,20), "Button 1"))
        {
            Debug.Log("OnClickButton1");
        }
    
        // Make the second button.
        if (GUI.Button(new Rect(20,70,80,20), "Button 2"))
        {
            Debug.Log("OnClickButton2");
        }
    }
}