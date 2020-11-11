// Get the latest webcam shot from outside "Friday's" in Times Square
using UnityEngine;
using System.Collections;

public class WWWTest : MonoBehaviour
{
    public string url = "http://images.earthcam.com/ec_metros/ourcams/fridays.jpg";
	public Material fallbackMat;
	
    IEnumerator Start()
    {
        using (WWW www = new WWW(url))
        {
            yield return www;

			Renderer renderer = GetComponent<Renderer>();

			// how do I check to see if it's the red question mark?
			if(www.isDone) {
            	renderer.material.mainTexture = www.texture;
			} else {
				renderer.material = fallbackMat;
			}
            
        }
    }
}