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


internal static class ReplayBrowser
{
	internal static ReplayExplorer explorer;
	internal static void ListReplays()
	{
		explorer = ReplayFiles.explorer;

		List<ReplayExplorer.Entry> entries = explorer.GetEntries();
		for (int i = 0; i < entries.Count; i++)
		{

			ReplayExplorer.Entry entry = entries[i];
			try
			{
				Debug.Log($"{entry.Name}   {entry.header.Title}");
			}
			catch (Exception e)
			{
				Debug.Log(e.ToString() + e.StackTrace, false, 1);
			}

			if (entry.Name.Contains("Replay_iListen2Sound [BREEL]-vs-Kalamart_on_Pit_2026-05-29_03-56-48"))
			{
				explorer.Select(i);
				break;
			}
		}

		Debug.Log(explorer.currentlySelectedEntry.Name);
	}
}
