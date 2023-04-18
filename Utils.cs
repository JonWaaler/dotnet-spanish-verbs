namespace spanish_verbs
{
    public static class Utils
    {
        /// <summary>
        /// Takes a list of items and shuffles it using the
        /// Fisher-Yates algorithm
        /// </summary>
        /// <param name="list">List you want to randomize</param>
        public static void Shuffle(List<string> list)
        {
            Random rng = new Random();

            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                string temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }

    }
}
