namespace ConsoleApp1;

public class Program
{
    private static string FindLongestAdjacentString(IReadOnlyList<char[]>? matrix)
    {
        if (matrix == null || matrix.Count == 0 || matrix[0].Length == 0)
        {
            return string.Empty;
        }

        var rows = matrix.Count;
        var columns = matrix[0].Length;
        var maxLen = 0;
        var maxString = "";

        /*
            (0, 1): R
            (1, 0): L
            (1, 1): DR
            (1, -1): DL
        */
        int[] dx = { 0, 1, 1, 1 };
        int[] dy = { 1, 0, 1, -1 };

        for (int x = 0; x < rows; x++)
        {
            for (int y = 0; y < columns; y++)
            {
                if (matrix[x][y] == ' ')
                {
                    continue;
                }

                for (var dir = 0; dir < 4; dir++)
                {
                    var currentLen = 1;
                    var newX = x + dx[dir];
                    var newY = y + dy[dir];

                    while (newX >= 0 && newX < rows && newY >= 0 && newY < columns && matrix[newX][newY] == matrix[x][y])
                    {
                        currentLen++;
                        newX += dx[dir];
                        newY += dy[dir];
                    }

                    if (currentLen <= maxLen) continue;

                    maxLen = currentLen;
                    maxString = new string(matrix[x][y], maxLen);
                }
            }
        }

        return maxString;
    }


    private static void Main()
    {
        const string filePath = "input.txt";
        var lines = File.ReadAllLines(filePath);
        var matrix = new char[lines.Length][];
        for (var i = 0; i < lines.Length; i++)
        {
            matrix[i] = lines[i].ToCharArray();
        }

        var longestAdjacentString = FindLongestAdjacentString(matrix);

        Console.WriteLine("Longest adjacent equal string: " + longestAdjacentString);
        Console.ReadKey();
    }
}