using System;
using System.Collections.Generic;
using RestSharp;
using System.Linq;
using GithubDashboard.Utilities;

namespace GithubAPI
{
	/// <summary>
	/// Details the number of additions / deletions for a single week for the given repo.
	/// see: http://developer.github.com/v3/repos/statistics/#get-the-number-of-additions-and-deletions-per-week
	/// </summary>
	public class CodeFrequencyDataItem
	{
		public DateTime WeekCommencing { get; set; }
		public int Additions { get; set; }
		public int Deletions { get; set; }

		public CodeFrequencyDataItem (IList<long> list)
		{
			if (list.Count != 3) {
				throw new ArgumentException ("The IList must have 3 integer elements");
			}

			this.WeekCommencing = list [0].FromUnixTime ();
			this.Additions = (int)list [1];
			this.Deletions = (int)list [2];
		}

		public override string ToString ()
		{
			return string.Format ("[CodeFrequencyEntry: WeekCommencing={0}, Additions={1}, Deletions={2}]",
			                      WeekCommencing, Additions, Deletions);
		}
	}
	
}
