using NUnit.Framework;

namespace PipeDriveApi.Tests
{
	[TestFixture]
	public class BaseFixture
	{
		protected PipeDriveClient client;
		protected readonly string organizationName = "TestOrganization";
		protected readonly string personName = "TestPerson";
		protected readonly string personEmail = "test@person.com";
		protected readonly string dealTitle = "TestDeal";
		protected readonly int stageId = 23;
		protected readonly string noteContent = "TestNote";

		[OneTimeSetUp]
		public void Init()
		{
			client = new PipeDriveClient("API key");
		}
	}
}
