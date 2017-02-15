using NUnit.Framework;
using PipeDriveApi.Requests;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PipeDriveApi.Tests
{
	[TestFixture]
	public class DealTest : BaseFixture
	{
		[Test]
		public async Task CreateAndDeleteDeal()
		{
			var organization = await client.Organizations.AddAsync(new AddOrganizationRequestBody(organizationName));
			var person = await client.Persons.AddAsync(
				new AddPersonRequestBody(
					personName,
					email: new List<string> { personEmail },
					orgId: organization.Id
				)
			);

			var requestBody = new AddDealRequestBody(
				dealTitle,
				person.Id,
				organization.Id,
				stageId: stageId);
			var deal = await client.Deals.AddAsync(requestBody);

			Assert.AreNotEqual(default(int), deal.Id);
			Assert.AreEqual(personName, deal.PersonName);

			// Cleanup
			 await client.Deals.DeleteAsync(deal.Id);
			 await client.Persons.DeleteAsync(person.Id);
			 await client.Organizations.DeleteAsync(organization.Id);
		}
	}
}
