﻿public class GameController {

    /* So, Unity's Roll-a-ball tutorial uses the PlayerController to keep track of the score.
     * I'll be using a singleton for a game controller, so every object can reference to it.
     * Singleton is a design pattern that basically says an object that can have only one instance of it.
     * Plus, if the object is not instantiated yet, it does so.
     */

    static GameController m_instance; // I declare a variable of this same Class,
                                      // which will be empty 'cause it's not instantiated yet.

    private int score;
    private int pickUpsOnLevel;
    private bool levelWon;

    public static GameController Instance
    {
        get // I override the getter with this
        {
            if (m_instance == null)
            {
                m_instance = new GameController();
            }

            return m_instance;

            // This asks for my GameController instance, and if there's none, it creates it.
        }
    }

    private GameController() // This is the Constructor. I made it private so only this class can call it (which is what I want).                   
    {
        Score = 0;
        pickUpsOnLevel = 0;
        levelWon = false;
    }

    /* Then, instead of instantiating this object using GameController gameController = new GameController();
     * I do GameController.Instance; which since it's a class method and not an instance method, I can call it from anywhere.
     * And since it's a singleton, it will always return the same instance ;)
     */

    public int Score // Getter and setter for the score.
    {
        get
        {
            return score; // I'll use the getter to show the score.
        }

        private set
        {
            score = value;
        }
    }

    public void AddToScore(int pickUpValue)
    {
        Score += pickUpValue;
        UpdateScoreUI();
        CompareScoreToObjective();

        if (levelWon)
            CongratulateUser();
    }

    public void pickUpCreated(int pickUpValue)
    {
        pickUpsOnLevel += pickUpValue;
    }

    private void CompareScoreToObjective()
    {
        if (Score == pickUpsOnLevel)
            levelWon = true;
    }

    private void UpdateScoreUI()
    {
    }

    private void CongratulateUser()
    {
    }
}
