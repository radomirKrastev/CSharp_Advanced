using System;
using System.Collections.Generic;
using System.Linq;

namespace RectangleIntersection
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new string[] { " " },StringSplitOptions.RemoveEmptyEntries);
            var rectanglesCount = int.Parse(input[0]);
            var intersectionsCount = int.Parse(input[1]);
            var rectanglesList = new List<Rectangle>();

            for (int i = 0; i < rectanglesCount; i++)
            {
                var rectangle = Console.ReadLine().Split(new string[] { " " },StringSplitOptions.RemoveEmptyEntries);
                rectanglesList.Add(new Rectangle(rectangle[0]
                    , int.Parse(rectangle[1])
                    ,int.Parse(rectangle[2])
                    , int.Parse(rectangle[3])
                    , int.Parse(rectangle[4])));
            }

            for (int i = 0; i < intersectionsCount; i++)
            {
                var rectanglesIdentification = Console.ReadLine().Split(new string[] { " " },StringSplitOptions.RemoveEmptyEntries);
                var rectangleOneId = rectanglesIdentification[0];
                var rectangleTwoId = rectanglesIdentification[1];

                Rectangle rectangleOne = rectanglesList.FirstOrDefault(x => x.Id == rectangleOneId);
                Rectangle rectangleTwo = rectanglesList.FirstOrDefault(x => x.Id == rectangleTwoId);

                if(rectangleOne.LeftCornerHorizontal<=rectangleTwo.Width || rectangleOne.LeftCornerVertical <= rectangleTwo.Height)
                {
                    Console.WriteLine("true");
                }
            }
        }
    }
}
