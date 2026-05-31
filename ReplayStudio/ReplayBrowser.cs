namespace ReplayStudio;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;
using ReplayMod;
using ReplayMod.Replay.Files;
using ReplayMod.Replay;
using System.Globalization;
using Il2CppSystem.Runtime.Remoting.Messaging;

internal static class ReplayBrowser
{
	internal static ReplayExplorer explorer;
	internal static List<Session> sessions = new();
	internal static void ListReplays()
	{
		List<ReplayExplorer.Entry> entries = (List<ReplayExplorer.Entry>)ReplayAPI.Entries;
		
		foreach (ReplayExplorer.Entry entry in entries)
		{
			if (entry.IsFolder)
			{
				Debug.Log("Entry is folder");
				continue;
			}
			string lineToPrint = "";
			try
			{
				lineToPrint = $"{entry.Name}, {entry.header.Players[0].Name} vs {entry.header.Players[1].Name}, {entry.header.Players[0].WasHost}, {entry.header.Scene}, {entry.header.Date}";

				if (sessions.Count == 0 || sessions.Last<Session>().Opponent != entry.header.Players[1].Name)
				{
					sessions.Add(new Session(entry.header.Players[1].Name, entry.header.Date));
				}
				sessions.Last<Session>().Entries.Add(entry);
			}
			catch (Exception ex) { Debug.Log($"{ex}"); }
			//Debug.Log(lineToPrint);

		}

		foreach(Session sesh in sessions)
		{
			Debug.Log($"Current session {sesh.Opponent} on {sesh.Date.ToString("yyyy-MM-dd")} with {sesh.Entries.Count()} fights");
			foreach(ReplayExplorer.Entry entry in  sesh.Entries)
			{
				Debug.Log($"\t{entry.Name}, {entry.header.Players[0].Name} vs {entry.header.Players[1].Name}, {entry.header.Players[0].WasHost}, {entry.header.Scene}, {entry.header.Date}");
			}
		}
		Debug.Log(explorer.currentlySelectedEntry.Name);
	}
}

internal class Session
{
	internal string Opponent;
	internal List<ReplayExplorer.Entry> Entries = new();
	internal int MarkerCount;
	internal DateTime Date;

	public Session(string opponent, string date)
	{ 
		Opponent = opponent;

		string format = "yyyy-MM-dd HH:mm:ss";
		if (DateTime.TryParseExact(date, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out Date))
		{
			Console.WriteLine($"Successfully parsed: {Date}");
		}

	}
}
