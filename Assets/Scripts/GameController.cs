using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text countText;
    public Text timerText;
    public Text scoreText;
    public Text timeupText;
    public GameObject[] jewelry;
    int jewelryCount = 0;
    float gameTime = 20.0f;
    float timer;
    public int score;
    bool isFever = false;
    public GameObject feverButton;
    public GameObject startButton;
    float feverTime = 10.0f;
 
    // Start is called before the first frame update
    void Start()
    {
         timer = gameTime;
    }

    // Update is called once per frame
    void Update()
    {
	if(timer >= 0)
	{
		timer -= Time.deltaTime;
		timerText.text = "残り時間:" + timer.ToString("f1");
		if(Input.GetMouseButtonDown(0))
		{
			int color = Random.Range(0, 5);
			int position = Random.Range(-8, 9);
			Instantiate(jewelry[color], new Vector3(position, 10, 0), Quaternion.identity);  
			jewelryCount++;
			if(isFever == true)
			{
				Instantiate(jewelry[color], new Vector3(position, 10, 0), Quaternion.identity);  
				jewelryCount++;
			}
		}
	}

	else
	{
		timerText.text = "タイムアップ";
		timeupText.text = "タイムアップ";
		startButton.SetActive(true);
	}
	if(timer <= feverTime)
	{
		if(isFever == false)
		{
			feverButton.SetActive(true);
		}
	}

	countText.text = "宝石数:" + jewelryCount.ToString("f0"); 
	scoreText.text = "スコア:" + score.ToString("f0");
    }

    public void FeverButton()
    {
	isFever = true;
	feverButton.SetActive(false);
    }

    public void StartButton()
    {
	SceneManager.LoadScene("Main");
	isFever = false;
	timer = gameTime;
	score = 0;
	jewelryCount = 0;
	startButton.SetActive(false);
    }
}
