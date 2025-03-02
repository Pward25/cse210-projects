using System;

public class Movie
{
    
    public string GetDirector()
    {
        return "Steven Speilburg";
    }
}


public class Animated : Movie
{
    public string GetAnimator()
    {
        return "Walt Disney";
    }
}

