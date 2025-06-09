using System.IO;

namespace B2ImgEditor.Models // <-- Make sure this matches your project
{
    public class B2Image
    {
        public int[,] Pixels { get; private set; }
        public int Width => Pixels.GetLength(1);
        public int Height => Pixels.GetLength(0);

        public B2Image(int height, int width)
        {
            Pixels = new int[height, width];
        }

        public static B2Image LoadFromFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            string[] size = lines[0].Split(' ');

            int height = int.Parse(size[0]);
            int width = int.Parse(size[1]);

            B2Image image = new B2Image(height, width);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    image.Pixels[i, j] = lines[i + 1][j] - '0';
                }
            }

            return image;
        }
    }
}
