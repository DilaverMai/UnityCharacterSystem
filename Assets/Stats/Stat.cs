namespace Stats
{
    public class Stat
    {
        public string StatName;
        public int Value;
        public int MaxValue;
        
        public Stat(StatData data)
        {
            StatName = data.StatName;
            Value = data.Value;
            MaxValue = data.MaxValue;
        }
    }
}
