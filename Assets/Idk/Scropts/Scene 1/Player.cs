using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player
{
    //instance variables
    private String name;    //primary key, all names need to be unique!
    private static int id = 0;  //used to create new unique names for all Player objects
    private int score;
    private int idNum;


    //the default constructor - it implements the a new name that is unique by using
    //the static variable called id
    public Player()
    {
        idNum = id;
        name = "John" + id++;
        score = 0;
    }

    //a non-defualt constructor used to make a new Player object with the given name
    //it is assumed that this name is unique and that a precheck has been done before calling
    //this method
    public Player(String name)
    {
        idNum = id++;
        this.name = name;
        score = 0;
    }

    public String getName()
    {
        return name;
    }

    public void setName(String name)
    {
        this.name = name;
    }

    public int getScore()
    {
        return score;
    }

    public void setScore(int score)
    {
        this.score = score;
    }

    public int getIDnum()
    {
        return idNum;
    }

}
