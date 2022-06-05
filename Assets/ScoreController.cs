using UnityEngine;
using System.Collections;
using System.Text;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{

	public Text ScoreText;
	public static int score;
	public static int currentscore;
	public Text highscore;
	void Start()
	{
		score = 0;
		currentscore = 0;
		highscore.text = PlayerPrefs.GetInt("HighScore : ",0).ToString();
	}
	void Update()
	{
		ScoreText.text = "Score : " + score.ToString();
		PlayerPrefs.SetInt("HighScore : ", score);
	}
	public void Reset()
	{
		PlayerPrefs.DeleteAll();

		highscore.text = "0";
	}
}