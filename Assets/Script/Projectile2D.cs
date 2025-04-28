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

                Vector2 projectileVelocity = CalculateProjectileVelocity(shootpoin.position, hit.point, 1f);

                Rigidbody2D shootBullet = Instantiate(bulletprefab, shootpoin.position, Quaternion.identity);

                shootBullet.linearVelocity = projectileVelocity;
                
            }

       
        
        
        }


        Vector2 CalculateProjectileVelocity(Vector2 Origin, Vector2 target ,float time)
        {
            Vector2 distance = target - Origin;

            float velocityX= distance.x /time;
            float velocityY= distance.y /time + 0.5f * Mathf.Abs(Physics2D.gravity.y)*time;

            Vector2 projectileVelocity = new Vector2(velocityX, velocityY);
            return projectileVelocity;

        }



    }



}
