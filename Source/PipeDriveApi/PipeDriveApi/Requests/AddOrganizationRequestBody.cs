using PipeDriveApi.Enums;
using System;
using System.Collections.Generic;

namespace PipeDriveApi.Requests
{
	public class AddOrganizationRequestBody : IAddRequestBody
	{
		public string Name;
		public int? OwnerId;
		public Visibility VisibleTo;
		public DateTime? AddTime;

		public AddOrganizationRequestBody(
			string name,
			int? ownerId = null,
			Visibility visibleTo = Visibility.Shared,
			DateTime? addTime = null)
		{
			Name = name;
			OwnerId = ownerId;
			VisibleTo = visibleTo;
			AddTime = addTime;
		}
	}
}
