using System;

namespace ObjectSorting
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new PersonController();
            string DisplayOutput = string.Empty;

            try
            {
                Console.WriteLine(controller.GetListOfPetsWithOwnerGenderOrderedByAlphabets());
            }
            catch(Exception generalException)
            {
                Console.WriteLine(generalException.Message);
            }
            finally
            {
                controller = null;
            }
            
        }
    }
}
