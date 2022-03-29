namespace Lab4
{
    public class Player
    {
        private string _name;
        private int _points;

        public string Name { get => _name; set => _name = value; }
        public int Points { get => _points; set => _points = value; }

        public void IncreasePoints(int points)
        {
            if(points >= 0)
                _points += points;
        }

        public void ResetPoints()
        {
            _points = 0;
        }
    }
}
