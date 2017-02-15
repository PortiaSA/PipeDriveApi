using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PipeDriveApi.Tests
{
	[TestFixture]
	public class NoteTest : BaseFixture
	{
		private readonly string organizationName = "TestOrganization";
		private readonly string personName = "TestPerson";
		private readonly string personEmail = "test@person.com";
		private readonly string dealTitle = "TestDeal";
		private readonly int stageId = 23;
		private readonly string noteContent = "TestNote";

		[Test]
		public async Task CreateAndDeleteNote()
		{
			var organization = await client.Organizations.AddAsync(organizationName);
			var person = await client.Persons.AddAsync(
				personName,
				email: new List<string> { personEmail },
				orgId: organization.Id
			);
			var deal = await client.Deals.AddAsync(
				dealTitle,
				person.Id,
				organization.Id,
				stageId: stageId);

			var note = await client.Notes.AddAsync(
				noteContent,
				deal.Id,
				person.Id,
				organization.Id,
				isPinnedToDeal: true);

			Assert.AreNotEqual(default(int), note.Id);

			// Cleanup
			 await client.Notes.DeleteAsync(note.Id);
			 await client.Deals.DeleteAsync(deal.Id);
			 await client.Persons.DeleteAsync(person.Id);
			 await client.Organizations.DeleteAsync(organization.Id);
		}
	}
}
