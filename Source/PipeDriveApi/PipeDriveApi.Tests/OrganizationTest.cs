using NUnit.Framework;
using PipeDriveApi.Requests;
using System.Linq;
using System.Threading.Tasks;

namespace PipeDriveApi.Tests
{
	[TestFixture]
	public class OrganizationTest : BaseFixture
	{
		[OneTimeTearDown]
		public async Task CleanupOrganizations()
		{
			var organizations = await client.Organizations.FindAsync(organizationName);
			foreach (var org in organizations)
			{
				await client.Organizations.DeleteAsync(org.Id);
			}
		}

		[Test]
		public async Task CreateAndDeleteOrganization()
		{
			var organization = await client.Organizations.AddAsync(new AddOrganizationRequestBody(organizationName));

			Assert.AreNotEqual(default(int), organization.Id);
			Assert.AreEqual(organizationName, organization.Name);

			var deletedOrganization = await client.Organizations.DeleteAsync(organization.Id);
			Assert.AreEqual(organization.Id, deletedOrganization.Id);
		}

		[Test]
		public async Task FindOrganization()
		{
			var organization = await client.Organizations.AddAsync(new AddOrganizationRequestBody(organizationName));

			var fetched = await client.Organizations.FindAsync("Test");

			Assert.IsNotNull(fetched.FirstOrDefault(o => o.Id == organization.Id));
		}

		[Test]
		public async Task GetAllOrganizations()
		{
			var organizations = await client.Organizations.GetAllAsync();

			Assert.IsNotEmpty(organizations);
		}
	}
}
