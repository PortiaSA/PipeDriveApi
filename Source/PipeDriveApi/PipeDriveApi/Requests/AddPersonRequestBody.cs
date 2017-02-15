using PipeDriveApi.Enums;
using System;
using System.Collections.Generic;

namespace PipeDriveApi.Requests
{
	public class AddPersonRequestBody : IAddRequestBody
	{
		public string Name;
		public int? OwnerId;
		public int? OrgId;
		public IEnumerable<string> Email;
		public IEnumerable<string> Phone;
		public Visibility VisibleTo;
		public DateTime? AddTime;

		public AddPersonRequestBody(
			string name,
			int? ownerId = null,
			int? orgId = null,
			IEnumerable<string> email = null,
			IEnumerable<string> phone = null,
			Visibility visibleTo = Visibility.Shared,
			DateTime? addTime = null)
		{
			Name = name;
			OwnerId = ownerId;
			OrgId = orgId;
			Email = email;
			Phone = phone;
			VisibleTo = visibleTo;
			AddTime = addTime;
		}
	}
}
