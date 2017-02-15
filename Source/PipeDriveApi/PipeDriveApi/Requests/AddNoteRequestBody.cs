using PipeDriveApi.Enums;
using System;

namespace PipeDriveApi.Requests
{
	public class AddNoteRequestBody : IAddRequestBody
	{
		public string Content;
		public int? DealId;
		public int? PersonId;
		public int? OrgId;
		public bool PinnedToDealFlag;
		public bool PinnedToOrganizationFlag;
		public bool PinnedToPersonFlag;

		public AddNoteRequestBody(
			string content,
			int? dealId = null,
			int? personId = null,
			int? orgId = null,
			bool isPinnedToDeal = false,
			bool isPinnedToOrganization = false,
			bool isPinnedToPerson = false)
		{
			Content = content;
			DealId = dealId;
			PersonId = personId;
			OrgId = orgId;
			PinnedToDealFlag = isPinnedToDeal;
			PinnedToOrganizationFlag = isPinnedToOrganization;
			PinnedToPersonFlag = isPinnedToPerson;
		}
	}
}
