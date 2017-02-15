using NUnit.Framework;
using PipeDriveApi.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PipeDriveApi.Tests
{
	[TestFixture]
	public class NoteTest : BaseFixture
	{
		[Test]
		public async Task CreateAndDeleteNote()
		{
			var organization = await client.Organizations.AddAsync(new AddOrganizationRequestBody(organizationName));
			var person = await client.Persons.AddAsync(
				new AddPersonRequestBody(
					personName,
					email: new List<string> { personEmail },
					orgId: organization.Id
				)
			);

			var deal = await client.Deals.AddAsync(
				new AddDealRequestBody(
					dealTitle,
					person.Id,
					organization.Id,
					stageId: stageId
				)
			);

			var note = await client.Notes.AddAsync(
				new AddNoteRequestBody(
					noteContent,
					deal.Id,
					person.Id,
					organization.Id,
					isPinnedToDeal: true
				)
			);

			Assert.AreNotEqual(default(int), note.Id);

			// Cleanup
			 await client.Notes.DeleteAsync(note.Id);
			 await client.Deals.DeleteAsync(deal.Id);
			 await client.Persons.DeleteAsync(person.Id);
			 await client.Organizations.DeleteAsync(organization.Id);
		}
	}
}
