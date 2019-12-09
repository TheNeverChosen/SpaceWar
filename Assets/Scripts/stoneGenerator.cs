using UnityEngine;
using System.Collections;
public class stoneGenerator : MonoBehaviour {

    public GameObject[] stones;

	// Use this for initialization
	void Start () {
        StartCoroutine(Generator());
	}
	
	IEnumerator Generator()
    {
        float time = Random.Range(.3f, 1f);
        yield return new WaitForSeconds(time);
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;

        pos.x = Random.Range(-16, 17);
        rot.z = Random.Range(0, 360);
        int index = Random.Range(0, stones.Length);
        GameObject rock = Instantiate(stones[index], pos, transform.rotation);
        Destroy(rock, 3.5f);
        StartCoroutine(Generator());    
    }
}
