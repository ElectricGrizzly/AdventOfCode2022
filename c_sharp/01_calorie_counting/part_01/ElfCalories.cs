namespace ElfCalories
{
    using System.IO;

    class ElfCalories
    {
        static void Main(string[] args)
        {
            int topCalories = new Calories().GetTopElfCalories();
            System.Console.WriteLine(topCalories);
        }
    }

    class Calories
    {
        public int GetTopElfCalories()
        {
            string[] elfCalories = new Data().GetFileData();
            int sum = 0;
            int greatest = 0;
            foreach (string calories in elfCalories)
            {
                if (calories == "")
                {
                    greatest = sum > greatest ? sum : greatest;
                    sum = 0;
                    continue;
                }
                sum += int.Parse(calories);
            }

            return greatest;
        }
    }

    class Data
    {
        private string CALORIE_FILE = "input.txt";
        private string RELATIVE_PATH = @"..\..\..\data\";

        private string GetDataFilePath()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string file = System.IO.Path.Combine(currentDirectory, this.RELATIVE_PATH + this.CALORIE_FILE);
            return Path.GetFullPath(file);
        }

        public string[] GetFileData()
        {
            return System.IO.File.ReadAllLines(GetDataFilePath());
        }
    }
}