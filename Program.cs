string filePath = "votes.txt";
Dictionary<string, int> voting = new ();

try
{
  using (var streamReader = File.OpenText(filePath))
  {
    while(!streamReader.EndOfStream)
    {
      string[] line = streamReader.ReadLine().Split(",");
      var candidate = new Candidate { Name = line[0], Votes = int.Parse(line[1]) };
      if (voting.ContainsKey(candidate.Name)) {
        voting[candidate.Name] += candidate.Votes;
      } else {
        voting[candidate.Name] = candidate.Votes;
      }
    }
  }
}
catch (Exception e)
{
  System.Console.WriteLine(e.Message);
}

System.Console.WriteLine("Voting:");
foreach(var item in voting)
{
  System.Console.WriteLine($"{item.Key}: {item.Value}");
}