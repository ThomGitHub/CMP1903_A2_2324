internal class Die
{
    private int _value;
    public int Value
    {
        get { return _value; }
        set { _value = value; }
    }

    public void Roll()
    {
        Random die = new(); 
        int roll = die.Next(1, 7);
        Value = roll;
    }
}