using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Linq;
using Newtonsoft;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace ObjectSorting
{
    public class PersonController
    {
        /// <summary>
        /// This method is to provide the final outcome to the consumer.Outcome of the method can be
        /// 1 - Valid input Json -> returns the string of sorted pets grouped by Gender
        /// 2 - Any run time Exception - > returns the exception message
        /// 3- No pets or no people in the input Json -> returns the message "No values to display.
        /// </summary>
        /// <returns></returns>
        public string GetListOfPetsWithOwnerGenderOrderedByAlphabets()
        {
            string result = string.Empty;
            var apiUtil = new Utils();
            try
            {
                result = apiUtil.GetGenderAndPetsByOrder(apiUtil.GetPeople());

                if (result == string.Empty)
                    result = "No values to display";
            }
            catch(Exception ex)
            {
                result = ex.Message;
            }
            finally
            {
                apiUtil = null;
            }
            return result;
        }

    }
}
