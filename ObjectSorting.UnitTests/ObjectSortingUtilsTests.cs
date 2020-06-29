using NUnit.Framework;
using ObjectSorting;

namespace ObjectSorting.UnitTests
{
    public class ObjectSortingUtilsTests
    {

        [Test]
        public void GetGenderAndPetsByOrder_ListPets_GroupByGender()
        {
            var apiUtil = new Utils();
            Assert.AreEqual(ObjectSortingMockData.VALIDJSON_OUTPUT, apiUtil.GetGenderAndPetsByOrder(ObjectSortingMockData.GetValidJSONPeoplePets()));
        }              

        [Test]
        public void GetGenderAndPetsByOrder_ListPets_NoPetsAvailable()
        {
            var apiUtil = new Utils();
            Assert.AreEqual(ObjectSortingMockData.NOVALUESTODISPLAY, apiUtil.GetGenderAndPetsByOrder(ObjectSortingMockData.GetValidJSONPeoplePetsNull()));
        }

        [Test]
        public void GetGenderAndPetsByOrder_ListPets_PersonNull()
        {
            var apiUtil = new Utils();
            Assert.AreEqual(ObjectSortingMockData.NOVALUESTODISPLAY, apiUtil.GetGenderAndPetsByOrder(ObjectSortingMockData.LISTOFPEOPLENULL));
        }

        [Test]
        public void GetGenderAndPetsByOrder_ListPets_EmptyJSON()
        {
            var apiUtil = new Utils();
            Assert.AreEqual(ObjectSortingMockData.NOVALUESTODISPLAY, apiUtil.GetGenderAndPetsByOrder(ObjectSortingMockData.LISTOFPEOPLEEMPTYOBJECT));
        }
    }
}