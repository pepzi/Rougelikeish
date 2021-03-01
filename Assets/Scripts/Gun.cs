using UnityEngine;


public class Gun : MonoBehaviour
{
    
    public GameObject Bullet;
    public float ReloadTime;
    public float Speed;
    public Camera Cam;

    private float _lastDelta;


    private void Awake()
    {
        if (Cam == null) Cam = Camera.main;
    }

    void Start()
    {
        Physics2D.IgnoreLayerCollision(Constants.GunLayer, Constants.GunLayer, true);
        Physics2D.IgnoreLayerCollision(Constants.PlayerLayer, Constants.GunLayer, true);
    }

    void Update()
    {
        if ( Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0) )
        {
            if (_lastDelta >= ReloadTime)
            {
                Vector2 screenMousePosition = Input.mousePosition;
                
                Vector2 mousePosition = Cam.ScreenToWorldPoint(screenMousePosition);

                Vector2 direction = mousePosition - (Vector2)transform.position;
                direction.Normalize();
                direction *= Speed;

                GameObject bull = Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
                bull.GetComponent<FixedProjectile>().SetTarget(direction);
                _lastDelta = 0;
            }           
        }
        _lastDelta += Time.deltaTime;
    }
}
