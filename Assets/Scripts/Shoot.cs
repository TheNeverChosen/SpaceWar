using UnityEngine;
public class Shoot : MonoBehaviour{
    [Range(0.01f,1)]public float rate;
    public float damage=1;
    void Start(){
        Destroy(gameObject,3);
    }
	void Update(){
        Vector3 p=transform.position;
        p.y+=10*Time.deltaTime;
        transform.position=p;
    }
}