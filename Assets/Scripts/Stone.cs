using UnityEngine;
public class Stone:MonoBehaviour{
    public float damage;
    public float health;
    public GameObject explosion;
    public int score;
    void OnTriggerEnter2D(Collider2D col){
        if(col.GetComponent<Shoot>()){
            Destroy(col.gameObject);
            if (health<=0){
                FindObjectOfType<Score>().ScoreUp(score);
                GameObject xp=Instantiate(explosion,transform.position,transform.rotation);
                Destroy(gameObject);
                Destroy(xp,3);
            }
            else{
                health-=col.GetComponent<Shoot>().damage;
            }
        }
    }
}