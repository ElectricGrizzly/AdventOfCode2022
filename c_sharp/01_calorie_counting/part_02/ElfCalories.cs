namespace ElfCalories
{
    using System.IO;

    class ElfCalories
    {
        static void Main(string[] args)
        {
            int topElfNumber = 3;
            int topCalories = new Calories().GetTopElfCalories(topElfNumber);
            System.Console.WriteLine(topCalories);
        }
    }

    class Calories
    {
        public int GetTopElfCalories(int elfNumber)
        {
            string[] elfCalories = new Data().GetFileData();
            int sum = 0;
            Dictionary<int, int> topElfCalories = GetTopElfDictionary(elfNumber);
            foreach (string calories in elfCalories)
            {
                if (calories == "")
                {
                    if (sum > topElfCalories[0])
                    {
                        AddAndSortTopElfCalories(ref topElfCalories, sum);
                    }
                    sum = 0;
                    continue;
                }
                sum += int.Parse(calories);
            }

            return GetCalorieSum(ref topElfCalories);
        }

        private int GetCalorieSum(ref Dictionary<int, int> topElfCalories)
        {
            int sum = 0;
            foreach (int caloriesSum in topElfCalories.Values)
            {
                sum += caloriesSum;
            }
            return sum;
        }

        private void AddAndSortTopElfCalories(ref Dictionary<int, int> topElfDictionary, int numberToAdd)
        {
            int lastIndex = topElfDictionary.Count - 1;

            for (int index = 0; index < lastIndex; index++)
            {
                if (numberToAdd > topElfDictionary[index] && numberToAdd < topElfDictionary[index + 1])
                {
                    int oldNumber = topElfDictionary[index];
                    topElfDictionary[index] = numberToAdd;
                    AddAndSortTopElfCalories(ref topElfDictionary, oldNumber);
                }
            }

            if (numberToAdd > topElfDictionary[lastIndex])
            {
                int oldNumber = topElfDictionary[lastIndex];
                topElfDictionary[lastIndex] = numberToAdd;
                AddAndSortTopElfCalories(ref topElfDictionary, oldNumber);
            }
        }

        private Dictionary<int, int> GetTopElfDictionary(int dictionarySize)
        {
            Dictionary<int, int> topElfDictionary = new Dictionary<int, int>();
            for (int index = 0; index < dictionarySize; index++)
            {
                topElfDictionary.Add(index, 0);
            }
            return topElfDictionary;
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