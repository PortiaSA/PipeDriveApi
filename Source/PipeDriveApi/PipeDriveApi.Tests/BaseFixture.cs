using NUnit.Framework;

namespace PipeDriveApi.Tests
{
	[TestFixture]
	public class BaseFixture
	{
		protected PipeDriveClient client;

		[OneTimeSetUp]
		public void Init()
		{
			client = new PipeDriveClient("API token");
		}
	}
}
