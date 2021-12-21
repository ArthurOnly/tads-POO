namespace App.Models
{
    class Grade
    {
        private static int quantity = 1;
        private int _id;
        private double _score;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public double Score
        {
            get { return _score; }
            set { _score = value; }
        }

        public Grade(double score)
        {
            this.Score = score;
            this.Id = quantity;
            quantity++;
        }
    }
}