using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace ObjectSorting
{
    /// <summary>
    /// This util class holds the general purpose members that is required for this Sorting.
    /// </summary>
    public class Utils
    {
        /// <summary>
        /// URL which produces the JSON object with People and their pets.
        /// </summary>
        public static string BASE_URI = "http://agl-developer-test.azurewebsites.net";
        public static double SERVICE_TIMEOUT = 30;

        private string CatsWithGenderInAlphabeticalOrder = string.Empty;

        /// <summary>
        /// This method to provide the required outout by managing private methods.
        /// The outcome of this method is a string with Pets sorted alphabets and ordered by Owner Gender
        /// </summary>
        /// <returns>List of Pets under Owners Gender</returns>
        public string GetGenderAndPetsByOrder(List<Person> people)
        {
            try
            {
                if (people != null)
                    this.GetCatsByOwnerGender(this.GetGenderAndPets(people));

                return CatsWithGenderInAlphabeticalOrder;
            }
            catch (NullReferenceException ex)
            {
                return ex.Message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }


        /// <summary>
        /// This method creates a new list of objects by extracting the Name of the Pet and Gender of the Owner. if the person dosent have pet list then it dosent do any action on that element.
        /// </summary>
        /// <param name="people"></param>
        /// <returns></returns>
        private List<PetNameWithOwnerGender> GetGenderAndPets(List<Person> people)
        {

            List<PetNameWithOwnerGender> allCatNameWithOwnerGender = new List<PetNameWithOwnerGender>();
            if (people != null)
                people.ForEach(person => { if (person.Pets != null) GetCatListWithGender(ref allCatNameWithOwnerGender, person); });

            return allCatNameWithOwnerGender;
        }

        /// <summary>
        /// This method checks the List
        /// </summary>
        /// <param name="allCatNameWithOwnerGender"></param>
        /// <param name="person"></param>
        private void GetCatListWithGender(ref List<PetNameWithOwnerGender> allCatNameWithOwnerGender, Person person)
        {
            List<PetNameWithOwnerGender> allCatNameWithOwner = allCatNameWithOwnerGender;
            if (person != null && allCatNameWithOwnerGender != null)
                person.Pets.ForEach(pet => { if (pet != null && pet.Type == "Cat") CatListWithGenderOrdered(ref allCatNameWithOwner, pet, person.Gender); });
        }

        /// <summary>
        /// This method addes the derived object which contains Pet Name and Owner Gender.
        /// </summary>
        /// <param name="allCatsNameWithOwnerGender"> ref variable</param>
        /// <param name="pet">Pet object</param>
        /// <param name="personGender">Person Gender</param>
        private void CatListWithGenderOrdered(ref List<PetNameWithOwnerGender> allCatsNameWithOwnerGender, Pet pet, string personGender)
        {
            PetNameWithOwnerGender petNameWithOwnerGender = null;
            if (personGender != string.Empty && pet != null)
            {
                petNameWithOwnerGender = new PetNameWithOwnerGender { OwnerGender = personGender, PetName = pet.Name };
                allCatsNameWithOwnerGender.Add(petNameWithOwnerGender);
            }
        }

        /// <summary>
        /// This method performs the group by "Gender" on the Derived List that contains Owner Name and Pet Details
        /// </summary>
        /// <param name="allPetsWithGender"></param>
        private void GetCatsByOwnerGender(List<PetNameWithOwnerGender> allPetsWithGender)
        {
            if (allPetsWithGender != null)
                allPetsWithGender.GroupBy(group => group.OwnerGender).ToList().ForEach(group => SetResultToMemberVariable(group, group.Key));
        }

        /// <summary>
        /// This method iterate  through IEnumerable and sort the pets Name under the given Gender(passed as Key).
        /// </summary>
        /// <param name="gender"></param>
        /// <param name="groupName"></param>
        private void SetResultToMemberVariable(IEnumerable<PetNameWithOwnerGender> gender, string groupName)
        {
            this.CatsWithGenderInAlphabeticalOrder += string.Format("\n{0}\n\n", groupName);
            if (gender != null)
                gender.OrderBy(group => group.PetName).ToList().ForEach(p => this.CatsWithGenderInAlphabeticalOrder += string.Format("{0}\n", p.PetName));
        }

        /// <summary>
        /// This method extracts the JSON from the URL and returns as a List of Objects.
        /// </summary>
        /// <returns></returns>
        internal List<Person> GetPeople()
        {

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("type", "Application/json");
                httpClient.Timeout = TimeSpan.FromSeconds(Utils.SERVICE_TIMEOUT);/*Timeout if the response dosnet come in 30 seconds*/

                var response = httpClient.GetAsync(string.Format("{0}/people.json", Utils.BASE_URI)).Result;

                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<List<Person>>().Result;
                }

            }
            return null;
        }
    }
}
