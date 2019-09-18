using System;
using System.Linq;
using System.Collections.Generic;

namespace Ranking
{
    public class Program
    {
        public static void Main()
        {
            var contest = Console.ReadLine();
            var contestData = new Dictionary<string, string>();

            while(contest!="end of contests")
            {
                var contestInfo = contest.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                var contestName = contestInfo[0];
                var contestPass = contestInfo[1];

                if (!contestData.ContainsKey(contestName))
                {
                    contestData.Add(contestName, contestPass);
                }

                contest = Console.ReadLine();
            }

            var submission = Console.ReadLine();
            var candidatesData = new Dictionary<string, Dictionary<string, int>>();

            while(submission!="end of submissions")
            {
                var submissionInfo = submission.Split(new string[] { "=>" }, StringSplitOptions.RemoveEmptyEntries);
                var contestName = submissionInfo[0];
                var password = submissionInfo[1];
                var username = submissionInfo[2];
                var points = int.Parse(submissionInfo[3]);

                if(contestData.ContainsKey(contestName) && contestData[contestName] == password)
                {
                    var contestPoints = new Dictionary<string, int>();

                    if (!candidatesData.ContainsKey(username))
                    {
                        contestPoints.Add(contestName, points);
                        candidatesData.Add(username, contestPoints);
                    }
                    else
                    {
                        contestPoints = candidatesData[username];

                        if (!contestPoints.ContainsKey(contestName))
                        {
                            contestPoints.Add(contestName, points);
                        }
                        else
                        {
                            if (contestPoints[contestName] < points)
                            {
                                contestPoints[contestName] = points;
                            }
                        }

                        candidatesData[username] = contestPoints;
                    }                    
                }

                submission = Console.ReadLine();
            }

            var candidatesTotalPoints = new Dictionary<string, int>();

            foreach (var candidate in candidatesData)
            {
                candidatesTotalPoints.Add(candidate.Key, 0);

                foreach (var competition in candidate.Value)
                {
                    candidatesTotalPoints[candidate.Key] += competition.Value;
                }
            }

            foreach (var candidate in candidatesTotalPoints.OrderByDescending(x=>x.Value))
            {
                Console.WriteLine($"Best candidate is {candidate.Key} with total {candidate.Value} points.");
                break;
            }

            Console.WriteLine("Ranking:");

            foreach (var student in candidatesData.OrderBy(x=>x.Key))
            {
                Console.WriteLine(student.Key);
                var competition = student.Value;

                foreach (var element in competition.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"#  {element.Key} -> {element.Value}");
                }
            }
        }
    }
}
