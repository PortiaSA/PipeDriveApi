using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PipeDriveApi.Tests
{
	[TestFixture]
	public class DealTest : BaseFixture
	{
		private readonly string organizationName = "TestOrganization";
		private readonly string personName = "TestPerson";
		private readonly string personEmail = "test@person.com";
		private readonly string dealTitle = "TestDeal";
		private readonly int stageId = 23;

		[Test]
		public async Task CreateAndDeleteDeal()
		{
			var organization = await client.Organizations.AddAsync(organizationName);
			var person = await client.Persons.AddAsync(
				personName,
				email: new List<string> { personEmail },
				orgId: organization.Id);

			var deal = await client.Deals.AddAsync(
				dealTitle,
				person.Id,
				organization.Id,
				stageId: stageId);

			Assert.AreNotEqual(default(int), deal.Id);
			Assert.AreEqual(personName, deal.PersonName);

			// Cleanup
			 await client.Deals.DeleteAsync(deal.Id);
			 await client.Persons.DeleteAsync(person.Id);
			 await client.Organizations.DeleteAsync(organization.Id);
		}
	}
}
