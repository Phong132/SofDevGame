using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class gameScores : IComparable<gameScores>
{
    public int score { get; set; }
    public string name { get; set; }
    public int ID { get; set; }

    public gameScores(int id, int score, string name)
    {
        this.score = score;
        this.name = name;
        this.ID = id;
    }

    public int CompareTo(gameScores other)
    {
        if (other.score < this.score)
        {
            return -1;
        }
        if (other.score > this.score)
        {
            return 1;
        }
        else if (other.ID > this.ID)
        {
            return -1;
        }
        else if (other.ID < this.ID)
        {
            return 1;
        }
        return 0;
    }
}
