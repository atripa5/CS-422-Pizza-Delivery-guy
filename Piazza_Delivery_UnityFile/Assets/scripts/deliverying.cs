using UnityEngine;
using System.Collections;

public class deliverying : MonoBehaviour {
    public Rigidbody projectile;
    public Transform shotPos;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


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
        }
    }
}
