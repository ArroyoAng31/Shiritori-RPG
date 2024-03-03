using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RandomEnemy
{
    private EnemyTypes defaultEnemy = new EnemyTypes();
    private System.Random rand = new System.Random();
    private static int maxPercent = 10000;
    private int randomPercent;
    private int goblinPercent;
    private int slimePercent;
    private int randomEnemyType; //private string randomEnemyType; //Its easier to have random enemy choosen if using ints to track them

    public EnemyTypes RandomEnemyChoosen(int numberOfWins)
    {
        if(numberOfWins %10 == 0 && numberOfWins != 0)//Every 10 enemies defeated spawns a boss
        {
            Boss boss = new Boss();
            return boss;
        }

        else
        {
            randomEnemyType = EnemyRandomizeFormula();

            switch (randomEnemyType)
            {
                case 0:
                    {
                        Goblin goblin = new Goblin();
                        return goblin;
                    }

                case 1:
                    {
                        Slime slime = new Slime();
                        return slime;
                    }

                default:
                    {
                        return defaultEnemy;
                    }
            }
        }
    }

    public int EnemyRandomizeFormula()
    {
        int[] percentageArray = new int[maxPercent];
        int[] enemyArray = {goblinPercent, slimePercent};
        double equalPercentage = 1.0 / enemyArray.Length; //Equal Percentage for one enemyType
        int equalEnemyPercDistr = Convert.ToInt32((int)Math.Round(maxPercent * equalPercentage));//Turn the percentage from equalPercentage to a value based on maxPercent
        int valueSent = 0;
        //int percentage = 0;

        randomPercent = rand.Next(maxPercent); 

        for(int i = 0; i < enemyArray.Length; i++) //should work if all the enemy percentages are the same amount
        {
            enemyArray[i] = equalEnemyPercDistr * (i + 1);
        }
        /*The for-loop automatically does this when adding a new enemy to the Array IF you want all the same appearance %
         * goblinPercent = equalEnemyPercDistr;
        slimePercent = goblinPercent + equalEnemyPercDistr;*/

        /* for (int i = 0; i < maxPercent; i++)
         {
             percentageArray[i] = i; //filling up array 0:maxPercent-1
         }*/

        //int j = 0; // If kept outside of for loop it won't run through second array multiple times
        Debug.Log("Random Percent: " +randomPercent);
        Debug.Log("Goblin Percent: " + enemyArray[0]);
        Debug.Log("Slime Percent: " + enemyArray[1]);
        for (int i = 0; i < enemyArray.Length; i++)
        {

            if (enemyArray[i] != randomPercent && randomPercent > enemyArray[i])
            {

            }
            else if (enemyArray[i] == randomPercent || enemyArray[i] > randomPercent)
            {
                valueSent = i;
                break;
            }
            /*{

                for (; j < maxPercent; j++)
                {
                    if (percentageArray[j] > enemyArray[i])
                    {
                        break;
                    }
                    else if (percentageArray[j] == randomPercent)
                    {
                        percentage = percentageArray[j];
                        break;
                    }
                }
            }
            if (percentage == randomPercent)
            {
                valueSent = i;
                break;
            }*/
        }
        return valueSent;

        /*If using if-statements gotta make a new if-else each time for each enemy made
         * if (randomPercent <= equalEnemyPercDistr)
            return "Goblin";
        else if (randomPercent > equalEnemyPercDistr)
            return "Slime";
        else
            return randomEnemyType;*/
    }
}
