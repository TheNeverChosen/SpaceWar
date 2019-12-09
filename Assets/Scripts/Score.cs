using UnityEngine;
using UnityEngine.UI;
public class Score:MonoBehaviour{
    int score;
    public Text numbers;
    void Start(){
        numbers.text=score.ToString();
	}
	public void ScoreUp(int value){
        score+=value;
        numbers.text=score.ToString();
    }
}