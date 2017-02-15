using NUnit.Framework;
using PipeDriveApi.EntityServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PipeDriveApi.Tests
{
	[TestFixture]
	public class PersonTest : BaseFixture
	{
		private readonly string personName = "TestPerson";
		private readonly string personEmail = "test@person.com";

		[OneTimeTearDown]
		public async Task CleanupPersons()
		{
			var persons = await client.Persons.FindAsync(personEmail);
			foreach (var person in persons)
			{
				await client.Persons.DeleteAsync(person.Id);
			}
		}

		[Test]
		public async Task CreateAndDeletePerson()
		{
			var person = await client.Persons.AddAsync(
				personName, 
				email: new List<string> { personEmail }
			);

			Assert.AreNotEqual(default(int), person.Id);
			Assert.AreEqual(personName, person.Name);
			var emails = person.Email.Select(e => e.Value).ToList();
			Assert.Contains(personEmail, emails);

			var deletedPerson = await client.Persons.DeleteAsync(person.Id);
			Assert.AreEqual(person.Id, deletedPerson.Id);
		}

		[Test]
		public async Task FindPerson()
		{
			var person = await client.Persons.AddAsync(
				personName,
				email: new List<string> { personEmail }
			);

			var fetched = await client.Persons.FindAsync(personEmail);

			Assert.Contains(personName, fetched.Select(p => p.Name).ToList());
		}

		[Test]
		public async Task GetAllPersons()
		{
			var persons = await client.Persons.GetAllAsync();

			Assert.IsNotEmpty(persons);
		}
	}
}
