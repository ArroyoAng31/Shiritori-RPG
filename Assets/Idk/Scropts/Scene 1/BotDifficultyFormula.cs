using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BotDifficultyFormula
{
    static System.Random rand = new System.Random();        
    static  int maxPercent = 10000;
    int randPercent = rand.Next(maxPercent); // rand and maxPercent have to be static to make this line work in this field; It works fine if placed in Difficulty
    //int easy = 3;
    //int medium = 7;
    int percentage = 0;   
    double multiplier = 1.02;
    int smallerLength = 0;
    int midLength = 0;
    int topLength = 0;
    int valueSent = 0;

    public int Difficulty(int bots_Defeated)
    {
        
        //should probably make something better out of this
        /*if (bots_Defeated <= easy) {
			int baseValue = Integer.valueOf((int) Math.round(maxPercent*0.7));
			smallerLength = Integer.valueOf((int) Math.round(baseValue / (Math.pow(multiplier, bots_Defeated))));
			midLength = Integer.valueOf((int) Math.round(maxPercent*0.25)) + (baseValue - smallerLength);
			topLength = maxPercent -(smallerLength + midLength);
		}
		else if (bots_Defeated <= medium){
			int baseValue = Integer.valueOf((int) Math.round(maxPercent*0.4));
			midLength = Integer.valueOf((int) Math.round(baseValue / (Math.pow(multiplier, bots_Defeated))));
			topLength = 
		}
		else{ //everything above medium difficulty

		}*/

        int baseValue = Convert.ToInt32((int)Math.Round(maxPercent * 0.7)); //Integer.valueOf((int)
        int smallValueEx = 0;
        int midAdd = 0;

        //Weird ass value distribution based on botsDefeated... Used for now lol
        smallerLength = Convert.ToInt32((int)Math.Round(baseValue / (Math.Pow(multiplier, bots_Defeated))));
        smallValueEx = (baseValue - smallerLength);
        midAdd = Convert.ToInt32((int)Math.Round(smallValueEx * 0.9));
        midLength = Convert.ToInt32((int)Math.Round(maxPercent * 0.25)) + midAdd;
        topLength = maxPercent - (smallerLength + midLength);

        //Setting Values as Cumulative
        midLength = smallerLength + midLength;
        topLength = midLength + topLength;

        int[] percentageArray = new int[maxPercent];
        int[] valuesArray = { smallerLength, midLength, topLength }; //Did I make it this way to practice making it easier to add a new item to the percentage pool?

        for (int i = 0; i < maxPercent; i++)
        {
            percentageArray[i] = i; //filling up array 0:maxPercent-1
        }

        int j = 0; // If kept outside of for loop it won't run through second array multiple times
        for (int i = 0; i < valuesArray.Length; i++)
        {

            if (valuesArray[i] != randPercent)
            {

                for (; j < maxPercent; j++)
                {
                    if (percentageArray[j] > valuesArray[i])
                    {
                        break;
                    }
                    else if (percentageArray[j] == randPercent)
                    {
                        percentage = percentageArray[j];
                        break;
                    }
                }
            }
            if (percentage == randPercent)
            {
                valueSent = i;
                break;
            }
        }
        //Console.WriteLine("Bot_difficulty valueSent is " + valueSent);
        return valueSent;
    }
}
