using PipeDriveApi.Enums;
using System;

namespace PipeDriveApi.Requests
{
	public class AddDealRequestBody : IAddRequestBody
	{
		public string Title;
		public int PersonId;
		public int OrgId;
		public string Value;
		public string Currency;
		public int? UserId;
		public int? StageId;
		public string Status;
		public string LostReason;
		public DateTime? AddTime;
		public Visibility VisibleTo;


		public AddDealRequestBody(
			string title,
			int personId,
			int orgId,
			string value = null,
			string currency = null,
			int? userId = null,
			int? stageId = null,
			DealStatus? status = null,
			string lostReason = null,
			DateTime? addTime = null,
			Visibility visibleTo = Visibility.Shared)
		{
			Title = title;
			PersonId = personId;
			OrgId = orgId;
			Value = value;
			Currency = currency;
			UserId = userId;
			StageId = stageId;
			Status = status?.ToString();
			LostReason = lostReason;
			AddTime = addTime;
			VisibleTo = visibleTo;
		}
	}
}
