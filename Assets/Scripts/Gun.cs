using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public float reloadTime;

    public float speed;
    public Camera cam;
    private float lastDelta;


    private void Awake()
    {
        if (cam == null) cam = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(3, 3, true);
        Physics2D.IgnoreLayerCollision(6, 3, true);
        Debug.Log(cam.pixelWidth + "x" + cam.pixelHeight);
    }

    void Update()
    {
        if ( Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0) )
        {
            if (lastDelta >= reloadTime)
            {
                Vector2 screenMousePosition = Input.mousePosition;
                
                Vector2 mousePosition = cam.ScreenToWorldPoint(screenMousePosition);

                Vector2 direction = mousePosition - (Vector2)transform.position;
                direction.Normalize();
                direction *= speed;

                GameObject bull = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
                bull.GetComponent<FixedProjectile>().SetTarget(direction);
                lastDelta = 0;
            }           
        }
        lastDelta += Time.deltaTime;
    }
}
