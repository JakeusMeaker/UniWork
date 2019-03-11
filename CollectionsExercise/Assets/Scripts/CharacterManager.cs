using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SortType
{
    NAME=0,
    AGE,
    HEALTH,
    SCORE
}


[Serializable]
public class Character: IComparable<Character>
{
    public string Name;
    public int Age;
    public int Health;
    public int Score;

    public static SortType SortBy;

    public int CompareTo(Character other)
    {
        switch (SortBy)
        {
            case SortType.NAME:
                return Name.CompareTo(other.Name);
                break;
            case SortType.AGE:
                return Age.CompareTo(other.Age);
                break;
            case SortType.HEALTH:
                return Health.CompareTo(other.Health);
                break;
            case SortType.SCORE:
                return Score.CompareTo(other.Score);
                break;
            default:
                return 0;
                break;
        }
    }
}

public class CharacterManager : MonoBehaviour {

    //The character list
    public List<Character> Characters=new List<Character>();

    //The UI Objects
    public Canvas UICanvas;
    //This is hidden but is a convient way of spawning text dynamically
    public Text UITextTemplate;

    public List<Text> textList = new List<Text>();

	// Use this for initialization
	void Start ()
    {
        RefreshList();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            RefreshList();
            Character.SortBy = SortType.NAME;
            Characters.Sort();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            RefreshList();
            Character.SortBy = SortType.SCORE;
            Characters.Sort();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            RefreshList();
            Character.SortBy = SortType.AGE;
            Characters.Sort();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            Characters.Find(x => x.Name.Contains("Brain"));

        }
	}

    void RefreshList()
    {
       foreach (Text text in textList)
        {
            Destroy(text.gameObject);
        }
        textList.Clear();

        //This is around the size of the canvas
        float startYPostition = 730f;
        //iterate and position the characters on the screen
        foreach(Character c in Characters)
        {
            //Create a UI Text object from the template above
            Text characterText = Instantiate<Text>(UITextTemplate);
            textList.Add(characterText);
            //Display some text from the current character
            characterText.text = c.Name + " " + c.Age.ToString() + " " + c.Health.ToString() + " " + c.Score.ToString();
            //Set it as active
            characterText.gameObject.SetActive(true);
            //Set the parent of the current text to the canvas
            characterText.transform.SetParent(UICanvas.transform);
            //position the element
            characterText.rectTransform.position = new Vector3(100, startYPostition, 0.0f);
            //increment the position
            startYPostition -= 30.0f;
        }
    }
}
