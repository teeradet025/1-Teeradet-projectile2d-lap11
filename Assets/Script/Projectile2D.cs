using UnityEngine;

public class Projectile2D : MonoBehaviour
{
    [SerializeField] Transform shootpoin;
    [SerializeField] GameObject target;
    [SerializeField] Rigidbody2D bulletprefab;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 5f , Color.red , 5f);

            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
            
            if (hit.collider != null)
            {
                target.transform.position = new Vector2(hit.point.x, hit.point.y);
                Debug.Log("hit" + hit.collider.name);

                
            }
        }
    }

}
