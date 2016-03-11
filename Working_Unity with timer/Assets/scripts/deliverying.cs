using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class deliverying : MonoBehaviour {
    public Rigidbody projectile;
    public Transform shotPos;
    private GUIStyle guiStyle = new GUIStyle();
    float TimeRemaining = 45;
    int Points = 0;

    bool PizzaPickup = false;
    bool PizzaDelivered = false;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (PizzaPickup)
        {
            TimeRemaining -= Time.deltaTime;   //To update the timer
        }
        //float 
        float x1 = transform.position.x;
        float y1 = transform.position.y ;
        float z1 = transform.position.z;
        //transform.Translate(new Vector3(h, v, 0f));

        if (Input.GetKeyDown(KeyCode.G))
        {
            Rigidbody shot = Instantiate(projectile, new Vector3(x1 +0.2f, y1 + 0.6f, z1), transform.rotation) as Rigidbody;
        }
    }

    void OnCollisionEnter(Collision col)
    {

        float x1 = transform.position.x;
        float y1 = transform.position.y;
        float z1 = transform.position.z;
        if (col.gameObject.name == "Cube")
        {
            Rigidbody shot = Instantiate(projectile, new Vector3(x1 + 0.2f, y1 + 0.6f, z1), transform.rotation) as Rigidbody;

            PizzaDelivered = true;
            Points = 100;

        }

        if (col.gameObject.tag == "Pizza")
        {
            Destroy(col.gameObject);
            PizzaPickup = true;
        }
    }

    void OnControllerColliderHit(Collision hit)
    {
        if (hit.gameObject.tag == "Pizza")
        {
           
            PizzaPickup = true;
        }
        else
        {
            PizzaPickup = false;
        }
    }

    public void OnGUI() // OnGUI is called twice per frame
    {

        guiStyle.fontSize = 30;
        guiStyle.fontStyle = FontStyle.Bold;
        GUI.contentColor = Color.blue;

        

        if (PizzaPickup)
        {
          //  GUI.Label(new Rect(600,75, 100, 100), "You picked the pizza!!", guiStyle);

            if (TimeRemaining > 0)
            {
               

                if(PizzaDelivered)
                {
                    
                    GUI.Label(new Rect(650, 50, 200, 200), "Congrats!! You delivered sucessfully!! " , guiStyle);
                    GUI.Label(new Rect(100, 50, 200, 200), "Points :  " + Points, guiStyle);
                    //   GUI.Label(new Rect(100, 50, 200, 200), "Points :  " + Points, guiStyle);
                }
                else
                {
                    GUI.Label(new Rect(650, 50, 200, 200), "Time to deliver pizza : " + (int)TimeRemaining, guiStyle);
                    GUI.Label(new Rect(100, 50, 200, 200), "Points :  " + Points, guiStyle);
                }
            }
            else
            {
                GUI.Label(new Rect(650, 50, 200, 200), "You failed to deliver on time!",guiStyle);
            }

           
        }


    }

}

