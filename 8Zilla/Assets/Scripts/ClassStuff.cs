using UnityEngine;
using System.Collections;

public class ClassStuff : MonoBehaviour 
{
	int maxNumber = 100;
	int maxPerson = 10;
	int magicNumber = 7;
	int magicNumberTwo = 11;

	// Use this for initialization
	void Start () 
	{
		FindTheNumber (maxPerson,maxNumber);
	}

	void Update()
	{


	}
	// Update is called once per frame
	void FindTheNumber (int maxPerson, int maxNumber) 
	{
		int person = 0;
		int counter;
		int direction = 1;
		int skip = 0;//
		for(counter = 1;counter<= maxNumber; counter++)
		{
			print ("Number:" + counter);
			person = (person + direction + skip) % maxPerson;
			if(person <= 0)
			{
				person = maxPerson;
			}

			if(counter % magicNumber == 0)
			{
				direction = direction *-1;
			}
			if(counter % magicNumberTwo == 0)
			{
				skip = direction;
			}else skip = 0;
			print ("Person: " + person);
		}
	
	}
}
