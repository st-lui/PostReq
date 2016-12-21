using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PostReq.Model;

namespace PostReq.Controller
{
	public class SearchController
	{
		public static SearchModel PerformSearch(SearchModel searchModel)
		{
			searchModel.PreviousResult = searchModel.CurrentResult;
			if (searchModel.PreviousResult == null)
			{
				Nom nom = searchModel.NomList.Find(
					x => { int index = x.Name.IndexOf(searchModel.SearchPattern, 0, StringComparison.InvariantCultureIgnoreCase);
						     return index == 0 || index > 0 && char.IsSeparator(x.Name[index - 1]);
					});
				if (nom != null)
				{
					searchModel.CurrentResult = nom.Id;
					searchModel.SearchResult = true;
				}
				else
					searchModel.SearchResult = false;
			}
			else
			{
				int previousResultIndex = searchModel.NomList.FindIndex(x => x.Id == searchModel.PreviousResult);
				searchModel.SearchResult = false;
				for (int i = previousResultIndex + 1; i < searchModel.NomList.Count && !searchModel.SearchResult; i++)
				{
					int index = searchModel.NomList[i].Name.IndexOf(searchModel.SearchPattern, 0, StringComparison.InvariantCultureIgnoreCase);
					bool r=index == 0 || index > 0 && char.IsSeparator(searchModel.NomList[i].Name[index - 1]);
					if (r)
					{
						searchModel.SearchResult = true;
						searchModel.CurrentResult = searchModel.NomList[i].Id;
					}
				}
			}
			return searchModel;
		}
	}
}
