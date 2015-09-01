using UnityEngine;
using System.Collections;

public class MovimientoEnX : MonoBehaviour {

	public float velocidad =.3f;
	public float velocidadDeRotacion=.3f;
	private float tamanoDePantalla=Screen.width;
	private Vector3 startPos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.touchCount>0)
		{
			Touch touch = Input.touches[0];
	        switch (touch.phase)
	        {
	            case TouchPhase.Began:
	                startPos = touch.position;
	              
	                break;
	            case TouchPhase.Moved:
	                float swipeDistVerticalf = (new Vector3(0, touch.position.y) - new Vector3(0, startPos.y)).magnitude;
	                float swipeDistHorizontalf = (new Vector3(touch.position.x, 0) - new Vector3(startPos.x, 0)).magnitude;
	                float angulof = Mathf.Atan2((touch.position.y - startPos.y), (touch.position.x - startPos.x)) * Mathf.Rad2Deg;
                    
	                if ((touch.position.y > startPos.y)&&(startPos.x>tamanoDePantalla/2))
	                {
	                	this.gameObject.transform.eulerAngles=new Vector3(this.gameObject.transform.eulerAngles.x,this.gameObject.transform.eulerAngles.y,this.gameObject.transform.eulerAngles.z+velocidadDeRotacion);
	                }
	                if ((touch.position.y < startPos.y)&&(startPos.x>tamanoDePantalla/2))
	                {
	                	this.gameObject.transform.eulerAngles=new Vector3(this.gameObject.transform.eulerAngles.x,this.gameObject.transform.eulerAngles.y,this.gameObject.transform.eulerAngles.z-velocidadDeRotacion);
	                }
	                if ((touch.position.y > startPos.y)&&(startPos.x<tamanoDePantalla/2))
	                {
	                	this.gameObject.transform.eulerAngles=new Vector3(this.gameObject.transform.eulerAngles.x,this.gameObject.transform.eulerAngles.y,this.gameObject.transform.eulerAngles.z-velocidadDeRotacion);
	                }
	                if ((touch.position.y < startPos.y)&&(startPos.x<tamanoDePantalla/2))
	                {
	                	this.gameObject.transform.eulerAngles=new Vector3(this.gameObject.transform.eulerAngles.x,this.gameObject.transform.eulerAngles.y,this.gameObject.transform.eulerAngles.z+velocidadDeRotacion);
	                }
	                

	                break;
                case TouchPhase.Stationary:
                    if (touch.position.x > tamanoDePantalla / 2)
                        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + velocidad, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
                    else
                        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x - velocidad, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
                    break;
	            case TouchPhase.Ended:

	                this.gameObject.transform.position= new Vector3(this.gameObject.transform.position.x,this.gameObject.transform.position.y,this.gameObject.transform.position.z);

	                
	                break;

	        }
		}
	
	}
}
