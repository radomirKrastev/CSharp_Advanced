namespace RectangleIntersection
{
    public class Rectangle
    {
        private string id;
        private int width;
        private int height;
        private int leftCornerHorizontal;
        private int leftCornerVertical;

        public string Id
        {
            get => this.id;
            set => this.id = value;
        }

        public int Width
        {
            get => this.width;
            set => this.width = value;
        }

        public int Height
        {
            get => this.height;
            set => this.height = value;
        }

        public int LeftCornerHorizontal
        {
            get => this.leftCornerHorizontal;
            set => this.leftCornerHorizontal = value;
        }

        public int LeftCornerVertical
        {
            get => this.leftCornerVertical;
            set => this.leftCornerVertical = value;
        }

        public Rectangle()
        {

        }

        public Rectangle (string id, int width, int height, int leftCornerHorizontal, int lefrCornerVertical)
        {
            this.Id = id;
            this.Width = width;
            this.Height = height;
            this.LeftCornerHorizontal = leftCornerHorizontal;
            this.LeftCornerVertical = leftCornerVertical;
        }
    }
}
