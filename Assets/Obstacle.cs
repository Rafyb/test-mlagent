using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float Movespeed = 3.5f;
    [HideInInspector]public MLPlayer player;

    private void Update()
    {
        this.transform.Translate(Vector3.right * Movespeed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("WallEnd") == true)
        {
            player.AddPoint();
            Destroy(this.gameObject);
        } 
        
      
    }
}