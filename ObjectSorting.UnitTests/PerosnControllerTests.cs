using System;
using NUnit.Framework;
using ObjectSorting;

namespace ObjectSorting.UnitTests
{
    class PerosnControllerTests
    {
        [Test]
        public void GetGenderAndPetsByOrder_ListPets_WrongURL()
        {
            var personcontroller = new PersonController();
            ObjectSorting.Utils.BASE_URI = "http://Something.wrongURL";
            var str = personcontroller.GetListOfPetsWithOwnerGenderOrderedByAlphabets();
            Assert.AreEqual(ObjectSortingMockData.WRONGURLMESSAGE, personcontroller.GetListOfPetsWithOwnerGenderOrderedByAlphabets());
        }
    }
}
