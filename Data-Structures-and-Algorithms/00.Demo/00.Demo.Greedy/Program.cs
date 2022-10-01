using System.Numerics;

public class Program
{
    public static void ActivitySelection()
    {
        int[] activityStarts = { 1, 3, 0, 5, 3, 5, 6, 8, 8, 2, 12 };
        int[] activityEnds = { 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

        LinkedList<int> viableActivities = new LinkedList<int>(Enumerable.Range(0, activityStarts.Length));
        List<int> selectedActivities = new List<int>();

        while(viableActivities.Count > 0)
        {
            int currentActivity = viableActivities.First.Value;
            selectedActivities.Add(currentActivity);
            viableActivities.RemoveFirst();

            for (int i = 0; i < activityStarts.Length; i++)
            {
                if (viableActivities.Find(i) != null && activityStarts[i] <= activityEnds[currentActivity])
                {
                    viableActivities.Remove(viableActivities.Find(i));
                }
            }
        }

        Console.WriteLine(string.Join(" ", selectedActivities));
    }

    public static void Main(string[] args)
    {
        ActivitySelection();
    }
}